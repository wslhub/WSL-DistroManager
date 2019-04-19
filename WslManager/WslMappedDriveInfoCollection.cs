using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WslManager
{
    [Serializable]
    public sealed class WslMappedDriveInfoCollection : KeyedCollection<string, WslMappedDriveInfo>
    {
        public WslMappedDriveInfoCollection() : base()
        {

        }

        public WslMappedDriveInfoCollection(IEnumerable<WslMappedDriveInfo> items) : this()
        {
            foreach (var eachItem in items.ToArray())
                this.Add(eachItem);
        }

        protected override string GetKeyForItem(WslMappedDriveInfo item)
        {
            return item.DriveName;
        }
    }
}
