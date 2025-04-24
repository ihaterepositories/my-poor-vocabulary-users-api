using DAL.Repositories.Core;
using DAL.Repositories.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<bool> IsEmailFree(string email)
    {
        if (!await Table.AnyAsync()) return true;
        return !await Table.AnyAsync(s => s.Email == email);
    }

    public async Task<Student> GetWithProgressData(string email)
    {
        return await DatabaseContext.Students
            .Include(x => x.StudentActivity)
            .Include(x => x.StudentGameProgressAnalytic)
            .Include(x => x.StudentVocabularyAnalytic)
            .Where(s => s.Email == email)
            .FirstOrDefaultAsync() ?? Student.GetEmpty();
    }
    
    public async Task<Student> GetFull(string email, string password)
    {
        return await DatabaseContext.Students
            .Include(x => x.StudentActivity)
            .Include(x => x.StudentGameProgressAnalytic)
            .Include(x => x.StudentVocabularyAnalytic)
            .Include(x => x.School)
            .Include(x => x.Teacher)
            .Where(x => x.Email == email && x.Password == password)
            .FirstOrDefaultAsync() ?? Student.GetEmpty();
    }
}