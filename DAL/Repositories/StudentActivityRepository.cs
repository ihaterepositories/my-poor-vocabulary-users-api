using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class StudentActivityRepository : GenericRepository<StudentActivity>, IStudentActivityRepository
{
    protected StudentActivityRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}