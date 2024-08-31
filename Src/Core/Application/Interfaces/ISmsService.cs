namespace Application.Interfaces;

public interface ISmsService
{
    public Task SendOtpAsync(PhoneNumber phoneNumber, string otp);
}
