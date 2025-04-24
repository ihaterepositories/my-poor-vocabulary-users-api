using AutoMapper;
using BLL.Helpers;
using BLL.Services.Interfaces;
using DAL.Repositories.Core.Interfaces;
using DAL.Repositories.Interfaces;
using Data.Dtos.SchoolDtos;
using Data.Dtos.StudentDtos;
using Data.Dtos.TeacherDtos;
using Data.Models;
using Data.Responses;
using FluentValidation;

namespace BLL.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _rc;
    private readonly IValidator<CreateTeacherDto> _validator;
    
    private ITeacherRepository Repository => _unitOfWork.TeacherRepository;

    public TeacherService(
        IUnitOfWork unitOfWork, 
        IMapper mapper, 
        IValidator<CreateTeacherDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
        _rc = new ResponseCreator();
    }

    public async Task<BaseResponse<GetTeacherAccountDto>> GetFullAccountData(string email, string password)
    {
        try
        {
            var teacher = await Repository.GetFullData(email, password);
            
            if (teacher.IsEmpty)
                return _rc.CreateNotFound<GetTeacherAccountDto>("Wrong email or password.");
            
            var teacherDto = _mapper.Map<GetTeacherAccountDto>(teacher);
            return _rc.CreateOk(teacherDto);
        }
        catch (Exception e)
        {
            return _rc.CreateServerError<GetTeacherAccountDto>(e.Message);
        }
    }

    public async Task<BaseResponse<GetTeacherStudyResultsDto>> GetStudyResults(string email)
    {
        try
        {
            var teacher = await Repository.GetWithFullStudents(email);
            
            if (teacher.IsEmpty)
                return _rc.CreateNotFound<GetTeacherStudyResultsDto>("Teacher with this email does not exist.");
            
            var teacherDto = _mapper.Map<GetTeacherStudyResultsDto>(teacher);
            
            // sub queries
            teacherDto.StudentsCount = teacher.Students.Count;
            teacherDto.StudentsAverageWordsCountInVocabulary = teacher.Students
                .Average(s => s.StudentVocabularyAnalytic.WordsCountInVocabulary);
            teacherDto.StudentsAverageGamesCompleted = teacher.Students
                .Average(s => s.StudentGameProgressAnalytic.GamesCompleted);
            teacherDto.LastWeekActiveStudentsCount = teacher.Students
                .Count(s => s.StudentActivity.LastVisitation >= DateTime.UtcNow.AddDays(-7));
            
            return _rc.CreateOk(teacherDto);
        }
        catch (Exception e)
        {
            return _rc.CreateServerError<GetTeacherStudyResultsDto>(e.Message);
        }
    }

    public async Task<NoReturnDataResponse> Register(CreateTeacherDto? teacherDto)
    {
        try
        {
            if (teacherDto == null)
                return _rc.CreateBadRequest("Some fields are missing or invalid.");
            
            // email availability check
            var isEmailAvailable = 
                await Repository.IsEmailFree(teacherDto.Email) && 
                await _unitOfWork.SchoolRepository.IsEmailFree(teacherDto.Email) &&
                await _unitOfWork.StudentRepository.IsEmailFree(teacherDto.Email);
            
            if (isEmailAvailable == false)
                return _rc.CreateBadRequest("This email already registered.");
            
            // enrollment key availability check
            var isKeyAvailable = 
                await Repository.IsEnrollmentKeyFree(teacherDto.KeyForEnrollment) &&
                await _unitOfWork.SchoolRepository.IsEnrollmentKeyFree(teacherDto.KeyForEnrollment);
            
            if (isKeyAvailable == false)
                return _rc.CreateBadRequest("This enrollment key already exists.");
            
            // dto validation
            var validationResult = await _validator.ValidateAsync(teacherDto);
            if (!validationResult.IsValid)
                return _rc.CreateBadRequest(validationResult.ToString());

            // model creation
            var schoolId = await _unitOfWork.SchoolRepository.GetIdByEnrollmentKey(teacherDto.SchoolKeyForEnrollment);
            if (schoolId == Guid.Empty) return _rc.CreateBadRequest("School with this enrollment key doesn't exist.");
            
            var teacher = _mapper.Map<Teacher>(teacherDto);
            teacher.Id = Guid.NewGuid();
            teacher.RegistrationDate = DateTime.UtcNow;
            teacher.SchoolId = schoolId;
            teacher.School = null;
            teacher.DateOfBirth = DateTime.SpecifyKind(DateTime.Parse(teacherDto.DateOfBirthUnformatted), DateTimeKind.Utc);
            
            // adding model to database
            await Repository.Create(teacher);
            await _unitOfWork.SaveChangesAsync();

            return _rc.CreateOk();
        }
        catch (Exception e)
        {
            return _rc.CreateServerError(e.Message);
        }
    }
}