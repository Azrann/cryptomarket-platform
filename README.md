**Languages:** [English](README.md) · [Español](README.es.md)

# cryptomarket-platform

Analysis, ingestion, and web application for cryptocurrency and ICO information.

<!-- BEGIN project-context -->

## Historical dates and evidence

**Reference year for this version: 2019.** This uses the most recent source or configuration file with a recoverable historical date; the exact creation date could not be confirmed.

- Most recent datable file: **2019-07-14**, [`cryptomarketweb/webapp/Views/Market/Last24hours.cshtml`](cryptomarketweb/webapp/Views/Market/Last24hours.cshtml); date of the commit modifying the file, recovered from local Git history.
- Earliest record among the original Git repositories included: **2018-02-24**. This may be an import and does not establish when the code was first written.
- Most recently published dependency among those checked: [Newtonsoft.Json 11.0.2](https://www.nuget.org/packages/Newtonsoft.Json/11.0.2), published on **2018-03-24** (declared version), in [`cryptomarketanalysis/src/CryptoMarketAnalysis.DataAccess/packages.config`](cryptomarketanalysis/src/CryptoMarketAnalysis.DataAccess/packages.config).
- Additional reference: target `v4.6.1` in [`cryptomarketanalysis/src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj`](cryptomarketanalysis/src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj); its [stable release was published on 2015-11-30](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). This indicates the technology generation; earlier preview releases may have existed.

A dependency's publication places the preserved configuration at or after that version, if the reference is valid. Package updates may be much newer than the project's beginnings. Packages were not restored to verify this.

October 2026 copy timestamps and documents generated during this review were excluded. Recoverable dates do not guarantee that there are no later, undated changes.

Reference years by component (most recent datable file):

| Component | Year |
| --- | --- |
| [`cryptomarketanalysis`](cryptomarketanalysis/) | 2018 |
| [`cryptomarketweb`](cryptomarketweb/) | 2019 |
| [`cryptomarketanalysis.webui2`](cryptomarketanalysis.webui2/) | Undetermined |

## Why this is worth exploring

Follow the ingestion of social activity and ICO data through to presentation in the portal. This complete flow between readers, persistence, and web exploration is the most interesting aspect of the collection.

Code entry points:

- [`cryptomarketanalysis/src/IcoReaderService`](cryptomarketanalysis/src/IcoReaderService/)
- [`cryptomarketweb/webapp/Controllers/IcoController.cs`](cryptomarketweb/webapp/Controllers/IcoController.cs)

<!-- END project-context -->

## Contents

| Directory | Function |
| --- | --- |
| [`cryptomarketanalysis/`](cryptomarketanalysis/) | .NET suite for collecting cryptocurrency and ICO data: Twitter monitoring, SQL persistence, ICO project extraction, and periodic reading of social media impact. |
| [`cryptomarketweb/`](cryptomarketweb/) | ASP.NET MVC cryptocurrency and ICO portal with news, profiles, experts, trends, suggestions, and reports based on social data. |
| [`cryptomarketanalysis.webui2/`](cryptomarketanalysis.webui2/) | An empty folder in the complete copy received; it contains no source code, manifests, or application configuration. |

The downloaded ICO/person image collection is omitted. cryptomarketanalysis.webui2 contained no code.

## Requirements and setup

.NET Framework, ASP.NET MVC/Web API, SQL Server, and NuGet.

This is a historical copy. Consult each component's project files and README for versions and dependencies. Restore NuGet/npm from the appropriate folder; internal libraries may need rebuilding. Prepare databases and external services using your own accounts.

Preserved solutions:

- `cryptomarketweb/CryptoMarketWeb.sln`
- `cryptomarketanalysis/src/CryptoMarketAnalysis.sln`
- `cryptomarketanalysis/src/Test/TwitterStream.sln`

## Configuration and security

Original secrets have been removed or replaced with `REPLACE_WITH_YOUR_VALUE`. Search for this marker before running and provide values through local configuration or environment variables. Sessions, private keys, signing certificates, databases, logs, deployment profiles, and binary packages are not published. The `.gitignore` protects these local files.

A fresh history is published: old commits remain only in the original local copy. Example values cannot connect to the original services.

## Validation status

A static review and secret scan were performed before publication. Applications, trading operations, deployments, and tests contacting external services were not run. Building with current tools is not guaranteed. Some projects need historical dependencies and assets that are not included.

## Licenses and provenance

Third-party licenses and attributions present in the code are retained. No blanket license is added to components that lacked one. This import preserves local sources and does not claim to be a current version of the original project.
