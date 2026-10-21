# cryptomarketanalysis

Suite .NET de recopilación de datos de criptomonedas e ICOs: seguimiento de Twitter, persistencia SQL, extracción de proyectos ICO y lectura periódica de su impacto en redes sociales.

Documentación basada en los archivos locales revisados el 21 de octubre de 2026.

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
