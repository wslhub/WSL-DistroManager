using System;
using System.Runtime.Serialization;

namespace WslManager.Models
{
    [DataContract]
    public sealed class DistroFeedItemAuthor
    {
        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; set; }
        [DataMember(Name = "url", IsRequired = true)]
        public Uri Url { get; set; }
        [DataMember(Name = "avatar", IsRequired = false)]
        public Uri Avatar { get; set; }
    }
}
