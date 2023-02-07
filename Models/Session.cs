using System.ComponentModel.DataAnnotations;
using ayclass_backend.Enums;

namespace ayclass_backend
{
    public class Session
    {
        public long Id { get; set; }
        [Required]
        public long StudentId { get; set; }
        [Required]
        public long TutorId { get; set; }
        public string Date { get; set; }
        public bool IsEmailSent { get; set; } = false;
        public double Rating { get; set; } = 0;
        public SessionState State { get; set; } = SessionState.Pending;
    }
}