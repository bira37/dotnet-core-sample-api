### .NET Example API

## Objective

The objective of this API was to introduce myself to .NET Core and Entity Framework, using some ideas and organization insights from [this](https://www.youtube.com/watch?v=fmvcAzHpsk8) tutorial video.

## Tools

To make this sample project, I used:

- .NET Core 5 Preview
- ASP.NET Core 5 Preview
- Entity Framework 5 Preview with MS SQL Server

## Setup

To run this sample, you first need to have a local MS SQL Server running, or use the following docker command to run the server inside a container:

```
docker run --name mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=@Test123' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

You can change the password and other settings on _appsettings.json_ file.
