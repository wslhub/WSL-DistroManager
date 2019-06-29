using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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

        public static string GetImageKey(RegistryKey key)
        {
            return GetImageKey(key?.GetValue("DistributionName", string.Empty) as string);
        }

        public static string NormalizePath(string rawPath)
        {
            return Regex.Replace(rawPath ?? string.Empty, @"(^\\\\\?\\)", string.Empty, RegexOptions.Compiled);
        }

        public static IEnumerable<DistroProperties> LoadDistroList()
        {
            var list = new List<DistroProperties>();
            var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Lxss");

            if (reg == null)
                return list;

            using (reg)
            {
                foreach (var eachSubKeyname in reg.GetSubKeyNames())
                {
                    using (var subReg = reg.OpenSubKey(eachSubKeyname))
                    {
                        list.Add(new DistroProperties(subReg));
                    }
                }
            }

            return list;
        }

        public static Dictionary<string, string> GetDistroProperties(RegistryKey key)
        {
            var properties = new Dictionary<string, string>();

            if (key == null)
                return properties;

            var distroName = (string)key.GetValue("DistributionName", "");
            properties.Add(
                nameof(DistroProperties.DistroName),
                distroName);

            properties.Add(
                nameof(DistroProperties.UniqueId),
                Path.GetFileName(key.Name));

            properties.Add(
                nameof(DistroProperties.AppxPackageName),
                (string)key.GetValue("PackageFamilyName", ""));

            properties.Add(
                nameof(DistroProperties.BasePath),
                NormalizePath((string)key.GetValue("BasePath", "")));

            properties.Add(
                nameof(DistroProperties.Version),
                key.GetValue("Version", 0).ToString());

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
