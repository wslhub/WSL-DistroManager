using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DistroManager
{
    public sealed class DistroInfo
    {
        private string _basePath;
        private IEnumerable<KeyValuePair<string, string>> _defaultEnvironment;
        private int _defaultUid;
        private string _distributionName;
        private int _flags;
        private string _kernelCommandLine;
        private int _state;
        private int _version;

        [DisplayName("Base Path")]
        [Description("Indicates where distro is installed on the system")]
        [Category("Information")]
        public string BasePath
        {
            get => _basePath;
            internal set => _basePath = value;
        }

        [DisplayName("Environment Variables")]
        [Description("Environment variables to be pre-specified when starting distro")]
        [Category("Information")]
        public IEnumerable<KeyValuePair<string, string>> DefaultEnvironment
        {
            get => _defaultEnvironment;
            internal set => _defaultEnvironment = value;
        }

        [DisplayName("Default UID")]
        [Description("The internal ID value of the Linux user to be automatically logged in")]
        [Category("Information")]
        public int DefaultUid
        {
            get => _defaultUid;
            internal set => _defaultUid = value;
        }

        [DisplayName("Distro Name")]
        [Description("Distribution's name")]
        [Category("Information")]
        public string DistributionName
        {
            get => _distributionName;
            internal set => _distributionName = value;
        }

        [DisplayName("Flags")]
        [Description("Distribution's properties")]
        [Category("Information")]
        public int Flags
        {
            get => _flags;
            internal set => _flags = value;
        }

        [DisplayName("Kernel Command Line")]
        [Description("Kernel startup parameters")]
        [Category("Information")]
        public string KernelCommandLine
        {
            get => _kernelCommandLine;
            internal set => _kernelCommandLine = value;
        }

        [DisplayName("Installation State")]
        [Description("Distribution's install state")]
        [Category("Information")]
        public int State
        {
            get => _state;
            internal set => _state = value;
        }

        [DisplayName("Version")]
        [Description("Distribution's version")]
        [Category("Information")]
        public int Version
        {
            get => _version;
            internal set => _version = value;
        }
    }
}
