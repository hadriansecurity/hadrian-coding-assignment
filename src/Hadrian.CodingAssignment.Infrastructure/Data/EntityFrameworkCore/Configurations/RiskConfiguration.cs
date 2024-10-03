using Hadrian.CodingAssignment.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hadrian.CodingAssignment.Infrastructure.Data.EntityFrameworkCore.Configurations;

internal class RiskConfiguration : IEntityTypeConfiguration<Risk>
{
    public void Configure(EntityTypeBuilder<Risk> builder)
    {
        builder.UseTphMappingStrategy();

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.RiskSeverity)
            .HasConversion<string>();

        builder
            .Property(x => x.RiskStatus)
            .HasConversion<string>();
    }
}