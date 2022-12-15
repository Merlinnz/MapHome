using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CourseService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetCourseDto>> GetCourses()
    {
        var list = await _context.Courses.Select(x => new GetCourseDto()
        {
            Title = x.Title,
            Credits = x.Credits,
            CourseId = x.CourseId
        }).ToListAsync();
        return list;
    }

    public async Task<AddCourseDto> AddCourse(AddCourseDto course)
    {
        var newCourse = _mapper.Map<Course>(course);
        _context.Courses.Add(newCourse);
        await _context.SaveChangesAsync();
        return _mapper.Map<AddCourseDto>(newCourse);
    }

    public async Task<AddCourseDto> UpdateCourse(AddCourseDto course)
    {
        var find = await _context.Courses.FindAsync(course.CourseId);
        find.Title = course.Title;
        find.Credits = course.Credits;
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<string> DeleteCourse(int id)
    {
        var find = await _context.Courses.FindAsync(id);
        _context.Courses.Remove(find);
        await _context.SaveChangesAsync();
        return "Deleted";
    }
}
