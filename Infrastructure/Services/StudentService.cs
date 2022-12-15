using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _env;
    private readonly IMapper _mapper;

    public StudentService(DataContext context, IMapper mapper, IWebHostEnvironment environment)
    {
        _context = context;
        _mapper = mapper;
        _env = environment;
    }

    public async Task<List<GetStudentDto>> GetStudents()
    {
        var list = _mapper.Map<List<GetStudentDto>>(_context.Students.ToList());
        return new List<GetStudentDto>(list);
    }

    public async Task<AddStudentDto> AddStudent(AddStudentDto student)
    {
        var newStudent = _mapper.Map<Student>(student);
        _context.Students.Add(newStudent);
        await _context.SaveChangesAsync();
        return student;
    }   

    public async Task<GetStudentDto> UpdateStudent(AddStudentDto student)
    {
        var response = new GetStudentDto()
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            LastName = student.LastName,
            ImageName = student.Image.FileName
        };

        var find = await _context.Students.FindAsync(student.StudentId);
        find.FirstName = student.FirstName;
        find.LastName = student.LastName;

        
        if (student.Image != null)
        {
            find.ImageName = await UpdateFile(student.Image, find.ImageName);
        }
        await _context.SaveChangesAsync();

        return response;
    }

    public async Task<string> DeleteStudent(int id)
    {
        var find = await _context.Students.FindAsync(id);
        _context.Students.Remove(find);
        await _context.SaveChangesAsync();

        return "Deleted";
    }




    // Upload File
    private async Task<string> UploadFile(IFormFile file)
    {
        if (file == null) return null;
        
        //create folder if not exists
        var path = Path.Combine(_env.WebRootPath, "Image");
        if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
        
        var filepath = Path.Combine(path, file.FileName);
        using (var stream = new FileStream(filepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return file.FileName;
    }



    private async Task<string> UpdateFile(IFormFile file, string oldFileName)
    {
        //delete old image if exists
        var filepath = Path.Combine(_env.WebRootPath, "Image", oldFileName);
        if(File.Exists(filepath) == true) File.Delete(filepath);
        
        var newFilepath = Path.Combine(_env.WebRootPath, "Image", file.FileName);
        using (var stream = new FileStream(newFilepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return file.FileName;

    }
    
}

