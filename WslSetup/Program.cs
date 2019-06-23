using System;
using System.IO;

namespace WslSetup
{
    internal class Program
    {
        private static void DownloadFile(string url, string filePath)
        {
            throw new NotImplementedException();
        }

        private static void ExpandArchive(string archivePath, string destDirectory, bool removeExistingContent)
        {
            throw new NotImplementedException();
        }

        private static void ImportTarballArchive(string distroName, string installDirectory, string tarballArchivePath)
        {
            throw new NotImplementedException();
        }

        private static void InvokeAddUserCommand(string distroName, string accountId)
        {
            throw new NotImplementedException();
        }

        private static string GetWslDistroId(string distroName)
        {
            throw new NotImplementedException();
        }

        private static int GetAccountUid(string distroName, string accountId)
        {
            throw new NotImplementedException();
        }

        private static void SetDefaultAccountUid(string distroName, int accountUid)
        {
            throw new NotImplementedException();
        }

        private static void LaunchWslDistroAsync(string distroName)
        {
            throw new NotImplementedException();
        }

        [STAThread]
        private static void Main()
        {
            var distroType = "debian";
            var distroUrl = "https://aka.ms/wsl-debian-gnulinux";

            Console.WriteLine($"This script will setup new {distroType} distro.");

            Console.Write("Enter Distro Alias: ");
            var distroName = Console.ReadLine();

            Console.Write("Enter Account ID: ");
            var accountId = Console.ReadLine();

            Console.WriteLine($"Distro Name: {distroName}");
            Console.WriteLine($"Account Id: {accountId}");

            Console.Write("Press Y for continue, N for cancel. [YN]");

            if (char.ToUpperInvariant(Console.ReadKey().KeyChar) != 'Y')
                return;

            Console.WriteLine($"Download {distroType} from Microsoft CDN");
            DownloadFile(distroUrl, Path.GetFullPath("package.zip"));
            ExpandArchive(Path.GetFullPath("package.zip"), Path.GetFullPath("package"), true);

            var distroDir = Path.Combine(
                Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)),
                "Distro", distroName);
            Console.WriteLine($"Create distro installation directory at {distroDir}");
            if (!Directory.Exists(distroDir))
                Directory.CreateDirectory(distroDir);

            Console.WriteLine($"Install distro {distroName}. This procedure may take long time. Please wait patiently.");
            ImportTarballArchive(distroName, distroDir, Path.Combine(Path.GetFullPath("package"), "install.tar.gz"));

            Console.WriteLine($"Add new user and set as a default user");
            InvokeAddUserCommand(distroName, accountId);

            Console.WriteLine($"Discover WSL distro ID");
            var distroGuid = GetWslDistroId(distroName);

            Console.WriteLine($"Discover Linux UID");
            var accountUid = GetAccountUid(distroName, accountId);

            Console.WriteLine("Change Default Linux UID");
            SetDefaultAccountUid(distroName, accountUid);

            Console.WriteLine("Launch installed new distro");
            LaunchWslDistroAsync(distroName);

            Console.WriteLine("Cleaning up intermediate directory and files");
            if (Directory.Exists(Path.GetFullPath("package")))
                Directory.Delete(Path.GetFullPath("package"), true);
            if (File.Exists(Path.GetFullPath("package.zip")))
                File.Delete(Path.GetFullPath("package.zip"));
        }
    }
}
