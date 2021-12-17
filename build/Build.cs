using System;
using System.Linq;
using LibGit2Sharp;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.NerdbankGitVersioning;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main ()
    {
        Environment.SetEnvironmentVariable("NUKE_TELEMETRY_OPTOUT","true");
        return Execute<Build>();
    }
    [Parameter] readonly string Source = "https://api.nuget.org/v3/index.json";
    [Parameter("ApiKey for the specified source")] readonly string NugetApiKey;
    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;
    bool IsCurrentBranchCommitted() => !GitRepository.RetrieveStatus().IsDirty;
    [GitRepositoryExt] LibGit2Sharp.Repository GitRepository;
    NerdbankGitVersioning GitVersion;

    string NugetVersion => IsCurrentBranchCommitted() ? GitVersion.NuGetPackageVersion : $"{GitVersion.SemVer2}-local";

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    protected override void OnBuildInitialized()
    {
        GitVersion = NerdbankGitVersioningTasks.NerdbankGitVersioningGetVersion(s => s
                .DisableProcessLogOutput()
                .SetProcessWorkingDirectory(RootDirectory)
                .SetProject(@"src/NMica.Utils")
                .SetFormat(NerdbankGitVersioningFormat.json))
            .Result;
    }

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Pack => _ => _
        .Executes(() =>
        {
            EnsureCleanDirectory(ArtifactsDirectory);
            DotNetPack(s => s
                .SetProject(Solution)
                .EnableContinuousIntegrationBuild()
                .SetVersion(NugetVersion)
                .SetOutputDirectory(ArtifactsDirectory)
                .SetConfiguration(Configuration));
        });
    Target NugetPush => _ => _
        .Requires(() => NugetApiKey, () => Source)
        .OnlyWhenStatic(() => IsCurrentBranchCommitted())
        .DependsOn(Pack)
        .Executes(() =>
        {
            NuGetTasks.NuGetPush(s => s
                    .SetSource(Source)
                    .SetApiKey(NugetApiKey)
                    .CombineWith(
                        ArtifactsDirectory.GlobFiles("*.nupkg").NotEmpty(), (cs, v) => cs
                            .SetTargetPath(v)),
                degreeOfParallelism: 3,
                completeOnFailure: true);
        });

}
