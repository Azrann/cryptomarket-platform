**Languages:** [English](readme.md) · [Español](README.es.md)

# cryptomarketweb

ASP.NET MVC cryptocurrency and ICO portal with news, profiles, experts, trends, suggestions, and reports based on social data.

Documentation based on local files reviewed on 21 October 2026.

<!-- BEGIN project-context -->

## Historical dates and evidence

**Reference year for this version: 2019.** This uses the most recent source or configuration file with a recoverable historical date; the exact creation date could not be confirmed.

- Most recent datable file: **2019-07-14**, [`cryptomarketweb/webapp/Views/Market/Last24hours.cshtml`](webapp/Views/Market/Last24hours.cshtml); date of the commit modifying the file, recovered from local Git history.
- First record in the original Git repository containing this code: **2018-03-09**. This may be an import and does not establish when the code was first written.
- Most recently published dependency among those checked: [NUnit 3.10.1](https://www.nuget.org/packages/NUnit/3.10.1), published on **2018-03-13** (declared version), in [`cryptomarketweb/CryptoMarketWeb.Test/packages.config`](CryptoMarketWeb.Test/packages.config).
- Additional reference: target `v4.6.1` in [`cryptomarketweb/CryptoMarketWeb.Test/CryptoMarketWeb.Test.csproj`](CryptoMarketWeb.Test/CryptoMarketWeb.Test.csproj); its [stable release was published on 2015-11-30](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). This indicates the technology generation; earlier preview releases may have existed.

A dependency's publication places the preserved configuration at or after that version, if the reference is valid. Package updates may be much newer than the project's beginnings. Packages were not restored to verify this.

October 2026 copy timestamps and documents generated during this review were excluded. Recoverable dates do not guarantee that there are no later, undated changes.

## Why this is worth exploring

The portal connects market data to ICO profiles and social activity. Follow how ingestion models and services become exploration pages and views such as those covering the last 24 hours.

Code entry points:

- [`webapp/Controllers/IcoController.cs`](webapp/Controllers/IcoController.cs)
- [`webapp/Views/Market/Last24hours.cshtml`](webapp/Views/Market/Last24hours.cshtml)
- [`webapp/DataAccess`](webapp/DataAccess/)

<!-- END project-context -->

## Structure and responsibilities

| Path | Responsibility |
| --- | --- |
| `webapp/` | Main MVC application and Entity Framework/Dapper data access. |
| `webapp/Controllers/` | Markets, trends, reports, cryptocurrencies, experts, ICOs, accounts, and suggestions. |
| `SimpleFeedReader/` | Reads news from CoinTelegraph. |
| `CryptoMarketWeb.Test/` | NUnit tests for readers and data services. |

## Technologies and requirements

Windows and Visual Studio/MSBuild. Targets .NET Framework 4.6.1, 4.5.2, and 4.0; ASP.NET MVC 5 and SQL Server. Uses Castle Windsor, AutoMapper, and an ICO data client.

Targets read from project files: `v4.0`, `v4.5.2`, `v4.6.1`.

## Setup and startup

Open CryptoMarketWeb.sln, restore NuGet packages, and select webapp for IIS Express. Prepare local databases before testing reports or authentication.

Solutions present: `CryptoMarketWeb.sln`.

## Configuration and integrations

Web.config and test configuration declare DefaultConnection, CryptoMarketDB, CurrencyContextDB, ExpertContextDB, IcoSocialDB, and IcoDB. UserManager also contains a literal password hash, and a publish profile contains private data.

## Status of this copy

cryptomarketanalysis performs related social data processing; the reviewed files do not demonstrate a complete joint deployment. The previous README is retained.

The review was static: dependencies were not restored, and applications and tests were neither built nor run. The commands above are setup instructions, not validation results. Listed versions describe the preserved code.


## Public copy

Original credentials have been removed or replaced with `REPLACE_WITH_YOUR_VALUE`. Local data, sessions, private certificates, and deployment profiles are omitted. Configure your own services and credentials before running. Building and operation with external services have not been validated.
