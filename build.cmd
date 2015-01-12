@echo off
echo Build Started
echo.
call .\src\.nuget\nuget.exe install "FAKE" -source "https://nuget.org/api/v2/" -RequireConsent -o "tools" -ExcludeVersion
echo.
call "tools\FAKE\tools\Fake.exe" build.fsx %*
echo.
