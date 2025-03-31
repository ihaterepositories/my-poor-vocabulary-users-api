using Data.Dtos.TeacherDtos;
using Data.Responses;

namespace BLL.Services.Interfaces;

public interface ITeacherService
{
    Task<BaseResponse<GetTeacherAccountDto>> GetFullAccountData(string email, string password);
    Task<BaseResponse<GetTeacherStudyResultsDto>> GetStudyResults(string email);
    Task<NoReturnDataResponse> Register(CreateTeacherDto? teacherDto);
}