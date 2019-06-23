namespace WslManager.Structures
{
    public sealed class MappedDriveQueryResultModel
    {
        public WslMappedDriveInfoCollection AvailableDrives { get; set; }

        public string[] WslDistroList { get; set; }
    }
}
