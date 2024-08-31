using Application.Interfaces;
using Domain.ValueObjects;

namespace SmsService;

public class SmsServiceProvider : ISmsService
{
    public Task SendOtpAsync(PhoneNumber phoneNumber, string otp)
    {
        //TODO Connect to sms panel

        Console.WriteLine($"{phoneNumber.Value} OTP : {otp}");
        return Task.CompletedTask;
    }
}
