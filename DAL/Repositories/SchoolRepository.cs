using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class SchoolRepository : GenericRepository<School>, ISchoolRepository
{
    protected SchoolRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}