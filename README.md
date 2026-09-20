[![](https://img.shields.io/github/actions/workflow/status/soenneker/Soenneker.PlanetScale.Runners.OpenApiClient/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/Soenneker.PlanetScale.Runners.OpenApiClient/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/Soenneker.PlanetScale.Runners.OpenApiClient/daily-automatic-update.yml?style=for-the-badge&label=Daily%20Update)](https://github.com/soenneker/Soenneker.PlanetScale.Runners.OpenApiClient/actions/workflows/daily-automatic-update.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.PlanetScale.Runners.OpenApiClient
### A runner that regenerates and updates Soenneker.PlanetScale.OpenApiClient.

This runner executes a GitHub action that updates another project. It's not meant for consumption.

## Local generation

From this repository, with .NET 10 installed:

```powershell
$env:ASPNETCORE_ENVIRONMENT = 'Local'
dotnet run --project src/Soenneker.PlanetScale.Runners.OpenApiClient -- --PlanetScale:LocalDirectory ../soenneker.planetscale.openapiclient
```

The target must already contain the client project under
`src/Soenneker.PlanetScale.OpenApiClient`. The runner replaces generated files in
that source directory, preserves the project file, downloads the specification,
normalizes it, generates the client with Kiota, and builds it in Release mode.
Local generation does not commit, push, or require GitHub credentials.
A failed generation or build produces a nonzero exit code.

`PlanetScale:ClientGenerationUrl` overrides the specification URL, which defaults
to `https://api.planetscale.com/v1/openapi-spec`.

Without `PlanetScale:LocalDirectory`, the runner clones the GitHub client repository
and commits and pushes a successful update. That mode requires `GH__TOKEN`,
`GIT__NAME`, and `GIT__EMAIL`, as configured by the daily workflow.
