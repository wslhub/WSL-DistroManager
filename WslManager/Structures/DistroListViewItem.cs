using Microsoft.Win32;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace WslManager.Structures
{
    public class DistroListViewItem : ListViewItem
    {
        public DistroListViewItem(RegistryKey key)
            : base(SharedRoutines.GetDistroProperties(key), SharedRoutines.GetImageKey(key))
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

        public override string ToString()
        {
            return DistroName;
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
