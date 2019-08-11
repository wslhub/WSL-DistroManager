using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using WslManager.Shared;
using WslManager.Structures;

namespace WslManager
{
    internal static class SharedRoutines
    {
        public static string GetImageKey(string distroName)
        {
            if (string.IsNullOrWhiteSpace(distroName))
                return "linux";

            string eval = (distroName ?? string.Empty).ToUpperInvariant().Trim();

            if (eval.Contains("DEBIAN"))
                return "debian";

            if (eval.Contains("UBUNTU"))
                return "ubuntu";

            if (eval.Contains("SLES") || eval.Contains("SUSE"))
                return "suse";

            if (eval.Contains("KALI"))
                return "kali";

            return "linux";
        }

        public static string GetImageKey(WslQueryDistroModel model)
        {
            return GetImageKey(model?.DistroName);
        }

        public static string NormalizePath(string rawPath)
        {
            return Regex.Replace(rawPath ?? string.Empty, @"(^\\\\\?\\)", string.Empty, RegexOptions.Compiled);
        }

        public static IEnumerable<DistroProperties> LoadDistroList()
        {
            var content = Extensions.LoadWslDistroInfo(Path.Combine(
                Path.GetDirectoryName(typeof(Program).Assembly.Location),
                "WslQuery.exe"));

            var list = new List<DistroProperties>();

            if (content == null)
                throw new Exception("Cannot lookup WSL distro states from the system.");

            if (!content.Succeed)
            {
                if (content.HResult.HasValue)
                    Marshal.ThrowExceptionForHR((int)content.HResult.Value);
                else
                    throw new Exception($"Unexpected error occurred: {content.Error}");
            }

            list.AddRange(content.Distros.Select(x => new DistroProperties(x)));
            return list;
        }

        public static Dictionary<string, string> GetDistroProperties(WslQueryDistroModel model)
        {
            var properties = new Dictionary<string, string>();

            if (model == null)
                return properties;

            var distroName = model.DistroName;
            properties.Add(
                nameof(DistroProperties.DistroName),
                distroName);

            properties.Add(
                nameof(DistroProperties.UniqueId),
                model.DistroId);

            properties.Add(
                nameof(DistroProperties.DistroStatus),
                model.DistroStatus);

            properties.Add(
                nameof(DistroProperties.BasePath),
                NormalizePath(model.BasePath));

            properties.Add(
                nameof(DistroProperties.Version),
                model.WslVersion.ToString());

            return properties;
        }

        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }

        public static string GetIconDirectoryPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "WslManagerIcons");
        }

        public static string GetWslShimDirectoryPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "WslManagerShims");
        }

        public static string GetWslShortcutDirectoryPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "WslManagerShortcuts");
        }

        public static bool IsWsl2SupportedOS()
        {
            var osVersion = Environment.OSVersion;
            return (osVersion.Platform == PlatformID.Win32NT &&
                osVersion.Version.Major >= 10 &&
                osVersion.Version.Major >= 0 &&
                osVersion.Version.Build >= 18917);
        }
    }
}
