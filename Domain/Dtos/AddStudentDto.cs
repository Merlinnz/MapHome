using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;

public class AddStudentDto
{
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public IFormFile Image { get; set; }
}
