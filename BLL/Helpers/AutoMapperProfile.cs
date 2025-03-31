using AutoMapper;
using Data.Dtos.SchoolDtos;
using Data.Dtos.StudentDtos;
using Data.Dtos.TeacherDtos;
using Data.Models;

namespace BLL.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        
        // TEACHER
        CreateMap<Teacher, GetTeacherAccountDto>()
            .ForMember(d => d.TeacherStudentsCredentials, o => o.MapFrom(t => t.Students))
            .ForMember(d => d.TeacherSchoolCredentials, o => o.MapFrom(t => t.School));
            
        CreateMap<Teacher, GetTeacherCredentialsDto>();
        CreateMap<Teacher, GetTeacherStudyResultsDto>().ReverseMap();
        CreateMap<Teacher, CreateTeacherDto>().ReverseMap();

        // SCHOOL
        CreateMap<School, GetSchoolAccountDto>()
            .ForMember(d => d.SchoolStudentsCredentials, o => o.MapFrom(s => s.Students))
            .ForMember(d => d.SchoolTeachersCredentials, o => o.MapFrom(s => s.Teachers));
            
        CreateMap<School, GetSchoolCredentialsDto>().ReverseMap();
        CreateMap<School, CreateSchoolDto>().ReverseMap();
        
        // STUDENT
        CreateMap<Student, GetStudentCredentialsDto>().ReverseMap();
        CreateMap<Student, CreateStudentDto>().ReverseMap();
        CreateMap<Student, GetStudentProgressDto>()
            .ForMember(d => d.LastVisitation, o => o.MapFrom(s => s.StudentActivity.LastVisitation))
            .ForMember(d => d.GamesCompleted, o => o.MapFrom(s => s.StudentGameProgressAnalytic.GamesCompleted))
            .ForMember(d => d.AverageScorePerGame, o => o.MapFrom(s => s.StudentGameProgressAnalytic.AverageScorePerGame))
            .ForMember(d => d.WordsCountInVocabulary, o => o.MapFrom(s => s.StudentVocabularyAnalytic.WordsCountInVocabulary))
            .ForMember(d => d.LastVocabularyUpdate, o => o.MapFrom(s => s.StudentVocabularyAnalytic.LastVocabularyUpdate))
            .ReverseMap();
        
        CreateMap<Student, GetStudentAccountDto>()
            .ForMember(d => d.LastVisitation, o => o.MapFrom(s => s.StudentActivity.LastVisitation))
            .ForMember(d => d.GamesCompleted, o => o.MapFrom(s => s.StudentGameProgressAnalytic.GamesCompleted))
            .ForMember(d => d.AverageScorePerGame, o => o.MapFrom(s => s.StudentGameProgressAnalytic.AverageScorePerGame))
            .ForMember(d => d.WordsCountInVocabulary, o => o.MapFrom(s => s.StudentVocabularyAnalytic.WordsCountInVocabulary))
            .ForMember(d => d.LastVocabularyUpdate, o => o.MapFrom(s => s.StudentVocabularyAnalytic.LastVocabularyUpdate))
            .ForMember(d => d.SchoolCredentials, o => o.MapFrom(s => s.School))
            .ForMember(d => d.TeacherCredentials, o => o.MapFrom(s => s.Teacher))
            .ReverseMap();
    }
}