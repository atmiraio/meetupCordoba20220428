# Meetup de MicUP Córdoba 28 de abril 
## Cómo montar microservicios con Dapr

Se necesita instalar la última versión de Darp Cli

[Primeros pasos con Dapr](https://docs.dapr.io/getting-started/install-dapr-cli/)

Es necesario arrancar Dapr en modo selfhost

```bash
dapr init
```

Hay que instalar Tye Cli 
[Documentación de Tye](https://github.com/dotnet/tye/blob/main/docs/getting_started.md)

```bash
dotnet tool install -g Microsoft.Tye --version "0.11.0-alpha.22111.1"
```

Ejecutar en la carpeta src el siguiente comando:

```bash
tye run
```

Entrar en http://localhost/8000 