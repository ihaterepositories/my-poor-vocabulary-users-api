using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class StudentVocabularyAnalyticConfiguration : IEntityTypeConfiguration<StudentVocabularyAnalytic>
{
    public void Configure(EntityTypeBuilder<StudentVocabularyAnalytic> builder)
    {
        builder.HasKey(x => x.StudentId);
        builder.Property(x => x.WordsCount);
        builder.Property(x => x.LastUpdate);
    }
}