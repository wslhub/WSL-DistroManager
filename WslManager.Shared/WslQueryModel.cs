using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WslManager.Shared
{
    [DataContract]
    public sealed class WslQueryModel
    {
        [DataMember(Name = "succeed")]
        public bool Succeed { get; set; }

        [DataMember(Name = "error", IsRequired = false)]
        public string Error { get; set; }

        [DataMember(Name = "hresult", IsRequired = false)]
        public uint? HResult { get; set; }

        [DataMember(Name = "distros", IsRequired = false)]
        public List<WslQueryDistroModel> Distros { get; set; }
    }

    [DataContract]
    public sealed class WslQueryDistroModel
    {
        [DataMember(Name = "succeed")]
        public bool Succeed { get; set; }

        [DataMember(Name = "error", IsRequired = false)]
        public string Error { get; set; }

        [DataMember(Name = "hresult", IsRequired = false)]
        public uint? HResult { get; set; }

        [DataMember(Name = "basePath")]
        public string BasePath { get; set; }

        [DataMember(Name = "distroName")]
        public string DistroName { get; set; }

        [DataMember(Name = "kernelCommandLine")]
        public string KernelCommandLine { get; set; }

        [DataMember(Name = "defaultEnvironmentVariables")]
        public List<string> DefaultEnvironment { get; set; }

        [DataMember(Name = "defaultUid")]
        public int DefaultUid { get; set; }

        [DataMember(Name = "enableInterop")]
        public bool EnableInterop { get; set; }

        [DataMember(Name = "enableDriveMounting")]
        public bool EnableDriveMounting { get; set; }

        [DataMember(Name = "appendNtPath")]
        public bool AppendNtPath { get; set; }

        [DataMember(Name = "hasDefaultFlag")]
        public bool HasDefaultFlag { get; set; }

        [DataMember(Name = "distroFlags")]
        public int Flags { get; set; }

        [DataMember(Name = "distroId")]
        public string DistroId { get; set; }

        [DataMember(Name = "isDefaultDistro")]
        public bool IsDefaultDistro { get; set; }

        [DataMember(Name = "distroStatus")]
        public string DistroStatus { get; set; }

        [DataMember(Name = "wslVersion")]
        public int WslVersion { get; set; }
    }
}
