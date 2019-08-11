# WSL Manager

You can download and use WSL Manager by selecting one of the links below.

- [Installer](https://github.com/rkttu/WSL-DistroManager/releases/latest/download/WslManagerSetup.exe)

You can access or contribute to the source code of this project from the GitHub repository: [https://github.com/rkttu/WSL-DistroManager](https://github.com/rkttu/WSL-DistroManager)

<a target="_blank" href="Assets/Images/Screenshot3.png">
	<img src="Assets/Images/Screenshot3.png" alt="Distro Gallery" style="width: 40%;" />
</a>
<a target="_blank" href="Assets/Images/Screenshot1.png">
	<img src="Assets/Images/Screenshot1.png" alt="Basic Feature" style="width: 40%;" />
</a>
<a target="_blank" href="Assets/Images/Screenshot2.png">
	<img src="Assets/Images/Screenshot2.png" alt="Integrate with Hyper" style="width: 40%;" />
</a>

**WSL Manager** is a highly customizable Windows Subsystem for Linux distro manager for Windows 10 (at least 19H1) and Windows Server 19H1 (or later).

This program helps you install and manage multiple versions of the same Linux distribution on the Windows Subsystem for Linux. This program is currently under development and may take some time to complete its first function.

Good news! This project was introduced in **BetaPage**!

## Features

Latest features introduced at [here](https://www.wslhub.com/)

* Install official linux distros directly with -or- without using Microsoft Store.
* Run your linux distro easily with GUI based interface.
* Open/mount your linux distro directly without running each distro instance.
* Import your own system tarball archive to Windows Subsystem for Linux.
* Export/Backup your existing distro to tarball archive file.
* Review detailed distro properties (such as distro total size, registry keys)
* Create a desktop shortcut which runs distro with wsl.exe and decorated with custom icon.
* Initialize new distro with custom user account.

## Planned features/enhancements

* Enhance simple WSL shim to full features WSL Distro Launcher (based on https://github.com/Microsoft/WSL-DistroLauncher)
* Issue a command or script into distro directly.
* Set default distro for wsl.exe and bash.exe.
* Run distro as a specific user.
* Add new user into distro.
* Migrate to .NET Core 3.0 Windows Forms Project

## FAQ

### The functionality of this tool is already provided by wsl.exe. Why should I use this tool?

This tool is designed to enable the use of WSL functionality in a GUI manner. Of course, it is useful to call wsl.exe directly if you are familiar with using the command line.

However, if you use this tool, you will get additional convenience features that can not be solved by wsl.exe alone.

## Distro manager as a Service

Thanks to the import and export capabilities of WSL, you can now exchange tarball archive files. I'm considering creating a gallery service that will allow you to register and exchange the WSL system itself in the future.

## License

This project follows the MIT license.

This project uses WslQuery project, which follows GPL v3 license. But this project does not link the WslQuery utility direct.

## Thanks to

- App Icons: https://www.icons8.com
- Imaging Helper: https://gist.github.com/darkfall/1656050
- WMI Event Query/Monitoring: https://stackoverflow.com/questions/826971/registry-watcher-c-sharp
- Project temporary logo: https://pixabay.com/vectors/monitor-informatics-windows-2108894/
