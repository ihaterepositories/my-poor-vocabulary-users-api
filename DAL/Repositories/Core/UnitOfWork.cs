using DAL.Repositories.Core.Interfaces;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Core;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _databaseContext;

    public ISchoolGroupRepository SchoolGroupRepository { get; }
    public ISchoolRepository SchoolRepository { get; }
    public IStudentActivityRepository StudentActivityRepository { get; }
    public IStudentGameProgressAnalyticRepository StudentGameProgressAnalyticRepository { get; }
    public IStudentRepository StudentRepository { get; }
    public IStudentVocabularyAnalyticRepository StudentVocabularyAnalyticRepository { get; }
    public ITeacherRepository TeacherRepository { get; }
    
    public UnitOfWork(
        DatabaseContext databaseContext, 
        ISchoolGroupRepository schoolGroupRepository, 
        ISchoolRepository schoolRepository, 
        IStudentActivityRepository studentActivityRepository, 
        IStudentGameProgressAnalyticRepository studentGameProgressAnalyticRepository, 
        IStudentRepository studentRepository, 
        IStudentVocabularyAnalyticRepository studentVocabularyAnalyticRepository, 
        ITeacherRepository teacherRepository)
    {
        _databaseContext = databaseContext;
        SchoolGroupRepository = schoolGroupRepository;
        SchoolRepository = schoolRepository;
        StudentActivityRepository = studentActivityRepository;
        StudentGameProgressAnalyticRepository = studentGameProgressAnalyticRepository;
        StudentRepository = studentRepository;
        StudentVocabularyAnalyticRepository = studentVocabularyAnalyticRepository;
        TeacherRepository = teacherRepository;
    }
    
    public async Task SaveChangesAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}