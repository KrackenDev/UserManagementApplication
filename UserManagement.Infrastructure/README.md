## Getting Started

### Infrastructure Project
* This project runs on .NET 5 SDK.
* The infrastructure project relies on a SQLServer database. The connection string is stored in the appsettings.json of UserManagement.Api.
    * This connection string for now can be pointed to a local SQLServer instance.
* Utilizing Entity Framework Core, the database can be created by running the following command in the UserManagement.Infrastructure project directory:
    * `dotnet ef migrations add InitialCreate -p .\UserManagement.Infrastructure.csproj -s ..\UserManagement.Api\UserManagement.Api.csproj`
    * `dotnet ef database update -p .\UserManagement.Infrastructure.csproj -s ..\UserManagement.Api\UserManagement.Api.csproj`
    * Please note that both Microsoft.EntityFrameworkCore.Design and Microsoft.EntityFrameworkCore.Tools is required to run these commands. These tools can be installed through NuGet.
    * Version 5.0.17 is the version that was used for this project.
    * dotnet-ef must also be installed.
       * `dotnet tool install --global dotnet-ef --version 5.0.17`