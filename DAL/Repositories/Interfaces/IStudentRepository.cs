using DAL.Repositories.Core.Interfaces;
using Data.Models;

namespace DAL.Repositories.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<bool> IsEmailFree(string email);
    Task<Student> GetWithProgressData(string email);
    Task<Student> GetFull(string email, string password);
}