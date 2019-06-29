using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;

namespace WslManager.Structures
{
    public class DistroProperties 
    {
        public DistroProperties(RegistryKey key)
        {
            this.Properties = SharedRoutines.GetDistroProperties(key);
            this.ImageKey = SharedRoutines.GetImageKey(key);
        }

        [DisplayName("Distro Name")]
        public string DistroName {
            get => Properties[nameof(DistroName)];
            set => Properties[nameof(DistroName)] = value;
        }

        [DisplayName("Unique ID")]
        public string UniqueId {
            get => Properties[nameof(UniqueId)];
            set => Properties[nameof(UniqueId)] = value;
        }

        [DisplayName("Store Package Name")]
        public string AppxPackageName {
            get => Properties[nameof(AppxPackageName)];
            set => Properties[nameof(AppxPackageName)] = value;
        }

        [DisplayName("Distro Base Path")]
        public string BasePath {
            get => Properties[nameof(BasePath)];
            set => Properties[nameof(BasePath)] = value;
        }

        [DisplayName("WSL Version")]
        public string Version {
            get => Properties[nameof(Version)];
            set => Properties[nameof(Version)] = value;
        }

        [Browsable(false)]
        public Dictionary<string, string> Properties { get; }

        [Browsable(false)]
        public string ImageKey { get; }
    }
}
