**Languages:** [English](README.md) · [Español](README.es.md)

# cryptomarketanalysis

Suite .NET de recopilación de datos de criptomonedas e ICOs: seguimiento de Twitter, persistencia SQL, extracción de proyectos ICO y lectura periódica de su impacto en redes sociales.

Documentación basada en los archivos locales revisados el 21 de octubre de 2026.

<!-- BEGIN project-context -->

## Antigüedad y evidencia

**Año de referencia de esta versión: 2018.** Se toma el archivo de código o configuración más reciente con una fecha histórica recuperable; no se ha podido confirmar la fecha exacta de creación.

- Archivo más reciente datable: **2018-06-06**, [`cryptomarketanalysis/src/IcoHolderScrapper/Program.cs`](src/IcoHolderScrapper/Program.cs); fecha de modificación conservada.
- Primer registro del repositorio Git original que contiene este código: **2018-02-24**. Puede corresponder a una importación; no prueba cuándo se escribió por primera vez.
- Dependencia fechada más reciente entre las comprobadas: [Newtonsoft.Json 11.0.2](https://www.nuget.org/packages/Newtonsoft.Json/11.0.2), publicada el **2018-03-24** (versión declarada), en [`cryptomarketanalysis/src/CryptoMarketAnalysis.DataAccess/packages.config`](src/CryptoMarketAnalysis.DataAccess/packages.config).
- Referencia adicional: destino `v4.6.1` en [`cryptomarketanalysis/src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj`](src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj); su [versión estable se publicó el 2015-11-30](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). Es una pista de generación tecnológica; pudieron existir versiones preliminares anteriores.

La publicación de una dependencia sitúa la configuración conservada a partir de esa versión, si la referencia es válida. Una actualización de paquetes puede ser mucho más reciente que el inicio del proyecto. No se restauraron paquetes para comprobarlo.

Se descartaron las marcas de tiempo de la copia de octubre de 2026 y los documentos generados durante esta revisión. Las fechas recuperables no garantizan que no existan cambios posteriores sin datar.

## Por qué merece la pena mirarlo

Los lectores de redes y las tareas periódicas convierten información dispersa sobre monedas e ICO en datos persistidos. La parte interesante es el recorrido extracción → normalización → almacenamiento, especialmente la coordinación de lectores mediante CronNET.

Puntos de entrada al código:

- [`src/IcoReaderService`](src/IcoReaderService/)
- [`src/IcoHolderScrapper/Program.cs`](src/IcoHolderScrapper/Program.cs)
- [`src/CryptoMarketAnalysis/TwitterService.cs`](src/CryptoMarketAnalysis/TwitterService.cs)

<!-- END project-context -->

## Estructura y responsabilidades

| Ruta | Responsabilidad |
| --- | --- |
| `src/CryptoMarketAnalysis/Program.cs` | Alojamiento del proceso como servicio Windows mediante Topshelf. |
| `src/CryptoMarketAnalysis/TwitterService.cs` | Credenciales de Twitter, términos de búsqueda y eventos de publicaciones recibidas. |
| `src/Test/TwitterStream/` | Experimentos adicionales con Twitter, Facebook y PubNub. |
| `src/CryptoMarketAnalysis/DataAccess/` | Repositorios, monedas, tweets y procedimientos para contadores de actividad. |
| `src/CryptoMarketAnalysis.DataAccess/` | Entidades y contextos de mercado/sociales de ICOs. |
| `src/IcoHolderScrapper/` | Extracción de fichas ICO a archivos y actualización de la base de datos. |
| `src/IcoReaderService/` | Lectores de distintas redes y trabajo recurrente con CronNET para guardar impacto social. |

## Tecnologías y requisitos

Windows, .NET Framework 4.6.1, Visual Studio/MSBuild, Tweetinvi 2.1 y Topshelf 4. Las integraciones externas necesitan credenciales propias y compatibilidad con sus APIs.

Destinos leídos de los proyectos: `v4.6.1`.

## Preparación y arranque

Abrir src/CryptoMarketAnalysis.sln, restaurar NuGet y compilar. Revisar TwitterService antes de ejecutar el binario como consola o instalarlo mediante Topshelf.

Soluciones presentes: `src/CryptoMarketAnalysis.sln`, `src/Test/TwitterStream.sln`.

## Configuración e integraciones

Hay credenciales literales en TwitterService.cs y en el programa de prueba, además de claves PubNub. Externalizarlas antes de conectar el servicio. IcoHolderScrapper/App.config e IcoReaderService/App.config contienen conexiones SQL adicionales.

## Estado de esta copia

La copia completa incluye ingesta y persistencia además del primer servicio de tweets. Los modelos y servicios guardan relación con el portal cryptomarketweb. Los ejecutables de scraping inicializan o actualizan datos y no se ejecutaron. El proyecto referencia CronNET; revisar la disponibilidad de esa biblioteca y los paquetes originales.

La revisión fue estática: no se restauraron dependencias, no se compiló ni se ejecutaron aplicaciones o pruebas. Los comandos anteriores son instrucciones de preparación, no resultados de validación. Las versiones indicadas son las del código conservado.


## Copia pública

Las credenciales originales se han retirado o sustituido por `REPLACE_WITH_YOUR_VALUE`. Los datos locales, sesiones, certificados privados y perfiles de despliegue se omiten. Configurar servicios y credenciales propios antes de ejecutar. La compilación y el funcionamiento con servicios externos no se han validado.
