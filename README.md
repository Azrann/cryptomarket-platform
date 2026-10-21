# cryptomarket-platform

Análisis, ingestión y aplicación web de información sobre criptomonedas e ICO.

<!-- BEGIN project-context -->

## Antigüedad y evidencia

**Año de referencia de esta versión: 2019.** Se toma el archivo de código o configuración más reciente con una fecha histórica recuperable; no se ha podido confirmar la fecha exacta de creación.

- Archivo más reciente datable: **2019-07-14**, [`cryptomarketweb/webapp/Views/Market/Last24hours.cshtml`](cryptomarketweb/webapp/Views/Market/Last24hours.cshtml); fecha del commit que modificó el archivo, recuperada del Git local.
- Primer registro entre los repositorios Git originales incluidos: **2018-02-24**. Puede corresponder a una importación; no prueba cuándo se escribió por primera vez.
- Dependencia fechada más reciente entre las comprobadas: [Newtonsoft.Json 11.0.2](https://www.nuget.org/packages/Newtonsoft.Json/11.0.2), publicada el **2018-03-24** (versión declarada), en [`cryptomarketanalysis/src/CryptoMarketAnalysis.DataAccess/packages.config`](cryptomarketanalysis/src/CryptoMarketAnalysis.DataAccess/packages.config).
- Referencia adicional: destino `v4.6.1` en [`cryptomarketanalysis/src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj`](cryptomarketanalysis/src/CryptoMarketAnalysis/CryptoMarketAnalysis.csproj); su [versión estable se publicó el 2015-11-30](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). Es una pista de generación tecnológica; pudieron existir versiones preliminares anteriores.

La publicación de una dependencia sitúa la configuración conservada a partir de esa versión, si la referencia es válida. Una actualización de paquetes puede ser mucho más reciente que el inicio del proyecto. No se restauraron paquetes para comprobarlo.

Se descartaron las marcas de tiempo de la copia de octubre de 2026 y los documentos generados durante esta revisión. Las fechas recuperables no garantizan que no existan cambios posteriores sin datar.

Años de referencia por componente (archivo más reciente datable):

| Componente | Año |
| --- | --- |
| [`cryptomarketanalysis`](cryptomarketanalysis/) | 2018 |
| [`cryptomarketweb`](cryptomarketweb/) | 2019 |
| [`cryptomarketanalysis.webui2`](cryptomarketanalysis.webui2/) | Sin determinar |

## Por qué merece la pena mirarlo

La ingesta de actividad social y datos de ICO se puede seguir hasta su representación en el portal. Ese recorrido completo entre lectores, persistencia y exploración web es el aspecto más interesante del conjunto.

Puntos de entrada al código:

- [`cryptomarketanalysis/src/IcoReaderService`](cryptomarketanalysis/src/IcoReaderService/)
- [`cryptomarketweb/webapp/Controllers/IcoController.cs`](cryptomarketweb/webapp/Controllers/IcoController.cs)

<!-- END project-context -->

## Contenido

| Directorio | Función |
| --- | --- |
| [`cryptomarketanalysis/`](cryptomarketanalysis/) | Suite .NET de recopilación de datos de criptomonedas e ICOs: seguimiento de Twitter, persistencia SQL, extracción de proyectos ICO y lectura periódica de su impacto en redes sociales. |
| [`cryptomarketweb/`](cryptomarketweb/) | Portal ASP.NET MVC de criptomonedas e ICOs con noticias, fichas, expertos, tendencias, sugerencias e informes basados en datos sociales. |
| [`cryptomarketanalysis.webui2/`](cryptomarketanalysis.webui2/) | Carpeta vacía en la copia completa recibida; no contiene código, manifiestos ni configuración de aplicación. |

La colección descargada de imágenes de ICO/personas se ha omitido. cryptomarketanalysis.webui2 no contenía código.

## Requisitos y preparación

.NET Framework, ASP.NET MVC/Web API, SQL Server y NuGet.

Esta es una copia histórica. Consultar los archivos de proyecto y los README de cada componente para sus versiones y dependencias. Restaurar NuGet/npm desde la carpeta correspondiente; las bibliotecas internas pueden necesitar reconstrucción. Preparar las bases de datos y los servicios externos con cuentas propias.

Soluciones conservadas:

- `cryptomarketweb/CryptoMarketWeb.sln`
- `cryptomarketanalysis/src/CryptoMarketAnalysis.sln`
- `cryptomarketanalysis/src/Test/TwitterStream.sln`

## Configuración y seguridad

Los secretos originales se han eliminado o sustituido por `REPLACE_WITH_YOUR_VALUE`. Buscar este marcador antes de ejecutar y aportar los valores mediante configuración local o variables de entorno. Las sesiones, claves privadas, certificados de firma, bases de datos, registros, perfiles de despliegue y paquetes binarios no se publican. El `.gitignore` protege estos archivos locales.

Se publica un historial nuevo: los commits antiguos permanecen únicamente en la copia local original. Los valores de ejemplo no permiten conectarse a los servicios originales.

## Estado de validación

Se realizó una revisión estática y un escaneo de secretos antes de publicar. No se ejecutaron aplicaciones, operaciones de trading, despliegues ni pruebas que contacten servicios externos. No se garantiza la compilación con herramientas actuales. Algunos proyectos necesitan dependencias históricas y activos que no están incluidos.

## Licencias y procedencia

Se conservan las licencias y atribuciones de terceros presentes en el código. No se añade una licencia global a los componentes que no la tenían. Esta importación conserva fuentes locales y no afirma ser una versión actual del proyecto original.
