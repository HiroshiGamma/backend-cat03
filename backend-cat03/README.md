## Instalación

Antes de comenzar, asegúrate de tener instalado el SDK de .NET 8. Puedes descargar e instalar el SDK desde [aquí](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

Para verificar si tienes instalado el SDK 8, ejecuta el siguiente comando en tu terminal:

```
dotnet --version
```

Si el comando no devuelve la versión 8.x del SDK, sigue las instrucciones de instalación proporcionadas en el enlace.

También asegúrate de tener una cuenta de Cloudinary de antemano.

## Inicio Rápido

1. Clona este repositorio en tu máquina local:

```
git clone https://github.com/HiroshiGamma/backend-cat03.git
```

2. Restaura las dependencias del proyecto:

```
dotnet restore
```

3. Asegúrate de que la base de datos esté operativa:

```
$ dotnet ef database update
```
4. Ejecuta la aplicación:

```
$ dotnet run
```
## Nota

Necesitarás crear un archivo .env y llenar la siguiente información en él para que la API funcione:
DATABASE_URL = Data 'NameOfYourDataBase.db' 
CloudinaryName = 'YourCloudinaryName'
ApiKey = 'YourApiKey'
ApiSecret = 'YourApiSecret'

Puedes crear tu cuenta de Cloudinary [aquí](https://cloudinary.com/users/login) si aún no tienes una.

# backend-catedra03
