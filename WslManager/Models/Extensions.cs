using System;

namespace WslManager.Models
{
    public static class Extensions
    {
        public static bool IsAppxDistro(this DistroFeedItem item)
        {
            if (item != null && item.Id.StartsWith("appx_", StringComparison.Ordinal))
                return true;

            return false;
        }

        public static bool IsOfficialDistro(this DistroFeedItem item)
        {
            if (item != null && item.Url.Host.Equals("aka.ms", StringComparison.Ordinal))
                return true;

            return false;
        }
    }
}
