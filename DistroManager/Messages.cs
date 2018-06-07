using System.Collections.Generic;

namespace DistroManager
{
    internal static class Messages
    {
        public static readonly int MSG_WSL_REGISTER_DISTRIBUTION_FAILED = 1001;
        public static readonly int MSG_WSL_CONFIGURE_DISTRIBUTION_FAILED = 1002;
        public static readonly int MSG_WSL_LAUNCH_INTERACTIVE_FAILED = 1003;
        public static readonly int MSG_WSL_LAUNCH_FAILED = 1004;
        public static readonly int MSG_USAGE = 1005;
        public static readonly int MSG_STATUS_INSTALLING = 1006;
        public static readonly int MSG_INSTALL_SUCCESS = 1007;
        public static readonly int MSG_ERROR_CODE = 1008;
        public static readonly int MSG_ENTER_USERNAME = 1009;
        public static readonly int MSG_CREATE_USER_PROMPT = 1010;
        public static readonly int MSG_PRESS_A_KEY = 1011;
        public static readonly int MSG_MISSING_OPTIONAL_COMPONENT = 1012;
        public static readonly int MSG_INSTALL_ALREADY_EXISTS = 1013;

        public static readonly IDictionary<int, string> MessageTable_English = new Dictionary<int, string>
        {
            {MSG_WSL_REGISTER_DISTRIBUTION_FAILED, @"WslRegisterDistribution failed with error: 0x{0:X8}"},
            {MSG_WSL_CONFIGURE_DISTRIBUTION_FAILED, @"WslGetDistributionConfiguration failed with error: 0x{0:X8}"},
            {MSG_WSL_LAUNCH_INTERACTIVE_FAILED, @"WslLaunchInteractive {0} failed with error: 0x{1:X8}"},
            {MSG_WSL_LAUNCH_FAILED, @"WslLaunch {0} failed with error: 0x{1:X8}"},
            {MSG_USAGE, @"Launches or configures a Linux distribution.

Usage: 
    <no args> 
        Launches the user's default shell in the user's home directory.

    install [--root]
        Install the distribuiton and do not launch the shell when complete.
          --root
              Do not create a user account and leave the default user set to root.

    run <command line> 
        Run the provided command line in the current working directory. If no
        command line is provided, the default shell is launched.

    config [setting [value]] 
        Configure settings for this distribution.
        Settings:
          --default-user <username>
              Sets the default user to <username>. This must be an existing user.

    help 
        Print usage information."},
            {MSG_STATUS_INSTALLING, @"Installing, this may take a few minutes..."},
            {MSG_INSTALL_SUCCESS, @"Installation successful!"},
            {MSG_ERROR_CODE, @"Error: 0x{0:X8} {1}"},
            {MSG_ENTER_USERNAME, @"Enter new UNIX username: "},
            {MSG_CREATE_USER_PROMPT, @"Please create a default UNIX user account. The username does not need to match your Windows username.
For more information visit: https://aka.ms/wslusers"},
            {MSG_PRESS_A_KEY, @"Press any key to continue..."},
            {MSG_MISSING_OPTIONAL_COMPONENT, @"The Windows Subsystem for Linux optional component is not enabled. Please enable it and try again.
See https://aka.ms/wslinstall for details."},
            {MSG_INSTALL_ALREADY_EXISTS, @"The distribution installation has become corrupted.
Please select Reset from App Settings or uninstall and reinstall the app."},
        };
    }
}
