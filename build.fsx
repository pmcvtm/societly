#r @"./tools/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile
open System

let buildDir = "./build/"
let toolsDir = "tools"
let sourceDir = "./src/"
let slnFile = "./src/Societly.sln"

let webNuspec = "societly.nuspec"

let projectName = "Societly"
let projectDescription = "A game with a sweet tagline"
let copyright = "Copyright ©" + DateTime.UtcNow.Year.ToString()

let setVersion = "0.1"
let version =
    match buildServer with
    | TeamCity -> buildVersion
    | _ -> setVersion + ".0"

Target "Clean" ( fun _ -> 
    CleanDir buildDir
)

Target "NuGetRestore" RestorePackages

Target "Compile" ( fun _ ->
    trace ""
    MSBuild buildDir "Build" [ "Verbosity","Quiet"; "Configuration","Release" ] [slnFile]
     |> ignore
)

Target "GenerateAssemblyInfo" (fun _ ->
    CreateCSharpAssemblyInfo "src/Societly/Properties/AssemblyInfo.cs"
        [
            Attribute.Title "Societly Core"
            Attribute.Description projectDescription
            Attribute.Product (projectName + " Core")
            Attribute.Version version
            Attribute.FileVersion version
            Attribute.ComVisible false
         ]

    CreateCSharpAssemblyInfo "src/UI/Properties/AssemblyInfo.cs"
        [
            Attribute.Title "Societly UI"
            Attribute.Description projectDescription
            Attribute.Product (projectName + " UI")
            Attribute.Version version
            Attribute.FileVersion version
            Attribute.ComVisible false
        ]
)

Target "PackageWeb" (fun _ ->
    NuGetPack  (fun p -> 
        { p with
            Version = version
            WorkingDir = buildDir
            OutputPath = buildDir
            Publish = false
        }) webNuspec
)

let Thumbsup = fun _ -> trace "        _\n       / )\n      / /\n_____' (___\n       ((__)\n       ((___)\n       ((__)\n---___((__)\n"

Target "Default" (Thumbsup)
Target "CI" (Thumbsup)

"Clean" ==> "NuGetRestore" ==> "Compile"
"Compile" ==> "Default"

"GenerateAssemblyInfo" ==> "CI"
"Compile" ==> "CI"
"PackageWeb" ==> "CI"

RunTargetOrDefault "Default"
