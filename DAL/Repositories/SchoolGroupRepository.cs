using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;

namespace DAL.Repositories;

public class SchoolGroupRepository : GenericRepository<SchoolGroup>, ISchoolGroupRepository
{
    protected SchoolGroupRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}