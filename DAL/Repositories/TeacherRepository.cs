using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    protected TeacherRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}