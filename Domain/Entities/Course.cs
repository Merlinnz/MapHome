using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Course
{
    [Key]
    public int CourseId { get; set; }
    public string? Title { get; set; }
    public string? Credits { get; set; }
    public int DepertmentId { get; set; }
    public List<Enrollment> Enrollments { get; set; }
}
