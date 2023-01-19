# Maui Blazor (Hybrid) app with a shared Blazor Webassembly Web App

## Solution Layout

* Client.Core - All meaningful UI code goes here. Shared between Maui and Web site. Includes `wwwroot` and all razor controls. 
* Client.Maui - Builds native UIs for iOS, Android, Windows, Mac. `wwwroot` only for `index.html`, everything referenced via Core. 
* Client.Web - web site that hosts Blazor WebAssembly. Same `wwwroot` caveat as Maui.
* Server.API - .NET 6 in-process Azure Function.  
* Common - Minimal class library for data transfer objects and business logic that is shared between client & server; targets .NET 6 and 7. 

[Helpful writeup from Telerik](https://www.telerik.com/blogs/sharing-code-blazor-dotnet-maui)

!(Solution Layout)[/SolutionLayout.svg]

## Build

Requirements
* .NET 7 for the frontend 
* .NET 6 for the Azure Function Server.API
* Android Studio & Android v33
* A Mac for iOS & MacOS builds

You can build everything but Apple stuff with the two Dockerfiles in root...but this is just a starting point for CI, you can't launch the solution. 

```
docker build -t mauibuild - < Dockerfile-mauibuild
docker build .
```

Client.Maui.csproj. Note the conditional builds depending on OS.
```
    <PropertyGroup>
        <TargetFrameworks>net7.0-android</TargetFrameworks>
        <TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net7.0-windows10.0.19041.0</TargetFrameworks>
        <TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('freebsd'))">$(TargetFrameworks);net7.0-ios;net7.0-maccatalyst</TargetFrameworks>
```

## See Also

* https://www.telerik.com/blogs/sharing-code-blazor-dotnet-maui - This helped me get the fiddly bits working, but I prefer my naming conventions. 

## TODO

* The frontend doesn't actually call the backend, so I don't know if the Common project is necessary, or if repeating contract classes is easier with codegen. 