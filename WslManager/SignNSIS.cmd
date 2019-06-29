@echo off
pushd "%~dp0"

"C:\Program Files (x86)\Windows Kits\10\bin\10.0.18362.0\x64\signtool" sign ^
    /n "Jeong Hyun Nam" ^
    /tr http://timestamp.comodoca.com/rfc3161 ^
    WslManagerSetup.exe

:exit
popd
@echo on