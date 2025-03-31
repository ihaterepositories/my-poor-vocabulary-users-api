using DAL.Repositories.Core.Interfaces;
using Data.Models;

namespace DAL.Repositories.Interfaces;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<Teacher> GetFullData(string email, string password);
    Task<Teacher> GetWithFullStudents(string email);
    Task<Guid> GetIdByEnrollmentKey(string enrollmentKey);
    Task<bool> IsEnrollmentKeyFree(string enrollmentKey);
    Task<bool> IsEmailFree(string email);
}