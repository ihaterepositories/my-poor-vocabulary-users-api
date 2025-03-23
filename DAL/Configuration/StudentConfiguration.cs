using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(70);
        builder.Property(x => x.DateOfBirth).IsRequired();
        builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
        builder.Property(x => x.RegistrationDate).IsRequired();
        builder.Property(x => x.IsSchoolAttendee).IsRequired();
        
        builder
            .HasOne(x => x.StudentActivity)
            .WithOne(x => x.Student)
            .HasForeignKey<StudentActivity>(x => x.StudentId);
        
        builder
            .HasOne(x => x.StudentVocabularyAnalytic)
            .WithOne(x => x.Student)
            .HasForeignKey<StudentVocabularyAnalytic>(x => x.StudentId);
        
        builder
            .HasOne(x => x.StudentGameProgressAnalytic)
            .WithOne(x => x.Student)
            .HasForeignKey<StudentGameProgressAnalytic>(x => x.StudentId);
    }
}