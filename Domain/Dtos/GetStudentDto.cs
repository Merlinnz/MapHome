namespace Domain.Dtos;

public class GetStudentDto
{
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImageName { get; set; }
}
