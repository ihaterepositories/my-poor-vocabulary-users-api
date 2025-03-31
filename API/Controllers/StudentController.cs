using BLL.Services.Interfaces;
using Data.Dtos.StudentDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("students")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpGet("getFullAccountData/{email}/{password}")]
    public async Task<IActionResult> GetFullAccountData(string email, string password)
    {
        var response = await studentService.GetFullAccountData(email, password);
        
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
    
    [HttpGet("getProgress/{email}")]
    public async Task<IActionResult> GetProgress(string email)
    {
        var response = await studentService.GetProgress(email);
        
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateStudentDto createStudentDto)
    {
        var response = await studentService.Register(createStudentDto);
    
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }

    [HttpPut("updateProgress")]
    public async Task<IActionResult> UpdateProgress([FromBody] UpdateStudentProgressDto updateStudentProgressDto)
    {
        var response = await studentService.UpdateProgress(updateStudentProgressDto);
        
        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
}