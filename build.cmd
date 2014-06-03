@echo off

"tools\nuget.exe" "install" "FAKE.Core" "-OutputDirectory" "tools" "-ExcludeVersion" "-version" "2.17.8"
"tools\nuget.exe" "install" "roundhouse" "-OutputDirectory" "tools" "-ExcludeVersion" "-version" "0.8.6"

SET TARGET="Debug"
IF NOT [%1]==[] (set TARGET="%1")

SET BUILDMODE="Release"
IF NOT [%2]==[] (set BUILDMODE="%2")

"tools\FAKE.Core\tools\Fake.exe" "build.fsx" "target=%TARGET%" "buildMode=%BUILDMODE%"

