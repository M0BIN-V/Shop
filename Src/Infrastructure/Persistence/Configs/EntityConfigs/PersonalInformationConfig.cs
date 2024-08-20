using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configs.EntityConfigs.EntityConfigurations;

internal class PersonalInformationConfig : IEntityTypeConfiguration<PersonalInformation>
{
    public void Configure(EntityTypeBuilder<PersonalInformation> builder)
    {
        builder.HasIndex(c => c.PhoneNumber);
    }
}