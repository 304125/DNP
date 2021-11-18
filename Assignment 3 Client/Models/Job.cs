using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        public string JobTitle { get; set; }
        
        [Range(0, 99999999999, ErrorMessage = "Salary must be bigger than than {1} and smaller than {2}")]
        public int Salary { get; set; }
    }
}