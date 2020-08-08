#addin nuget:?package=SharpZipLib
#addin nuget:?package=Cake.Compression

#tool "nuget:?package=gitreleasemanager"

enum OperatingSystem 
{
    Windows,
    MacOS,
    Linux
}

// script arguments and constants
const string APP_NAME = "Aura_UI";
var BUILD_NUMBER = EnvironmentVariable("GITHUB_RUN_NUMBER", "1");
var VERSION_PREFIX = Argument("VersionPrefix", "0.0.0");

// public variables
string _versionString = string.Empty;
bool _isGithubActionsBuild;
ConvertableDirectoryPath _sourceDirectory, _buildDirectory, _outputDirectory;
OperatingSystem _operatingSystem;

string GetPath(ConvertableDirectoryPath path)
{
    return MakeAbsolute(path).FullPath;
}

Setup(context => 
{
    _versionString = string.Format("{0}.{1}", VERSION_PREFIX, BUILD_NUMBER);
    _isGithubActionsBuild = GitHubActions.IsRunningOnGitHubActions;

    var platform = Context.Environment.OSVersion.Platform;
    switch (platform)
    {
        case PlatformFamily.Linux:
            _operatingSystem = OperatingSystem.Linux;
            break;

        case PlatformFamily.OSX:
            _operatingSystem = OperatingSystem.MacOS;
            break;

        default:
            _operatingSystem = OperatingSystem.Windows;
            break;
    }
    
    _sourceDirectory = Directory("../*");
    _buildDirectory = Directory("../build");
    _outputDirectory = Directory("../publish");
});

Teardown(context => 
{

});

Task("BuildInitialization")
    .Does(() => 
{
    Information($"Build is running on {_operatingSystem} operating system{(_isGithubActionsBuild ? " using Github Actions infrastructure" : string.Empty)}.");
    Information($"Source Directory: {GetPath(_sourceDirectory)}");
    Information($"Build Directory: {GetPath(_buildDirectory)}");
    Information($"Version: {_versionString}");

    Information($"Clean up any existing output in directory '{GetPath(_outputDirectory)}'.");
    CleanDirectories(_outputDirectory);
});

Task("BuildWindows64")
    .WithCriteria(() => _operatingSystem == OperatingSystem.Windows)
    .IsDependentOn("BuildInitialization")
    .Does(() => 
{
    var outputDirectory = _outputDirectory + Directory("windows");

    Information("Build for Windows (64-bit).");
    var settings = new DotNetCorePublishSettings
    {
        Framework = "netstandard2.0",
        Configuration = "Release",
        SelfContained = true,
        Runtime = "win-x64",
        OutputDirectory = GetPath(outputDirectory)
    };
    DotNetCorePublish(GetPath(_sourceDirectory), settings);

    Information("Create portable ZIP archive from the build.");
    Zip(outputDirectory, _outputDirectory + File("windows_portable.zip"));

    Information("Create installation setup.");
    var setupSettings = new InnoSetupSettings
    {
        OutputDirectory = _outputDirectory,
        EnableOutput = true,
        Defines = new Dictionary<string, string> 
        {
            { "APP_NAME", APP_NAME },
            { "APP_VERSION", _versionString },
            { "APP_ROOT", GetPath(Directory("../")) }
        }
    };
    InnoSetup(_buildDirectory + File("setup.iss"), setupSettings);
});

Task("BuildMacOS64")
    .WithCriteria(() => _operatingSystem == OperatingSystem.MacOS)
    .IsDependentOn("BuildInitialization")
    .Does(() => 
{
    var outputDirectory = _outputDirectory + Directory("osx");

    Information("Build for MacOS (64-bit).");
    var settings = new DotNetCorePublishSettings
    {
        Framework = "netstandard2.0",
        Configuration = "Release",
        SelfContained = true,
        Runtime = "osx-x64",
        OutputDirectory = GetPath(outputDirectory)
    };
    DotNetCorePublish(GetPath(_sourceDirectory), settings);

    Information("Create portable ZIP archive from the build.");
    Zip(outputDirectory, _outputDirectory + File("osx_portable.zip"));

    Information("Create MacOS application bundle.");
    CopyDirectory(_buildDirectory + Directory("aura.ui"), _outputDirectory + Directory("aura.ui"));
    CopyDirectory(outputDirectory, _outputDirectory + Directory("aura.ui/Contents/MacOS"));
    Zip(_outputDirectory + Directory("aura.ui/Contents/MacOS"), _outputDirectory + File("osx_app.zip"));
});

Task("BuildLinux64")
    .WithCriteria(() => _operatingSystem == OperatingSystem.Linux)
    .IsDependentOn("BuildInitialization")
    .Does(() => 
{
    var outputDirectory = _outputDirectory + Directory("osx");

    Information("Build for Linux (64-bit).");
    var settings = new DotNetCorePublishSettings
    {
        Framework = "netstandard2.0",
        Configuration = "Release",
        SelfContained = true,
        Runtime = "linux-x64",
        OutputDirectory = GetPath(outputDirectory)
    };
    DotNetCorePublish(GetPath(_sourceDirectory), settings);

    Information("Create portable ZIP archive from the build.");
    Zip(outputDirectory, _outputDirectory + File("linux_portable.zip"));
});

Task("Deploy")
    .IsDependentOn("BuildWindows64")
    .IsDependentOn("BuildMacOS64")
    .IsDependentOn("BuildLinux64")
    .Does(() => 
{

});

RunTarget("Deploy");