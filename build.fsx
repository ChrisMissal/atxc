#r @"tools\FAKE.Core\tools\FakeLib.dll"
#load @"RoundhouseHelper.fs";;
#load @"DataLoaderHelper.fs";;

open Fake 
open Fake.AssemblyInfoFile
open Fake.FixieHelper
open Fake.Git.Information
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

Target "debug" (fun _ ->
    MSBuildDebug buildDir "Build" appReferences
        |> Log "AppBuild-Output: "
)

Target "buildunittests" (fun _ ->
    MSBuildDebug testBuildDir "Build" testReferences
        |> Log "TestBuild-Output: "
)

Target "unittests" (fun _ ->
    !! (testBuildDir @@ "Tests.dll") 
        |> Fixie (fun p -> p)
)

Target "drop" (fun _ ->
    Roundhouse (fun p -> 
        { p with
            Silent = false
            DatabaseName = "atxc"
            Drop = true })
)

Target "migrate" (fun _ ->
    Roundhouse (fun p ->
        { p with
            SqlFilesDirectory = ".\src\Database"
            RepositoryPath = "http://github.com/ChrisMissal/atxc"
            WarnOnOneTimeScriptChanges = true
            DatabaseName = "atxc" })
)

Target "loaddata" (fun _ ->
    DataLoader (fun p -> p)
)

Target "deletedata" (fun _ ->
    DataLoader (fun p ->
        { p with
            Delete = true
            NoLoad = true })
)

Target "clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "assemblyinfo" (fun _ ->
    CreateCSharpAssemblyInfo "src/UI/Properties/AssemblyInfo.cs"
      [ Attribute.Product projectName
        Attribute.Version version
        Attribute.FileVersion version
        Attribute.Copyright copyright
        Attribute.ComVisible false ]
)

Target "default" DoNothing

"clean"
  ==> "debug"
  ==> "default"

"buildunittests"
  ==> "unittests"
  ==> "default"

RunTargetOrDefault "default"
