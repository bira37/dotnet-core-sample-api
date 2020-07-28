# Docker

docker run --name mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=@Test123' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
