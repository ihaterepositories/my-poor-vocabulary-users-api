using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Core.Interfaces;

public interface IUnitOfWork
{
    ISchoolGroupRepository SchoolGroupRepository { get; }
    ISchoolRepository SchoolRepository { get; }
    IStudentActivityRepository StudentActivityRepository { get; }
    IStudentGameProgressAnalyticRepository StudentGameProgressAnalyticRepository { get; }
    IStudentRepository StudentRepository { get; }
    IStudentVocabularyAnalyticRepository StudentVocabularyAnalyticRepository { get; }
    ITeacherRepository TeacherRepository { get; }
    
    Task SaveChangesAsync();
}