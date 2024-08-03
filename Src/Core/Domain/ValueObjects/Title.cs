﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class Title : SingleValueObject<string>
{
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("عنوان")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}