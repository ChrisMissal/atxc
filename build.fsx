#r @"tools\FAKE.Core\tools\FakeLib.dll"
open Fake 
open System

let buildDir = "./build"

let appReferences  = !! "src/UI/*.csproj"

Target "Debug" (fun _ ->
    MSBuildDebug buildDir "Build" appReferences
        |> Log "AppBuild-Output: "
)

Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

"Clean"
  ==> "Debug"

RunTargetOrDefault "Debug"
