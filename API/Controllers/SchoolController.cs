using BLL.Services.Interfaces;
using Data.Dtos.SchoolDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("schools")]
public class SchoolController(ISchoolService schoolService) : ControllerBase
{
    [HttpGet("getFullAccountData/{email}/{password}")]
    public async Task<IActionResult> GetFullAccountData(string email, string password)
    {
        var response = await schoolService.GetFullAccountData(email, password);
        
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateSchoolDto createSchoolDto)
    {
        var response = await schoolService.Register(createSchoolDto);
    
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
}