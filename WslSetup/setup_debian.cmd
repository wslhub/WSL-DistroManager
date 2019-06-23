@echo off
pushd "%~dp0"

set DistroType=debian
set DistroUrl=https://aka.ms/wsl-debian-gnulinux

echo This script will setup new %DistroType% distro.
set /p DistroName="Enter Distro Alias: "
set /p AccountId="Enter Account ID: "
echo Distro Name: %DistroName%
echo Account Id: %AccountId%

choice /c YN /m "Press Y for continue, N for cancel."
if ERRORLEVEL 2 goto exit

echo Download %DistroType% from Microsoft CDN
curl -L %DistroUrl% -o .\package.zip
powershell -Command Expand-Archive .\package.zip -Force

set DistroDir=%SystemDrive%\Distro\%DistroName%
echo Create distro installation directory at %DistroDir%
if not exist C:\Distro\%DistroName% mkdir %DistroDir%

echo Install distro %DistroName%. This procedure will take long time. Please wait patiently.
wsl --import %DistroName% C:\Distro\%DistroName% .\package\install.tar.gz

echo Add new user and set as a default user
wsl -d %DistroName% -u root -- adduser %AccountId%

echo Discover WSL distro ID
powershell -Command ^$items ^= Get-ChildItem -Path HKCU:\Software\Microsoft\Windows\CurrentVersion\Lxss ^| Get-ItemProperty ^| Where-Object { $_.DistributionName -eq '%DistroName%' }; $items[0].PSChildName.Trim() > package.txt
set /p DistroGuid=<.\package.txt
echo Found WSL distro ID: %DistroGuid%

echo Discover Linux UID
wsl -d %DistroName% -- id -u rkttu > linuxuid.txt
set /p DistroUid=<.\linuxuid.txt
echo Found Linux UID: %DistroUid%

echo Change Default Linux UID
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Lxss\%DistroGuid% /v DefaultUid /t REG_DWORD /d %DistroUid% /f /reg:64

echo Launching installed new distro
start wsl -d %DistroName%

echo Cleaning up temporary directory and files
if exist .\package rd /s /q .\package
if exist .\package.zip del /f /q .\package.zip
if exist .\package.txt del /f /q .\package.txt
if exist .\linuxuid.txt del /f /q .\linuxuid.txt

:exit
popd
@echo on
