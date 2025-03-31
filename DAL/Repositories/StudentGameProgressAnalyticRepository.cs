using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class StudentGameProgressAnalyticRepository : GenericRepository<StudentGameProgressAnalytic>, IStudentGameProgressAnalyticRepository
{
    public StudentGameProgressAnalyticRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}