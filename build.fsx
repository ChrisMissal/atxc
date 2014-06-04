#r @"tools\FAKE.Core\tools\FakeLib.dll"
#load @"RoundhouseHelper.fs";;

open Fake 
open Fake.AssemblyInfoFile
open Fake.FixieHelper
open System

let projectName = "ATX Creatives"
let projectDescription = "Austin's best, brightest and most creative people"
let projectSummary = "www.atxcreatives.com"
let version = "0.0.0"
let copyright = "Copyright © 2013 - " + DateTime.UtcNow.Year.ToString()

let rh = "./tools/roundhouse/rh.exe"
let buildDir = "./publish/build"
let testBuildDir = "./publish/test"

let appReferences  = !! "src/UI/*.csproj"
let testReferences = !! "src/Tests/*.csproj"

Target "Debug" (fun _ ->
    MSBuildDebug buildDir "Build" appReferences
        |> Log "AppBuild-Output: "
)

Target "BuildUnitTests" (fun _ ->
    MSBuildDebug testBuildDir "Build" testReferences
        |> Log "TestBuild-Output: "
)

Target "UnitTests" (fun _ ->
    !! (testBuildDir @@ "Tests.dll") 
        |> Fixie (fun p -> p)
)

Target "MigrateDb" (fun _ ->
    Roundhouse (fun p -> { p with 
        SqlFilesDirectory = ".\database"
        DatabaseName = "atxc" })
)

Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "AssemblyInfo" (fun _ ->
    CreateCSharpAssemblyInfo "src/UI/Properties/AssemblyInfo.cs"
      [ Attribute.Product projectName
        Attribute.Version version
        Attribute.FileVersion version
        Attribute.Copyright copyright
        Attribute.ComVisible false ]
)

Target "Default" DoNothing

"MigrateDb"
  ==> "Default"

"Clean"
  ==> "Debug"
  ==> "Default"

"BuildUnitTests"
  ==> "UnitTests"
  ==> "Default"

RunTargetOrDefault "Default"
