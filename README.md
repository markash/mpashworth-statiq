# Statiq boilerplate for Kontent

![Build and publish](https://github.com/markash/mpashworth-statiq/workflows/Publish/badge.svg)
[![Live Demo](https://black-pebble-0a0b71810.azurestaticapps.net/)](https://https://black-pebble-0a0b71810.azurestaticapps.net/)

![Screenshot](./screenshot.png)

## Technology
[Statiq](https://statiq.dev/)
[Kontent by Kentico](https://kontent.ai)

## Get started

### Running locally

```bat
dotnet run -- preview
```

Browse <http://localhost:5080>

### Generate typesafe models

```bat
ModelGenerator.bat
````

### Backup and restore content

1. Use the [Template Manager UI](https://kentico.github.io/kontent-template-manager/import) for importing the content from [`kontent-backup.zip`](./kontent-backup.zip) file and API keys from previous step. Check *Publish language variants after import* option before import.

    > Alternatively, you can use the [Kontent Backup Manager](https://github.com/Kentico/kontent-backup-manager-js) and import data to the newly created project from [`content.zip`](./content.zip) file via command line:
    >
    >   ```sh
    >    npm i -g @kentico/kontent-backup-manager
    >
    >    kbm --action=restore --projectId=<Project ID> --apiKey=<Management API key> --zipFilename=content
    >    ```
    >
    > Go to your Kontent project and [publish all the imported items](https://docs.kontent.ai/tutorials/write-and-collaborate/publish-your-work/publish-content-items).


## Features

- [Kontent Model Generator](https://github.com/Kentico/kontent-generators-net) for generating strongly-typed models from Kontent model.
- [Kontent.Statiq](https://www.nuget.org/packages/Kontent.Statiq) module for simple data loading from Kontent to strongly-typed models
- Razor template engine setup with simple layout

## Resources

[Jamstack on .NET - From zero to hero with Statiq and Kontent](https://ondrej.chrastina.tech/journal/jamstack-on-net-from-zero-to-hero-with-statiq-and-kontent)
[Kontent Statiq - Lumen Starter](https://github.com/Kentico/statiq-starter-kontent-lumen)

## Icons

https://icon-icons.com/icon/sheep-animal/33918
