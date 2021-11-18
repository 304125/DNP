using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        
        [Range(0, 99999999999, ErrorMessage = "Salary must be bigger than than {1} and smaller than {2}")]
        public int Salary { get; set; }

        public override bool Equals(Object obj)
        {
            if (!obj.GetType().Equals(this.GetType()) || (obj == null))
            {
                return false;
            }

            Job job2 = (Job) obj;
            if (this.Id == job2.Id && this.Salary == job2.Salary && this.JobTitle.Equals(job2.JobTitle))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return JobTitle;
        }
    }
}