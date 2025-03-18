# hello-dotnet

This is a simple project I created to study the basics of .NET

## Main commands:

* `dotnet build your-project.csproj`
* `dotnet restore your-project.csproj`: Reinstall the project dependencies
* `dotnet add package Organization.PackageName`
* `dotnet tool install --global tool-name`: Installs a tool globaly in your environment
* `dotnet tool update -g package-name`: Updates a global tool
* `dotnet ef migrations add <NameOfMigration>`: Creates a new migration with current models changes
* `dotnet ef database update`: Updates the database according to last migration
* `dotnet ef migrations update <NameOfMigration>`: Rollbacks the database to the selected migration
* `dotnet ef migrations remove`: Removes migrations that are not applied to database
* `dotnet run`
* `dotnet watch run`