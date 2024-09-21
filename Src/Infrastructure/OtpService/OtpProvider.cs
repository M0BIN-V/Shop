using Application.Errors;
using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Resulver;
using System.Security.Cryptography;

namespace OtpService;

record OtpRequest(string Otp, DateTime LastRequestDate);

public class OtpProvider : IOtpService
{
    readonly TimeSpan _otpRequestCooldown = TimeSpan.FromMinutes(0.2);
    readonly IMemoryCache _memoryCache;

    public OtpProvider(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Deprecate(string key)
    {
        _memoryCache.Remove(key);
    }

    public Result<string> GenerateAndSave(string key, DateTimeOffset? absoluteExpiration = null)
    {
        if (_memoryCache.TryGetValue<OtpRequest>(key, out var otpRequest))
        {
            //Limit request rate
            var remainingTime = CalculateRemainingTime(otpRequest!.LastRequestDate);
            if (remainingTime > TimeSpan.MinValue)
            {
                return new RateLimitError(remainingTime);
            }

            _memoryCache.Remove(key);
        }

        var otp = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

        _memoryCache.Set(key, new OtpRequest(otp, DateTime.UtcNow), absoluteExpiration ?? DateTimeOffset.UtcNow.AddDays(1));

        return otp;
    }

    public string? GetByKey(string key)
    {
        return _memoryCache.Get<OtpRequest>(key)?.Otp;
    }

    TimeSpan CalculateRemainingTime(DateTime lastRequest)
    {
        TimeSpan timeSinceLastRequest = DateTime.UtcNow - lastRequest;

        if (timeSinceLastRequest < _otpRequestCooldown)
        {
            return _otpRequestCooldown - timeSinceLastRequest;
        }

        return TimeSpan.MinValue;
    }
}
