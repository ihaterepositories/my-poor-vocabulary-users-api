using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class StudentVocabularyAnalyticRepository : GenericRepository<StudentVocabularyAnalytic>, IStudentVocabularyAnalyticRepository
{
    protected StudentVocabularyAnalyticRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}