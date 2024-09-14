using Resulver;

namespace Domain.Errors;

public class CustomerNotFoundError() : ResultError("کاربر پیدا نشد.");
public class CustomerWithThisPhoneNumberAlreadyExistsError() : ResultError("این شماره تلفن توسط کاربر دیگری ثبت شده است.");