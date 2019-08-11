using System;
using System.Collections.Generic;
using System.ComponentModel;
using WslManager.Shared;

namespace WslManager.Structures
{
    public class DistroProperties 
    {
        public DistroProperties(WslQueryDistroModel model)
        {
            WslDistroInfo = model ?? throw new ArgumentNullException(nameof(model));
            Properties = SharedRoutines.GetDistroProperties(model);
            ImageKey = SharedRoutines.GetImageKey(model);
        }

        public WslQueryDistroModel WslDistroInfo { get; private set; }

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

        [DisplayName("Distro Status")]
        public string DistroStatus {
            get => Properties[nameof(DistroStatus)];
            set => Properties[nameof(DistroStatus)] = value;
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
