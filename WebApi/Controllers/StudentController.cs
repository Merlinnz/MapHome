using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]


public class StudentController
{
    private readonly StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("GetStudent")]
    public async Task<List<GetStudentDto>> GetStudent()
    {
        return await _studentService.GetStudents();
    }

    [HttpPost("CreateStudent")]
    public async Task<AddStudentDto> AddStudent([FromForm] AddStudentDto student)
    {
        return await _studentService.AddStudent(student);
    }

    [HttpPut("UpdateStudent")]
    public async Task<GetStudentDto> UpdateStudent([FromForm]AddStudentDto student)
    {
        return await _studentService.UpdateStudent(student);
    }

    [HttpDelete("DeleteStudent")]
    public async Task<string> DeleteStudent(int id)
    {
        return await _studentService.DeleteStudent(id);
    }
}
