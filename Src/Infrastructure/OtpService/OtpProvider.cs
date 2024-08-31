using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace OtpService;

public class OtpProvider : IOtpService
{
    readonly IMemoryCache _memoryCache;
    readonly Random _random = new();

    public OtpProvider(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Deprecate(string key)
    {
        _memoryCache.Remove(key);
    }

    public string Generate(string key, DateTimeOffset? absoluteExpiration = null)
    {
        if (_memoryCache.TryGetValue<string>(key, out _))
        {
            _memoryCache.Remove(key);
        }

        var otp = _random.Next(100000, 999999).ToString();

        _memoryCache.Set(key, otp, absoluteExpiration ?? DateTimeOffset.Now.AddDays(1));

        return otp;
    }

    public string? GetByKey(string key)
    {
        return _memoryCache.Get<string>(key);
    }
}
