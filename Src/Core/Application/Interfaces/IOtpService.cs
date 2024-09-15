namespace Application.Interfaces;

public interface IOtpService
{
    public string? GetByKey(string key);
    public Result<string> GenerateAndSave(string key, DateTimeOffset? absoluteExpiration = null);
    public void Deprecate(string key);
}