namespace Application.Errors;

public class RateLimitError(TimeSpan remainingTime) :
    ResultError($"لطفا پس از {remainingTime.Minutes} دقیقه و {remainingTime.Seconds} ثانیه دوباره تلاش کنید.");