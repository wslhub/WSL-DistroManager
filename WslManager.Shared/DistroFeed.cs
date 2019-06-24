using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace WslManager.Shared
{
    [DataContract]
    public sealed class DistroFeed
    {
        [DataMember(Name = "title", IsRequired = true)]
        public string Title { get; set; }
        [DataMember(Name = "version", IsRequired = true)]
        public string Version { get; set; }
        [DataMember(Name = "author", IsRequired = false)]
        public DistroFeedAuthor Author { get; set; }
        [DataMember(Name = "items", IsRequired = true)]
        public List<DistroFeedItem> Items { get; set; }
    }
}
