namespace Api.Controllers.Auth;

public record SendOtpRequest(string PhoneNumber);
public record LoginWithOtpRequest(string PhoneNumber, string Otp);