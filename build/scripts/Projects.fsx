#I @"../tools/FAKE/tools"
#r @"FakeLib.dll"
open Fake 

type FrameworkName = { MSBuild: string; Nuget: string; }
type ProjectName(msbuild: string) = 
    member this.Nuget = regex_replace @"^.*\\" "" msbuild
    member this.MSBuild = if isMono then this.Nuget else msbuild
    member this.Location = msbuild
    
    member this.NugetDescription = 
        match this.Nuget.ToLowerInvariant() with
        | f when f = "nest.watcher" -> 
            Some "Watcher is a plugin for Elasticsearch that provides alerting and notifications based on changes in your data. This NuGet package extends NEST, allowing you to interface with the Watcher plugin."
        | _ -> 
            None

type DotNetFramework = 
    | NET40 
    | NET45 
    static member All = [
        NET40
        ; NET45
    ] 
    member this.Identifier = 
        match this with
        | NET40 -> { MSBuild = "v4.0"; Nuget = "net40"; }
        | NET45 -> { MSBuild = "v4.5"; Nuget = "net45"; }
    
type DotNet40Project =
    | NestWatcher
    static member All = [NestWatcher] 

type DotNetProject = 
    | DotNet40Project of DotNet40Project
    static member All =
        Seq.concat [
            DotNet40Project.All |> List.map(fun p -> DotNet40Project p);
        ]

    member this.ProjectName =
        match this with
        | DotNet40Project net40 ->
            match net40 with
            | NestWatcher -> ProjectName "Nest.Watcher"
        
    static member TryFindName (name: string) =
        DotNetProject.All
        |> Seq.map(fun p -> p.ProjectName)
        |> Seq.tryFind(fun p -> p.Nuget.ToLowerInvariant() = name.ToLowerInvariant())
