# cryptomarketweb

Portal ASP.NET MVC de criptomonedas e ICOs con noticias, fichas, expertos, tendencias, sugerencias e informes basados en datos sociales.

Documentación basada en los archivos locales revisados el 21 de octubre de 2026.

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
