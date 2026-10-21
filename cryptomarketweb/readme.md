# cryptomarketweb

Portal ASP.NET MVC de criptomonedas e ICOs con noticias, fichas, expertos, tendencias, sugerencias e informes basados en datos sociales.

Documentación basada en los archivos locales revisados el 21 de octubre de 2026.

<!-- BEGIN project-context -->

## Antigüedad y evidencia

**Año de referencia de esta versión: 2019.** Se toma el archivo de código o configuración más reciente con una fecha histórica recuperable; no se ha podido confirmar la fecha exacta de creación.

- Archivo más reciente datable: **2019-07-14**, [`cryptomarketweb/webapp/Views/Market/Last24hours.cshtml`](webapp/Views/Market/Last24hours.cshtml); fecha del commit que modificó el archivo, recuperada del Git local.
- Primer registro del repositorio Git original que contiene este código: **2018-03-09**. Puede corresponder a una importación; no prueba cuándo se escribió por primera vez.
- Dependencia fechada más reciente entre las comprobadas: [NUnit 3.10.1](https://www.nuget.org/packages/NUnit/3.10.1), publicada el **2018-03-13** (versión declarada), en [`cryptomarketweb/CryptoMarketWeb.Test/packages.config`](CryptoMarketWeb.Test/packages.config).
- Referencia adicional: destino `v4.6.1` en [`cryptomarketweb/CryptoMarketWeb.Test/CryptoMarketWeb.Test.csproj`](CryptoMarketWeb.Test/CryptoMarketWeb.Test.csproj); su [versión estable se publicó el 2015-11-30](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). Es una pista de generación tecnológica; pudieron existir versiones preliminares anteriores.

La publicación de una dependencia sitúa la configuración conservada a partir de esa versión, si la referencia es válida. Una actualización de paquetes puede ser mucho más reciente que el inicio del proyecto. No se restauraron paquetes para comprobarlo.

Se descartaron las marcas de tiempo de la copia de octubre de 2026 y los documentos generados durante esta revisión. Las fechas recuperables no garantizan que no existan cambios posteriores sin datar.

## Por qué merece la pena mirarlo

El portal conecta datos de mercado con fichas de ICO y actividad social. Es interesante seguir cómo los modelos y servicios de ingesta terminan convertidos en páginas de exploración y vistas como las de las últimas 24 horas.

Puntos de entrada al código:

- [`webapp/Controllers/IcoController.cs`](webapp/Controllers/IcoController.cs)
- [`webapp/Views/Market/Last24hours.cshtml`](webapp/Views/Market/Last24hours.cshtml)
- [`webapp/DataAccess`](webapp/DataAccess/)

<!-- END project-context -->

## Estructura y responsabilidades

| Ruta | Responsabilidad |
| --- | --- |
| `webapp/` | Aplicación MVC principal y acceso a datos con Entity Framework/Dapper. |
| `webapp/Controllers/` | Mercado, tendencias, informes, criptomonedas, expertos, ICOs, cuentas y sugerencias. |
| `SimpleFeedReader/` | Lectura de noticias de CoinTelegraph. |
| `CryptoMarketWeb.Test/` | Pruebas NUnit de lectores y servicios de datos. |

## Tecnologías y requisitos

Windows y Visual Studio/MSBuild. Destinos .NET Framework 4.6.1, 4.5.2 y 4.0; ASP.NET MVC 5 y SQL Server. Se usan Castle Windsor, AutoMapper y un cliente de datos ICO.

Destinos leídos de los proyectos: `v4.0`, `v4.5.2`, `v4.6.1`.

## Preparación y arranque

Abrir CryptoMarketWeb.sln, restaurar NuGet y seleccionar webapp para IIS Express. Preparar bases locales antes de probar informes o autenticación.

Soluciones presentes: `CryptoMarketWeb.sln`.

## Configuración e integraciones

Web.config y la configuración de pruebas declaran DefaultConnection, CryptoMarketDB, CurrencyContextDB, ExpertContextDB, IcoSocialDB e IcoDB. También hay un hash de contraseña literal en UserManager y datos privados en un perfil de publicación.

## Estado de esta copia

cryptomarketanalysis realiza otro trabajo relacionado con datos sociales; los archivos revisados no demuestran un despliegue conjunto completo. Se conservó el README anterior.

La revisión fue estática: no se restauraron dependencias, no se compiló ni se ejecutaron aplicaciones o pruebas. Los comandos anteriores son instrucciones de preparación, no resultados de validación. Las versiones indicadas son las del código conservado.


## Copia pública

Las credenciales originales se han retirado o sustituido por `REPLACE_WITH_YOUR_VALUE`. Los datos locales, sesiones, certificados privados y perfiles de despliegue se omiten. Configurar servicios y credenciales propios antes de ejecutar. La compilación y el funcionamiento con servicios externos no se han validado.
