using System.ComponentModel.DataAnnotations;
using ayclass_backend.Enums;

namespace ayclass_backend.models
{
    public class Tutor
    {
        public long Id { get; set; }

        public Student Student { get; set; }

        // public Universities University { get; set; }

        public string Institution { get; set; }

        //     public Fields Field { get; set; }
        //     public double Rating { get; set; }
        //     public string Bio { get; set; }
        //     public List<string> Stenghts { get; set; }

        //     public byte[] StudentIdCard { get; set; }

        //     public List<byte[]> ProofOfGrades { get; set; }
        //     public bool IsActive { get; set; }
        // 
    }
}