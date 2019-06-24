using System;
using System.Net;
using System.Net.Cache;
using System.Runtime.Serialization.Json;

namespace WslManager.Shared
{
    public static class Extensions
    {
        public static bool IsAppxDistro(this DistroFeedItem item)
        {
            if (item != null && item.Id.StartsWith("appx_", StringComparison.Ordinal))
                return true;

            return false;
        }

        public static bool IsAppxBundleDistro(this DistroFeedItem item)
        {
            if (item != null && item.Id.StartsWith("appxbundle_", StringComparison.Ordinal))
                return true;

            return false;
        }

        public static bool IsOfficialDistro(this DistroFeedItem item)
        {
            if (item != null && item.Url.Host.Equals("aka.ms", StringComparison.Ordinal))
                return true;

            return false;
        }

        public static DistroFeed LoadDistroFeed(string feedUrl)
        {
            var targetUri = new Uri($"{feedUrl}?t={DateTime.UtcNow.Ticks}", UriKind.Absolute);

            using (var client = new WebClient()
            {
                CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore),
            })
            {
                var feed = default(DistroFeed);
                using (var feedStream = client.OpenRead(targetUri))
                {
                    var deserializer = new DataContractJsonSerializer(typeof(DistroFeed));
                    feed = deserializer.ReadObject(feedStream) as DistroFeed;
                }

                return feed;
            }
        }
    }
}
