using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class StudentActivityConfiguration : IEntityTypeConfiguration<StudentActivity>
{
    public void Configure(EntityTypeBuilder<StudentActivity> builder)
    {
        builder.HasKey(x => x.StudentId);
        builder.Property(x => x.LastVisitation);
    }
}