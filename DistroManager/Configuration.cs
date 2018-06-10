using System.Configuration;

namespace DistroManager
{
    internal static class Configuration
    {
        public static string DistroName
        {
            get => ConfigurationManager.AppSettings["DistroName"];
        }

        public static string DistroDisplayName
        {
            get => ConfigurationManager.AppSettings["DistroDisplayName"];
        }

        public static string DistroInstallFilePath
        {
            get => ConfigurationManager.AppSettings["DistroInstallFilePath"];
        }
    }
}
