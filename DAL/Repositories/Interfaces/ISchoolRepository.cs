using DAL.Repositories.Core.Interfaces;
using Data.Models;

namespace DAL.Repositories.Interfaces;

public interface ISchoolRepository : IGenericRepository<School>
{
    Task<School> GetFullData(string email, string password);
    Task<Guid> GetIdByEnrollmentKey(string enrollmentKey);
    Task<bool> IsEnrollmentKeyFree(string enrollmentKey);
    Task<bool> IsEmailFree(string email);
}