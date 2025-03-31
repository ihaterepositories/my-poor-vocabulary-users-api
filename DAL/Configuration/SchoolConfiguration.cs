using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Address).HasMaxLength(200);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
        builder.Property(x => x.RegistrationDate).IsRequired();
        builder.Property(x => x.KeyForEnrollment).IsRequired();
        
        builder.HasMany(x => x.Students).WithOne(x => x.School).HasForeignKey(x => x.SchoolId);
        builder.HasMany(x => x.Teachers).WithOne(x => x.School).HasForeignKey(x => x.SchoolId);
    }
}