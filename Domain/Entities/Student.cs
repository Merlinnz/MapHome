using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;


public class Student
{
    [Key]
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string ImageName { get; set; }
    public string? EnrollmentDate { get; set; }
    // Navigation Properties 
    public List<Enrollment> Enrollments { get; set; } 
}