#r @"./tools/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile
open Fake.RoundhouseHelper
open System

let toolsDir = "tools"
let sourceDir = "./src/"
let buildDir = "./build/"
let packageDir = buildDir + "artifacts"
let slnFile = sourceDir + "Societly.sln"

let setVersion = "0.1"
let version =
    match buildServer with
    | TeamCity -> buildVersion
    | _ -> setVersion + ".0"

// --------------------------------------------------------------------------------------
// Compilation

let mutable buildConfig = "Debug"

Target "NuGetRestore" RestorePackages

Target "Clean" ( fun _ -> 
    CleanDir buildDir
    let buildParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Clean"]
            Properties =["NoLogo", "True"; "Configuration", buildConfig]
        }
    build buildParams slnFile
        |> DoNothing
)

Target "Compile" ( fun _ ->
    let buildParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            Properties =
                [
                    "NoLogo", "True"
                    "Configuration", buildConfig
                    "RunOctoPack", "true"
                    "OctoPackPackageVersion", version
                ]
        }
    build buildParams slnFile
        |> DoNothing
)

// --------------------------------------------------------------------------------------
// Packaging

let webNuspec = "societly.nuspec"

Target "SetReleaseBuild" ( fun _ ->  
    buildConfig <- "Release"
    updateConfigSetting (sourceDir+"/UI/Web.config") "configuration/system.web/compilation" "debug" "false"
)

Target "GenerateAssemblyInfo" (fun _ ->
    let CreateCommonAssemblyFor filename = 
        CreateCSharpAssemblyInfo filename
            [
                Attribute.Title "Societly"
                Attribute.Description "A game with a sweet tagline"
                Attribute.Product "Societly"
                Attribute.Version version
                Attribute.FileVersion version
                Attribute.ComVisible false
                Attribute.Copyright ("Copyright Loud & Abrasive & Co. © " + DateTime.UtcNow.Year.ToString())
             ]

    CreateCommonAssemblyFor "src/Societly/Properties/AssemblyInfo.cs"
    CreateCommonAssemblyFor "src/Societly.UI/Properties/AssemblyInfo.cs"
)

Target "CopyOctoPackages" ( fun _ ->
    CreateDir packageDir
    CopyTo packageDir !! (sourceDir+"/**/bin/*.nupkg")
)

Target "GeneratePackages" DoNothing

// --------------------------------------------------------------------------------------
// Dependencies and Aliases

let Thumbsup = fun _ -> trace "        _\n       / )\n      / /\n_____' (___\n       ((__)\n       ((___)\n       ((__)\n---___((__)\n"

Target "Default" (Thumbsup)
Target "CI" (Thumbsup)

//Compilation
"Clean" ==> "NuGetRestore" ==> "Compile"

//Packaging
"Compile" ==> "CopyOctoPackages"
"CopyOctoPackages" ==> "GeneratePackages"

//Build Server
"SetReleaseBuild" ==> "CI"
"Clean" ==> "CI"
"NuGetRestore" ==> "CI"
"GenerateAssemblyInfo" ==> "CI"
"Compile" ==> "CI"
"GeneratePackages" ==> "CI"

"Compile" ==> "Default"

RunTargetOrDefault "Default"
