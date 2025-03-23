using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class StudentGameProgressAnalyticRepository : GenericRepository<StudentGameProgressAnalytic>, IStudentGameProgressAnalyticRepository
{
    protected StudentGameProgressAnalyticRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}