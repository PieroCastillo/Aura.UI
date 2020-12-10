var target = Argument("target","Test");
var configuration = Argument("configuration","Release");

// TASKS

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
     {
         CleanDirectory($"./src/Aura.UI/bin/{configuration}");
         CleanDirectory($"./src/Aura.UI.Dragging/bin/{configuration}");
         CleanDirectory($"./Tests/UI.Tests/bin/{configuration}");
    });

Task("Build")
    .IsDependentOn("Clean")
    .Does(() => 
    {
        DotNetCoreBuild("./Aura.UI.sln", new DotNetCoreBuildSettings
        {
            Configuration = configuration,
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => 
    {
            DotNetCoreTest("./Aura.UI.sln", new DotNetCoreTestSettings
            {
                Configuration = configuration,
                NoBuild = true,
            });
    });

// Run

RunTarget(target);