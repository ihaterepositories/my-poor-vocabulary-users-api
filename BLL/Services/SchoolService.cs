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

public class SchoolService : ISchoolService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _rc;
    private readonly IValidator<CreateSchoolDto> _validator;

    private ISchoolRepository Repository => _unitOfWork.SchoolRepository;
    
    public SchoolService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateSchoolDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
        
        _rc = new ResponseCreator();
    }

    public async Task<BaseResponse<GetSchoolAccountDto>> GetFullAccountData(string email, string password)
    {
        try
        {
            var school = await Repository.GetFullData(email, password);
            
            if (school.IsEmpty)
                return _rc.CreateBadRequest<GetSchoolAccountDto>("Wrong email or password.");
            
            var schoolDto = _mapper.Map<GetSchoolAccountDto>(school);
            return _rc.CreateOk(schoolDto);
        }
        catch (Exception e)
        {
            return _rc.CreateServerError<GetSchoolAccountDto>(e.Message);
        }
    }

    public async Task<NoReturnDataResponse> Register(CreateSchoolDto? schoolDto)
    {
        try
        {
            if (schoolDto == null)
                return _rc.CreateBadRequest("Some fields are missing or invalid.");
            
            // email availability check
            var isEmailAvailable = 
                await Repository.IsEmailFree(schoolDto.Email) && 
                await _unitOfWork.StudentRepository.IsEmailFree(schoolDto.Email) &&
                await _unitOfWork.TeacherRepository.IsEmailFree(schoolDto.Email);
            
            if (isEmailAvailable == false)
                return _rc.CreateBadRequest("This email already registered.");
            
            // enrollment key availability check
            var isKeyAvailable = 
                await Repository.IsEnrollmentKeyFree(schoolDto.KeyForEnrollment) &&
                await _unitOfWork.TeacherRepository.IsEnrollmentKeyFree(schoolDto.KeyForEnrollment);
            
            if (isKeyAvailable == false)
                return _rc.CreateBadRequest("This enrollment key already exists.");
            
            // dto validation
            var validationResult = await _validator.ValidateAsync(schoolDto);
            if (!validationResult.IsValid)
                return _rc.CreateBadRequest(validationResult.ToString());

            // model creation
            var school = _mapper.Map<CreateSchoolDto, School>(schoolDto);
            school.Id = Guid.NewGuid();
            school.RegistrationDate = DateTime.UtcNow;
            
            // adding model to database
            await Repository.Create(school);
            await _unitOfWork.SaveChangesAsync();
            
            return _rc.CreateOk();
        }
        catch (Exception e)
        {
            return _rc.CreateServerError(e.Message);
        }
    }
}