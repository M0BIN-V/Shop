namespace Application.Interfaces;

public interface IOtpService
{
    public string Generate(string key);
    public void Deprecate(string key);
}