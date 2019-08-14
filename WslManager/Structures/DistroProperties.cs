using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using WslManager.Shared;

namespace WslManager.Structures
{
    public class DistroProperties 
    {
        public DistroProperties(int order, WslQueryDistroModel model)
        {
            Order = order;
            WslDistroInfo = model ?? throw new ArgumentNullException(nameof(model));
            Properties = GetDistroProperties(model);
            ImageKey = SharedRoutines.GetImageKey(model?.DistroName);
        }

        private string NormalizePath(string rawPath)
        {
            return Regex.Replace(rawPath ?? string.Empty, @"(^\\\\\?\\)", string.Empty, RegexOptions.Compiled);
        }

        private Dictionary<string, string> GetDistroProperties(WslQueryDistroModel model)
        {
            var properties = new Dictionary<string, string>();

            if (model == null)
                return properties;

            var distroName = model.DistroName;
            properties.Add(
                nameof(DistroProperties.DistroName),
                distroName);

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

        [Browsable(false)]
        public int Order { get; private set; }

        [Browsable(false)]
        public WslQueryDistroModel WslDistroInfo { get; private set; }

        [Browsable(true)]
        [DisplayName("Distro Name")]
        public string DistroName {
            get => Properties[nameof(DistroName)];
            set => Properties[nameof(DistroName)] = value;
        }

        [Browsable(true)]
        [DisplayName("Distro Status")]
        public string DistroStatus {
            get => Properties[nameof(DistroStatus)];
            set => Properties[nameof(DistroStatus)] = value;
        }

        [Browsable(false)]
        [DisplayName("Distro Base Path")]
        public string BasePath {
            get => Properties[nameof(BasePath)];
            set => Properties[nameof(BasePath)] = value;
        }

        [Browsable(true)]
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
