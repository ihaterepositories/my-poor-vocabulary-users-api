using Data.Dtos.StudentDtos;
using Data.Responses;

namespace BLL.Services.Interfaces;

public interface IStudentService
{
    Task<BaseResponse<GetStudentAccountDto>> GetFullAccountData(string email, string password);
    Task<BaseResponse<GetStudentProgressDto>> GetProgress(string email);
    Task<NoReturnDataResponse> Register(CreateStudentDto? studentDto);
    Task<NoReturnDataResponse> UpdateProgress(UpdateStudentProgressDto? studentProgressDto);
}