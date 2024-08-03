using System.ComponentModel.DataAnnotations;

namespace Domain.Validations.Attributes;

public class BeAllDigitsAttribute() :
    RegularExpressionAttribute(RegexValidations.BeAllDigits);