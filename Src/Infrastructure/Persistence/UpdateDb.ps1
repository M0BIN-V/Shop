$migrationsPath = "Configs/Migrations"
$contextName = "WriteDbContext"
$dbAddress = ".\SQLSERVER2022"
$dbName = "Shop"

# DONT CHANGE THIS SCRIPTS
$connection = "Data Source = $dbAddress; Initial Catalog = $dbName; Integrated Security=True;Trust Server Certificate=True;"
Remove-Item -Path $migrationsPath -Recurse -Force ; clear;
dotnet ef migrations add --context $contextName Init -o $migrationsPath;clear;
sqlcmd -S .\SQLSERVER2022 -Q "DROP DATABASE Shop";clear;
dotnet ef database update --context $contextName --connection $connection ;
