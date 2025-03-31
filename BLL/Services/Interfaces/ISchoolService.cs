using Data.Dtos.SchoolDtos;
using Data.Models;
using Data.Responses;

namespace BLL.Services.Interfaces;

public interface ISchoolService
{
    Task<BaseResponse<GetSchoolAccountDto>> GetFullAccountData(string email, string password);
    Task<NoReturnDataResponse> Register(CreateSchoolDto? schoolDto);
}