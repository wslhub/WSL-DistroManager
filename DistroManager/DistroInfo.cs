using System;
using System.Collections.Generic;
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

        public string BasePath
        {
            get => _basePath;
            internal set => _basePath = value;
        }

        public IEnumerable<KeyValuePair<string, string>> DefaultEnvironment
        {
            get => _defaultEnvironment;
            internal set => _defaultEnvironment = value;
        }

        public int DefaultUid
        {
            get => _defaultUid;
            internal set => _defaultUid = value;
        }

        public string DistributionName
        {
            get => _distributionName;
            internal set => _distributionName = value;
        }

        public int Flags
        {
            get => _flags;
            internal set => _flags = value;
        }

        public string KernelCommandLine
        {
            get => _kernelCommandLine;
            internal set => _kernelCommandLine = value;
        }

        public int State
        {
            get => _state;
            internal set => _state = value;
        }

        public int Version
        {
            get => _version;
            internal set => _version = value;
        }
    }
}
