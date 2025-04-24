using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<Teacher> GetFullData(string email, string password)
    {
        return await DatabaseContext.Teachers
            .Include(x => x.School)
            .Include(x => x.Students)
            .Where(x => x.Email == email && x.Password == password)
            .FirstOrDefaultAsync() ?? Teacher.GetEmpty();
    }
    
    public async Task<Teacher> GetWithFullStudents(string email)
    {
        return await DatabaseContext.Teachers
            .Include(x => x.Students)
            .ThenInclude(x => x.StudentActivity)
            .Include(x => x.Students)
            .ThenInclude(x => x.StudentVocabularyAnalytic)
            .Include(x => x.Students)
            .ThenInclude(x => x.StudentGameProgressAnalytic)
            .Where(x => x.Email == email)
            .FirstOrDefaultAsync() ?? Teacher.GetEmpty();
    }

    public async Task<Guid> GetIdByEnrollmentKey(string enrollmentKey)
    {
        return await DatabaseContext.Teachers
            .Where(x => x.KeyForEnrollment == enrollmentKey)
            .Select(s => s.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsEnrollmentKeyFree(string enrollmentKey)
    {
        if (!await Table.AnyAsync()) return true;
        return !await Table.AnyAsync(x => x.KeyForEnrollment == enrollmentKey);
    }
    
    public async Task<bool> IsEmailFree(string email)
    {
        if (!await Table.AnyAsync()) return true;
        return !await Table.AnyAsync(s => s.Email == email);
    }
}