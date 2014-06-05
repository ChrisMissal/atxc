[<AutoOpen>]
module Fake.DataLoaderHelper

open Fake
open Fake.ProcessHelper
open System

type DataLoaderParams = {
    Delete: bool
    NoLoad: bool
    ToolPath: string
    WorkingDir: string
    TimeOut: TimeSpan }

let DataLoaderDefaults = { 
    Delete = false
    NoLoad = false
    ToolPath = findToolInSubPath "DataLoader.exe" (currentDirectory @@ "tools" @@ "DataLoader")
    WorkingDir = null
    TimeOut = TimeSpan.FromMinutes 5.}

let DataLoader setParams = 
    let parameters = setParams DataLoaderDefaults

    let noload = if parameters.NoLoad then "noload" else ""
    let delete = if parameters.Delete then "delete" else ""

    let args = sprintf "/%s /%s" noload delete

    if 0 <> ExecProcess (fun info ->  
        info.FileName <- parameters.ToolPath
        info.WorkingDirectory <- parameters.WorkingDir
        info.Arguments <- args) parameters.TimeOut
    then
        failwith "DataLoader failed"

