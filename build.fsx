#r @"tools\FAKE.Core\tools\FakeLib.dll"
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
let testDir = "./"

let appReferences  = !! "src/UI/*.csproj"
let testReferences = !! "src/Tests/*.csproj"

Target "Debug" (fun _ ->
    MSBuildDebug buildDir "Build" appReferences
        |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
    MSBuildDebug testBuildDir "Build" testReferences
        |> Log "TestBuild-Output: "
)

Target "Test" (fun _ ->
    !! (testBuildDir @@ "Tests.dll") 
        |> Fixie (fun p -> p)
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

"Clean"
  ==> "Debug"

"BuildTest"
  ==> "Test"

RunTargetOrDefault "Clean"
