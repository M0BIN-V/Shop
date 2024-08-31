namespace Application.Interfaces;

public interface IOtpService
{
    public string? GetByKey(string key);
    public string Generate(string key, DateTimeOffset? absoluteExpiration = null);
    public void Deprecate(string key);
}