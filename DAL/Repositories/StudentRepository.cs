using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    protected StudentRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}