#tool nuget:?package=NUnit.ConsoleRunner&version=3.9.0 
#addin "Cake.FileHelpers"
#addin "Cake.Xamarin&version=3.0.0"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");

var solutionFile = File("../Glasgow123.sln");
var androidProject = File("../Glasgow123.Android/Glasgow123.Android.csproj");
var androidBin = Directory("../Glasgow123.Android/bin") + Directory(configuration);

Task("Clean")
.Does(() =>
{
CleanDirectory(androidBin);
});

Task("Restore-NuGet")
.IsDependentOn("Clean")
.Does(() =>
{
NuGetRestore(solutionFile);
});

Task("Build-Android")
.Does(() =>
{
	MSBuild(androidProject,settings =>
			settings.SetConfiguration(configuration)
			.WithProperty("AndroidSdkDirectory", "~/android/sdk"));
});

Task("Build-tests")
.IsDependentOn("Build-Android")
.Does(() =>
{
var parsedSolution = ParseSolution(solutionFile);

foreach(var project in parsedSolution.Projects)
{
if(project.Name.EndsWith("Tests"))
{
Information("Start Building Test: " + project.Name);
XBuild(project.Path, settings => settings.SetConfiguration(configuration));
}
}
});

Task("Run-unit-tests")
.Does(() =>
{
NUnit3("../**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings {
NoResults = true
});
});

Task("Default")
.IsDependentOn("Run-unit-tests");

RunTarget(target);
