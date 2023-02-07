using System.ComponentModel.DataAnnotations;

namespace ayclass_backend
{
    public class Student
    {
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
    }
}

