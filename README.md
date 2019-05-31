# movie-bomb-net-core
.NET Core Web App to play B.O.M.B.

# Vagrant Extensions
```
vagrant plugin install vagrant-notify-forwarder
```

# Usefull Links

[https://themestr.app/](https://themestr.app/)

# .NET Tools / Packages

From the `MovieBomb` folder.

```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-aspnet-codegenerator
```

# Creating DB Migrations (code first)

From the `MovieBomb` folder.

```
dotnet ef migrations add MigrationName
dotnet ef database update
```

# Launch

From the `MovieBomb` folder.

```
dotnet run
```
