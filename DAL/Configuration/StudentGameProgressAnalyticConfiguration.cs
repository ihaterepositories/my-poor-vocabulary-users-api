using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class StudentGameProgressAnalyticConfiguration : IEntityTypeConfiguration<StudentGameProgressAnalytic>
{
    public void Configure(EntityTypeBuilder<StudentGameProgressAnalytic> builder)
    {
        builder.HasKey(x => x.StudentId);
        builder.Property(x => x.GamesCompleted);
        builder.Property(x => x.AverageScorePerGame);
    }
}