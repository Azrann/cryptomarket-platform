**Languages:** [English](README.md) · [Español](README.es.md)

# cryptomarketanalysis

.NET suite for collecting cryptocurrency and ICO data: Twitter monitoring, SQL persistence, ICO project extraction, and periodic reading of social media impact.

Documentation based on local files reviewed on 21 October 2026.

<!-- BEGIN project-context -->

## Historical dates and evidence

**Reference year for this version: 2018.** This uses the most recent source or configuration file with a recoverable historical date; the exact creation date could not be confirmed.

- Most recent datable file: **2018-06-06**, [`cryptomarketanalysis/src/IcoHolderScrapper/Program.cs`](src/IcoHolderScrapper/Program.cs); preserved modification timestamp.
- First record in the original Git repository containing this code: **2018-02-24**. This may be an import and does not establish when the code was first written.
- Most recently published dependency among those checked: [Newtonsoft.Json 11.0.2](https://www.nuget.org/packages/Newtonsoft.Json/11.0.2), published on **2018-03-24** (declared version), in [`cryptomarketanalysis/src/CryptoMarketAnalysis.DataAccess/packages.config`](src/CryptoMarketAnalysis.DataAccess/packages.config).
- Additional reference: target `v4.6.1` in [`cryptomarketanalysis/src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj`](src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj); its [stable release was published on 2015-11-30](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). This indicates the technology generation; earlier preview releases may have existed.

A dependency's publication places the preserved configuration at or after that version, if the reference is valid. Package updates may be much newer than the project's beginnings. Packages were not restored to verify this.

October 2026 copy timestamps and documents generated during this review were excluded. Recoverable dates do not guarantee that there are no later, undated changes.

## Why this is worth exploring

Social media readers and scheduled tasks turn scattered information about currencies and ICOs into persisted data. The interesting flow is extraction → normalization → storage, especially the coordination of readers through CronNET.

Code entry points:

- [`src/IcoReaderService`](src/IcoReaderService/)
- [`src/IcoHolderScrapper/Program.cs`](src/IcoHolderScrapper/Program.cs)
- [`src/CryptoMarketAnalysis/TwitterService.cs`](src/CryptoMarketAnalysis/TwitterService.cs)

<!-- END project-context -->

## Structure and responsibilities

| Path | Responsibility |
| --- | --- |
| `src/CryptoMarketAnalysis/Program.cs` | Hosts the process as a Windows service using Topshelf. |
| `src/CryptoMarketAnalysis/TwitterService.cs` | Twitter credentials, search terms, and events for received posts. |
| `src/Test/TwitterStream/` | Additional Twitter, Facebook, and PubNub experiments. |
| `src/CryptoMarketAnalysis/DataAccess/` | Repositories, currencies, tweets, and activity counter procedures. |
| `src/CryptoMarketAnalysis.DataAccess/` | ICO market/social entities and contexts. |
| `src/IcoHolderScrapper/` | Extracts ICO profiles to files and updates the database. |
| `src/IcoReaderService/` | Readers for different networks and recurring CronNET jobs to store social impact. |

## Technologies and requirements

Windows, .NET Framework 4.6.1, Visual Studio/MSBuild, Tweetinvi 2.1, and Topshelf 4. External integrations require your own credentials and API compatibility.

Targets read from project files: `v4.6.1`.

## Setup and startup

Open src/CryptoMarketAnalysis.sln, restore NuGet packages, and build. Review TwitterService before running the executable as a console application or installing it with Topshelf.

Solutions present: `src/CryptoMarketAnalysis.sln`, `src/Test/TwitterStream.sln`.

## Configuration and integrations

TwitterService.cs and the test program contain literal credentials, as well as PubNub keys. Externalize them before connecting the service. IcoHolderScrapper/App.config and IcoReaderService/App.config contain additional SQL connections.

## Status of this copy

The complete copy includes ingestion and persistence in addition to the initial tweet service. Models and services are related to the cryptomarketweb portal. Scraping executables initialize or update data and were not run. The project references CronNET; check the availability of that library and the original packages.

The review was static: dependencies were not restored, and applications and tests were neither built nor run. The commands above are setup instructions, not validation results. Listed versions describe the preserved code.


## Public copy

Original credentials have been removed or replaced with `REPLACE_WITH_YOUR_VALUE`. Local data, sessions, private certificates, and deployment profiles are omitted. Configure your own services and credentials before running. Building and operation with external services have not been validated.
