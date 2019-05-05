using System;
using System.Runtime.Serialization;

namespace WslManager.Models
{
    [DataContract]
    public sealed class DistroFeedItem
    {
        [DataMember(Name = "id", IsRequired = true)]
        public string Id { get; set; }
        [DataMember(Name = "title", IsRequired = true)]
        public string Title { get; set; }
        [DataMember(Name = "url", IsRequired = true)]
        public Uri Url { get; set; }
        [DataMember(Name = "content_text", IsRequired = true)]
        public string ContentText { get; set; }
        [DataMember(Name = "image", IsRequired = true)]
        public Uri Image { get; set; }
        [DataMember(Name = "author", IsRequired = true)]
        public DistroFeedItemAuthor Author { get; set; }
    }
}
