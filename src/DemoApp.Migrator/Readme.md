# Migrator

The migrator console app is used to contain and apply migrations against the PostgreSQL database.

## Adding migrations

In order to add the migration from the commandline, ensure that the package:
`Microsoft.EntityFramework.Core.Tools.DotNet` is installed.

In case of any **dotnet-ef** CLI errors, please ensure that the following XML fragment is present within the `DemoApp.Migrator.csproj`

```
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
</ItemGroup> `
```

Adding the migration can be performed using the following command:

`dotnet ef migrations add {migration-name} --context Context --project ./DemoApp.Migrator.csproj`

It is important to include the `--project` argument, as the Migrations assembly  differes from the assembly containing the context.

## Applying migrations

Applying the migrations to the database, can be performed using the following command:

`dotnet ef database update`