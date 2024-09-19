param(
    [string] $init,
    [string] $connection,
    [string] $key
)

$api_proj = ".\Src\Peresentation\Api\"
$persistence_proj = ".\Src\Infrastructure\Persistence\"

if ($init) {
    if ([string]::IsNullOrWhiteSpace($connection)) {
        Write-Host "Connection parameter is missing or empty."
    }
    elseif ([string]::IsNullOrWhiteSpace($key)) {
        Write-Host "Key parameter is missing or empty."
    }
    else {
        dotnet user-secrets set "ConnectsionStrings:SqlServer" $connection --project $api_proj
        dotnet user-secrets set "JwtOptions:Key" $key --project $api_proj
        dotnet tool restore
        dotnet ef database update --context WriteDbContext --connection $connection --project $persistence_proj 
    }
}
else {
    dotnet run --project $api_proj
}