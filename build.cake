#tool "nuget:?package=xunit.runners&version=1.9.2"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var artifactsDir = Directory("./artifacts");
var solution = "./Atlas.sln";

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(artifactsDir);
    });

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        NuGetRestore(solution);
    });

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
    {
        MSBuild(solution, settings =>
            settings.SetConfiguration(configuration)
                .WithProperty("TreatWarningsAsErrors", "True")
                .SetVerbosity(Verbosity.Minimal)
                .AddFileLogger());
    });

Task("Run-Tests")
    .IsDependentOn("Build")
    .Does(() =>
    {
        XUnit("./test/**/bin/" + configuration + "/*.Tests.dll");
    });

Task("Package")
    .IsDependentOn("Run-Tests")
    .Does(() =>
    {
        NuGetPack("./src/Atlas/Atlas.csproj", new NuGetPackSettings
        {
            OutputDirectory = artifactsDir,
            Properties = new Dictionary<string, string>
            {
                { "Configuration", configuration }
            }
        });
    });

Task("Default")
    .IsDependentOn("Package");

RunTarget(target);
