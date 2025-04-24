using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SchoolRepository : GenericRepository<School>, ISchoolRepository
{
    public SchoolRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
    
    public async Task<School> GetFullData(string email, string password)
    {
        return await DatabaseContext.Schools
            .Include(x => x.Teachers)
            .Include(x => x.Students)
            .Where(s => s.Email == email && s.Password == password)
            .FirstOrDefaultAsync() ?? School.GetEmpty();
    }

    public async Task<Guid> GetIdByEnrollmentKey(string enrollmentKey)
    {
        return await DatabaseContext.Schools
            .Where(x => x.KeyForEnrollment == enrollmentKey)
            .Select(s => s.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsEnrollmentKeyFree(string enrollmentKey)
    {
        if (!await Table.AnyAsync()) return true;
        return !await Table.AnyAsync(s => s.KeyForEnrollment == enrollmentKey);
    }
    
    public async Task<bool> IsEmailFree(string email)
    {
        if (!await Table.AnyAsync()) return true;
        return !await Table.AnyAsync(s => s.Email == email);
    }
}