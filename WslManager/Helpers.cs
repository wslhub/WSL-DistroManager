using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using static System.Windows.Forms.ListViewItem;

namespace WslManager
{
    internal static class Helpers
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

        public static ListViewSubItem[] GetDistroProperties(RegistryKey key)
        {
            var properties = new List<ListViewSubItem>();

            if (key == null)
                return properties.ToArray();

            var distroName = (string)key.GetValue("DistributionName", "");
            properties.Add(new ListViewSubItem {
                Name = nameof(DistroListViewItem.DistroName),
                Text = distroName,
            });

            properties.Add(new ListViewSubItem
            {
                Name = nameof(DistroListViewItem.UniqueId),
                Text = Path.GetFileName(key.Name),
            });

            properties.Add(new ListViewSubItem
            {
                Name = nameof(DistroListViewItem.AppxPackageName),
                Text = (string)key.GetValue("PackageFamilyName", ""),
            });

            properties.Add(new ListViewSubItem
            {
                Name = nameof(DistroListViewItem.BasePath),
                Text = Regex.Replace((string)key.GetValue("BasePath", ""), @"(^\\\\\?\\)", string.Empty, RegexOptions.Compiled),
            });

            return properties.ToArray();
        }
    }
}
