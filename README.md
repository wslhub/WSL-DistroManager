# WSL Manager

You can download and use WSL Manager by selecting one of the links below.

- [Installer](https://github.com/rkttu/WSL-DistroManager/releases/latest/download/WslManagerSetup.exe)
- [Xcopy Friendly](https://github.com/rkttu/WSL-DistroManager/releases/latest/download/WslManager.zip)

![Example](Assets/Images/Screenshot-hyper.png)

**WSL Manager** is a highly customizable Windows Subsystem for Linux distro manager for Windows 10 (at least 19H1) and Windows Server 19H1 (or later).

This program helps you install and manage multiple versions of the same Linux distribution on the Windows Subsystem for Linux. This program is currently under development and may take some time to complete its first function.

## Features

Latest features introduced at [here](https://wslman.rkttu.com/)

* Install official linux distros directly with -or- without using Microsoft Store.
* Run your linux distro easily with GUI based interface.
* Open/mount your linux distro directly without running each distro instance.
* Import your own system tarball archive to Windows Subsystem for Linux.
* Export/Backup your existing distro to tarball archive file.
* Review detailed distro properties (such as distro total size, registry keys)
* Create a desktop shortcut which runs distro with wsl.exe and decorated with custom icon.
* Initialize new distro with custom user account.
* Open WSL configuration file (wsl.conf) with notepad. (Notepad in 19H1 supports/honors unix EOL)

## Planned features/enhancements

* Enhance simple WSL shim to full features WSL Distro Launcher (based on https://github.com/Microsoft/WSL-DistroLauncher)
* Issue a command or script into distro directly.
* Set default distro for wsl.exe and bash.exe.
* Run distro as a specific user.
* Add new user into distro.
* Migrate to .NET Core 3.0 Windows Forms Project

## Distro manager as a Service

Thanks to the import and export capabilities of WSL, you can now exchange tarball archive files. I'm considering creating a gallery service that will allow you to register and exchange the WSL system itself in the future.

## License

This project follows the MIT license.

## Thanks to

- App Icons: https://www.icons8.com
- Imaging Helper: https://gist.github.com/darkfall/1656050
- WMI Event Query/Monitoring: https://stackoverflow.com/questions/826971/registry-watcher-c-sharp
- Project temporary logo: https://pixabay.com/vectors/monitor-informatics-windows-2108894/
