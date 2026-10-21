# cryptomarket-platform

Análisis, ingestión y aplicación web de información sobre criptomonedas e ICO.

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
