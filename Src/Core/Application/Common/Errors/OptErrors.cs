namespace Application.Common.Errors;

public class RateLimitError : ResultError
{
    public RateLimitError(TimeSpan remainingTime) : base($"لطفا پس از {remainingTime.Minutes} دقیقه و {remainingTime.Seconds} ثانیه دوباره تلاش کنید.")
    {
        Remaining = $"{remainingTime.Minutes}:{remainingTime.Seconds}";
    }
    public string Remaining { get; set; }
}

public class OtpIsNotValidError() : ResultError("رمز یکبار مصرف یا شماره تلفن صحیح نمیباشد.");