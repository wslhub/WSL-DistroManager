using Microsoft.Win32;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace WslManager
{
    public class DistroListViewItem : ListViewItem
    {
        public DistroListViewItem(RegistryKey key)
            : base(Helpers.GetDistroProperties(key), Helpers.GetImageKey(key))
        {
        }

        public string DistroName
        {
            get => SubItems[nameof(DistroName)].Text;
            set => SubItems[nameof(DistroName)].Text = value;
        }

        public string UniqueId
        {
            get => SubItems[nameof(UniqueId)].Text;
            set => SubItems[nameof(UniqueId)].Text = value;
        }

        public string AppxPackageName
        {
            get => SubItems[nameof(AppxPackageName)].Text;
            set => SubItems[nameof(AppxPackageName)].Text = value;
        }

        public string BasePath
        {
            get => SubItems[nameof(BasePath)].Text;
            set => SubItems[nameof(BasePath)].Text = value;
        }

        protected DistroListViewItem(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        protected override void Serialize(SerializationInfo info, StreamingContext context)
        {
            base.Serialize(info, context);
        }
    }
}
