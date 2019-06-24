using Microsoft.Win32;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using WslManager.Shared;

namespace WslSetup
{
    internal class Program
    {
        private static void DownloadFile(string url, string filePath)
        {
            using (var webClient = new WebClient())
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                webClient.DownloadFile(url, filePath);
            }
        }

        private static void ExpandArchive(string archivePath, string destDirectory, bool removeExistingContent)
        {
            if (removeExistingContent && Directory.Exists(destDirectory))
                Directory.Delete(destDirectory, true);

            ZipFile.ExtractToDirectory(archivePath, destDirectory);
        }

        private static int ImportTarballArchive(string distroName, string installDirectory, string tarballArchivePath)
        {
            var psi = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $"--import {distroName} {installDirectory} {tarballArchivePath}")
            {
                UseShellExecute = false,
            };

            var proc = Process.Start(psi);
            proc.WaitForExit();
            return proc.ExitCode;
        }

        private static int InvokeAddUserCommand(string distroName, string accountId)
        {
            var psi = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $"-d {distroName} -u root -- adduser {accountId}")
            {
                UseShellExecute = false,
            };

            var proc = Process.Start(psi);
            proc.WaitForExit();
            return proc.ExitCode;
        }

        private static string GetWslDistroId(string distroName)
        {
            using (var regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Lxss", false))
            {
                foreach (var eachSubKeyName in regKey.GetSubKeyNames())
                {
                    using (var eachSubKey = regKey.OpenSubKey(eachSubKeyName, false))
                    {
                        var eachDistroName = eachSubKey.GetValue("DistributionName", null) as string;
                        if (eachDistroName == null || !string.Equals(eachDistroName, distroName, StringComparison.OrdinalIgnoreCase))
                            continue;
                        return Path.GetFileName(eachSubKey.Name);
                    }
                }
            }

            return null;
        }

        private static int? GetAccountUid(string distroName, string accountId)
        {
            var psi = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $"-d {distroName} -- id -u {accountId}")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            var proc = Process.Start(psi);
            proc.WaitForExit();

            if (proc.ExitCode != 0)
                return null;

            var accountUidRaw = (proc.StandardOutput.ReadToEnd() ?? string.Empty).Trim();
            if (!int.TryParse(accountUidRaw, out int parsedValue))
                return null;

            return parsedValue;
        }

        private static void SetDefaultAccountUid(string distroGuid, int accountUid)
        {
            using (var regKey = Registry.CurrentUser.OpenSubKey($@"Software\Microsoft\Windows\CurrentVersion\Lxss\{distroGuid}", true))
            {
                regKey.SetValue("DefaultUid", accountUid, RegistryValueKind.DWord);
            }
        }

        private static void LaunchWslDistroAsync(string distroName)
        {
            var psi = new ProcessStartInfo(
                   Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                   $"-d {distroName}")
            {
                UseShellExecute = true,
            };

            Process.Start(psi);
        }

        [STAThread]
        private static void Main(string[] args)
        {
            if (IntPtr.Size == 4)
            {
                Console.Error.WriteLine("This build of process seems 32-bit version. Please turn off 32-bit preferness or rebuild as x64 build.");
                Environment.Exit(1);
            }

            var packageZipPath = Path.GetFullPath("package.zip");
            var packageDirPath = Path.GetFullPath("package");

            var distroType = args.ElementAtOrDefault(0);
            Console.WriteLine($"This script will setup new {distroType} distro.");

            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, error) =>
                {
                    // If the certificate is a valid, signed certificate, return true.
                    if (error == SslPolicyErrors.None)
                        return true;

                    Console.Error.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                        cert.Subject,
                        error.ToString());

                    return false;
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string accountId;

                Console.WriteLine("Loading WSLHUB feed.");
                var feedUrl = ConfigurationManager.AppSettings["FeedUrl"];
                var feed = Extensions.LoadDistroFeed(feedUrl);
                if (feed == null)
                {
                    Console.Error.WriteLine("Cannot load WSLHUB feed.");
                    Environment.Exit(1);
                }

                var distro = feed.Items
                    .Where(x => string.Equals(x.Id, distroType, StringComparison.Ordinal))
                    .FirstOrDefault();

                if (distro == null)
                {
                    Console.Error.WriteLine("Cannot find distro URL from feed.");
                    Environment.ExitCode = 1;
                    return;
                }

                if (!distro.IsAppxDistro())
                {
                    Console.Error.WriteLine("Unsupported distro type.");
                    Environment.ExitCode = 1;
                    return;
                }

                var distroUrl = distro.Url.AbsoluteUri;
                var distroName = string.IsNullOrWhiteSpace(distro.Title) ? distro.Id : distro.Title;

                do
                {
                    Console.Write("Enter Distro Alias: ");
                    distroName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(distroName))
                    {
                        distroName = null;
                        Console.Error.WriteLine("Please specify distro alias.");
                        continue;
                    }
                    if (GetWslDistroId(distroName) != null)
                    {
                        distroName = null;
                        Console.Error.WriteLine("Already used distro alias.");
                        continue;
                    }
                }
                while (string.IsNullOrWhiteSpace(distroName));

                do
                {
                    Console.Write("Enter Account ID: ");
                    accountId = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(accountId))
                    {
                        accountId = null;
                        Console.Error.WriteLine("Please specify account ID.");
                        continue;
                    }
                }
                while (string.IsNullOrWhiteSpace(accountId));

                Console.WriteLine($"Distro Name: {distroName}");
                Console.WriteLine($"Account Id: {accountId}");

                Console.Write("Press Y for continue, N for cancel. [YN]");

                if (char.ToUpperInvariant(Console.ReadKey().KeyChar) != 'Y')
                {
                    Environment.ExitCode = 2;
                    return;
                }

                Console.WriteLine();

                int subExitCode;

                Console.WriteLine($"Download {distroType} from Microsoft CDN");
                DownloadFile(distroUrl, packageZipPath);
                ExpandArchive(packageZipPath, packageDirPath, true);

                var distroDir = Path.Combine(
                    Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)),
                    "Distro", distroName);
                Console.WriteLine($"Create distro installation directory at {distroDir}");
                if (!Directory.Exists(distroDir))
                    Directory.CreateDirectory(distroDir);

                Console.WriteLine($"Install distro {distroName}. This procedure may take long time. Please wait patiently.");
                subExitCode = ImportTarballArchive(distroName, distroDir, Path.Combine(packageDirPath, "install.tar.gz"));
                if (subExitCode != 0)
                {
                    Console.Error.WriteLine("WSL import failed.");
                    Environment.ExitCode = 3;
                    return;
                }

                Console.WriteLine($"Add new user and set as a default user");
                subExitCode = InvokeAddUserCommand(distroName, accountId);
                if (subExitCode != 0)
                {
                    Console.Error.WriteLine("WSL adduser failed.");
                    Environment.ExitCode = 4;
                    return;
                }

                Console.WriteLine($"Discover WSL distro ID");
                var distroGuid = GetWslDistroId(distroName);
                if (distroGuid == null)
                {
                    Console.Error.WriteLine("Cannot find WSL distro ID.");
                    Environment.ExitCode = 5;
                    return;
                }

                Console.WriteLine($"Discover Linux UID");
                var accountUid = GetAccountUid(distroName, accountId);
                if (!accountUid.HasValue)
                {
                    Console.Error.WriteLine("Cannot find user linux UID.");
                    Environment.ExitCode = 6;
                    return;
                }

                Console.WriteLine("Change Default Linux UID");
                SetDefaultAccountUid(distroGuid, accountUid.Value);

                Console.WriteLine("Launch installed new distro");
                LaunchWslDistroAsync(distroName);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                Environment.ExitCode = 7;
            }
            finally
            {
                Console.WriteLine("Cleaning up intermediate directory and files");
                if (Directory.Exists(packageDirPath))
                    Directory.Delete(packageDirPath, true);
                if (File.Exists(packageZipPath))
                    File.Delete(packageZipPath);
            }
        }
    }
}
