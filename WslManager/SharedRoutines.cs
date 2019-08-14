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

            var array = content.Distros.ToArray();
            for (int i = 0, cnt = array.Length; i < cnt; i++)
                list.Add(new DistroProperties(i, array[i]));
            return list;
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
