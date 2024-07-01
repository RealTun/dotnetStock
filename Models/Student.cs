using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? Address { get; set; }
    }
}
