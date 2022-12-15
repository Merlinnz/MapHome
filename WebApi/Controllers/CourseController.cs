using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class CourseController 
{
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("GetCourse")]
    public async Task<List<GetCourseDto>> GetCourses()
    {
        return await _courseService.GetCourses();
    }

    [HttpPost("CreateCourse")]
    public async Task<AddCourseDto> AddCourse(AddCourseDto course)
    {
        return await _courseService.AddCourse(course);
    }

    [HttpPut("UpdateCourse")]
    public async Task<AddCourseDto> UpdateCourse(AddCourseDto course)
    {
        return await _courseService.UpdateCourse(course);
    }

    [HttpDelete("DeleteCourse")]
    public async Task<string> DeleteCourse(int id)
    {
        return await _courseService.DeleteCourse(id);
    }
}