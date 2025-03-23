using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class SchoolGroupConfiguration : IEntityTypeConfiguration<SchoolGroup>
{
    public void Configure(EntityTypeBuilder<SchoolGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.KeyForEnrollment).IsRequired();
        
        builder.HasMany(x => x.Students).WithOne(x => x.SchoolGroup).HasForeignKey(x => x.SchoolGroupId);
    }
}