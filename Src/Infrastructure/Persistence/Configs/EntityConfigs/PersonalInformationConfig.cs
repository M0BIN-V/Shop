using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configs.EntityConfigs.EntityConfigurations;

internal class PersonalInformationConfig : IEntityTypeConfiguration<PersonalInformation>
{
    public void Configure(EntityTypeBuilder<PersonalInformation> builder)
    {
        builder.HasIndex(c => c.PhoneNumber);

        #region Convevtions
        builder.Property(p => p.FirstName)
            .HasConversion(n => n!.Value, v => new() { Value = v });

        builder.Property(p => p.LastName)
            .HasConversion(l => l!.Value, v => new() { Value = v });

        builder.Property(p => p.PhoneNumber)
            .HasConversion(p => p.Value, v => new() { Value = v });
        #endregion
    }
}