using AutoMapper;
using BLL.Helpers;
using BLL.Services.Interfaces;
using BLL.Validators;
using DAL.Repositories.Core.Interfaces;
using DAL.Repositories.Interfaces;
using Data.Dtos.StudentDtos;
using Data.Models;
using Data.Responses;
using FluentValidation;

namespace BLL.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _rc;
    private readonly IValidator<CreateStudentDto> _createValidator;
    private readonly IValidator<UpdateStudentProgressDto> _updateValidator;
    
    private IStudentRepository Repository => _unitOfWork.StudentRepository;

    public StudentService(
        IUnitOfWork unitOfWork, 
        IMapper mapper, 
        IValidator<CreateStudentDto> createValidator,
        IValidator<UpdateStudentProgressDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        
        _rc = new ResponseCreator();
    }

    public async Task<BaseResponse<GetStudentAccountDto>> GetFullAccountData(string email, string password)
    {
        try
        {
            var student = await Repository.GetFull(email, password);
            
            if (student.IsEmpty)
                return _rc.CreateNotFound<GetStudentAccountDto>("Wrong email or password.");

            var studentDto = _mapper.Map<GetStudentAccountDto>(student);
            return _rc.CreateOk(studentDto);
        }
        catch (Exception e)
        {
            return _rc.CreateServerError<GetStudentAccountDto>(e.Message);
        }
    }

    public async Task<BaseResponse<GetStudentProgressDto>> GetProgress(string email)
    {
        try
        {
            if (string.IsNullOrEmpty(email)) 
                return _rc.CreateBadRequest<GetStudentProgressDto>("Email is empty.");
            
            var student = await Repository.GetWithProgressData(email);
            
            if (student.IsEmpty)
                return _rc.CreateBadRequest<GetStudentProgressDto>("Student with this email doesn't exist.");
            
            var studentDto = _mapper.Map<GetStudentProgressDto>(student);
            
            return _rc.CreateOk(studentDto);
        }
        catch (Exception e)
        {
            return _rc.CreateServerError<GetStudentProgressDto>(e.Message);
        }
    }

    public async Task<NoReturnDataResponse> Register(CreateStudentDto? studentDto)
    {
        try
        {
            if (studentDto == null)
                return _rc.CreateBadRequest("Model is null.");
            
            // email availability check
            var isEmailAvailable = await Repository.IsEmailFree(studentDto.Email);
            if (isEmailAvailable == false)
                return _rc.CreateBadRequest("This email already registered.");
            
            // dto validation
            var validationResult = await _createValidator.ValidateAsync(studentDto);
            if (!validationResult.IsValid)
                return _rc.CreateBadRequest(validationResult.ToString());

            // model creation
            var schoolId = await _unitOfWork.SchoolRepository.GetIdByEnrollmentKey(studentDto.SchoolKeyForEnrollment);
            if (schoolId == Guid.Empty) return _rc.CreateBadRequest("School with this enrollment key doesn't exist.");
            
            var teacherId = await _unitOfWork.TeacherRepository.GetIdByEnrollmentKey(studentDto.TeacherKeyForEnrollment);
            if (teacherId == Guid.Empty) return _rc.CreateBadRequest("Teacher with this enrollment key doesn't exist.");
            
            var student = _mapper.Map<Student>(studentDto);
            student.Id = Guid.NewGuid();
            student.SchoolId = schoolId;
            student.School = null;
            student.TeacherId = teacherId;
            student.Teacher = null;
            student.RegistrationDate = DateTime.UtcNow;
            student.DateOfBirth = DateTime.SpecifyKind(studentDto.DateOfBirth, DateTimeKind.Utc);
            
            // creating tables for student`s progress analytic
            var studentActivity = new StudentActivity { StudentId = student.Id, Student = null };
            var studentGameProgressAnalytic = new StudentGameProgressAnalytic { StudentId = student.Id, Student = null };
            var studentVocabularyProgressAnalytic = new StudentVocabularyAnalytic { StudentId = student.Id, Student = null };
            
            await _unitOfWork.StudentActivityRepository.Create(studentActivity);
            await _unitOfWork.StudentGameProgressAnalyticRepository.Create(studentGameProgressAnalytic);
            await _unitOfWork.StudentVocabularyAnalyticRepository.Create(studentVocabularyProgressAnalytic);
            
            // adding student to database
            await Repository.Create(student);
            await _unitOfWork.SaveChangesAsync();

            return _rc.CreateOk();
        }
        catch (Exception e)
        {
            return _rc.CreateServerError(e.Message);
        }
    }

    public async Task<NoReturnDataResponse> UpdateProgress(UpdateStudentProgressDto? studentProgressDto)
    {
        try
        {
            if (studentProgressDto == null)
                return _rc.CreateBadRequest("Received data is null or id is incorrect.");
            
            var validationResult = await _updateValidator.ValidateAsync(studentProgressDto);
            if (!validationResult.IsValid)
                return _rc.CreateBadRequest(validationResult.ToString());
            
            if (await Repository.IsIdExists(studentProgressDto.StudentId) == false)
                return _rc.CreateBadRequest("Student with this id doesn't exist.");
            
            var studentActivity = await _unitOfWork.StudentActivityRepository.GetById(studentProgressDto.StudentId);
            var studentGameProgressAnalytic = await _unitOfWork.StudentGameProgressAnalyticRepository.GetById(studentProgressDto.StudentId);
            var studentVocabularyAnalytic = await _unitOfWork.StudentVocabularyAnalyticRepository.GetById(studentProgressDto.StudentId);
            
            studentActivity.LastVisitation = DateTime.SpecifyKind(studentProgressDto.LastVisitation, DateTimeKind.Utc);
            studentGameProgressAnalytic.AverageScorePerGame = studentProgressDto.AverageScorePerGame;
            studentGameProgressAnalytic.GamesCompleted = studentProgressDto.GamesCompleted;
            studentVocabularyAnalytic.WordsCountInVocabulary = studentProgressDto.WordsCountInVocabulary;
            studentVocabularyAnalytic.LastVocabularyUpdate = DateTime.SpecifyKind(studentProgressDto.LastVocabularyUpdate, DateTimeKind.Utc);
            
            await _unitOfWork.StudentActivityRepository.Update(studentActivity);
            await _unitOfWork.StudentGameProgressAnalyticRepository.Update(studentGameProgressAnalytic);
            await _unitOfWork.StudentVocabularyAnalyticRepository.Update(studentVocabularyAnalytic);
            await _unitOfWork.SaveChangesAsync();
            
            return _rc.CreateOk();
        }
        catch (Exception e)
        {
            return _rc.CreateServerError(e.Message);
        }
    }
}