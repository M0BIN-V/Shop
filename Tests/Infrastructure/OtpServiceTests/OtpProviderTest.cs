using Application.Common.Errors;
using Microsoft.Extensions.Caching.Memory;
using OtpService;

namespace OtpServiceTests;

public class OtpProviderTest
{
    readonly OtpProvider _OtpProvider;
    const string _phoneNumber = "09136666666";

    public OtpProviderTest()
    {
        _OtpProvider = new OtpProvider(new MemoryCache(new MemoryCacheOptions()));
    }

    [Fact]
    public void GenerateAndSave_WithConsecutiveRequests_ShouldReturnError()
    {
        _OtpProvider.GenerateAndSave(_phoneNumber);
        var result = _OtpProvider.GenerateAndSave(_phoneNumber);

        result.IsFailure.Should().BeTrue();
        result.Errors[0].GetType().Should().Be(typeof(RateLimitError));
    }

    [Fact]
    public void Deprecate_ShouldRemoveOtp()
    {
        _OtpProvider.GenerateAndSave(_phoneNumber);
        _OtpProvider.Deprecate(_phoneNumber);

        _OtpProvider.GetByKey(_phoneNumber).Should().BeNull();
    }

    [Fact]
    public void GetByKey_WhenOtpExists_ShouldReturnNotNull()
    {
        _OtpProvider.GenerateAndSave(_phoneNumber);

        _OtpProvider.GetByKey(_phoneNumber).Should().NotBeNull();
    }

    [Fact]
    public void GetByKey_WhenOtpNotExists_ShouldReturnNull()
    {
        _OtpProvider.GetByKey(_phoneNumber).Should().BeNull();
    }
}