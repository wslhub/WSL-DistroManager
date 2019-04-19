using System;

namespace WslManager
{
    [Serializable]
    public sealed class WslMappedDriveInfo
    {
        public string DriveName { get; set; }
        public string DistroName { get; set; }

        public override string ToString()
        {
            var displayString = DriveName;

            if (!string.IsNullOrWhiteSpace(DistroName))
                displayString = $"{DriveName} ({DistroName})";
            
            return displayString;
        }
    }
}
