@echo off
pushd "%~dp0"

for %%v in (*.exe;*.dll;*.cpl;*.ocx) do "C:\Program Files (x86)\Windows Kits\10\bin\10.0.18362.0\x64\signtool" sign ^
    /n "Jeong Hyun Nam" ^
    /tr http://timestamp.comodoca.com/rfc3161 ^
    "%%v"

%windir%\System32\WindowsPowerShell\v1.0\powershell -Command Get-ChildItem . ^| Where { $_.Name -ne 'Publish.cmd' } ^| Compress-Archive -DestinationPath .\WslManager.zip

%windir%\explorer.exe /select,%~dp0WslManager.zip

:exit
popd
@echo on