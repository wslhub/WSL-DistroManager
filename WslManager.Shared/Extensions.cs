using System;
using System.Diagnostics;
using System.IO;
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

        public static WslQueryModel LoadWslDistroInfo(string wslQueryExecPath)
        {
            if (!File.Exists(wslQueryExecPath))
                throw new FileNotFoundException("Cannot execute WslQuery utility.");

            var psi = new ProcessStartInfo("WslQuery.exe")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
            };

            var result = default(WslQueryModel);

            using (var proc = Process.Start(psi))
            {
                proc.WaitForExit();
                var deserializer = new DataContractJsonSerializer(typeof(WslQueryModel));
                result = deserializer.ReadObject(proc.StandardOutput.BaseStream) as WslQueryModel;
            }

            return result;
        }
    }
}
