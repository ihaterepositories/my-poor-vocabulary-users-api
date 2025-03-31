using BLL.Services.Interfaces;
using Data.Dtos.TeacherDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("teachers")]
public class TeacherController(ITeacherService teacherService) : ControllerBase
{
    [HttpGet("getFullAccountData/{email}/{password}")]
    public async Task<IActionResult> GetFullAccountData(string email, string password)
    {
        var response = await teacherService.GetFullAccountData(email, password);
        
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }

    [HttpGet("getStudyResults/{email}")]
    public async Task<IActionResult> GetStudyResults(string email)
    {
        var response = await teacherService.GetStudyResults(email);
        
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateTeacherDto createTeacherDto)
    {
        var response = await teacherService.Register(createTeacherDto);
        
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
}