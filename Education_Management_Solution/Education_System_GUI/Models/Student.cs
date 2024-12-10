using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_System_GUI.Models
{
    public class Student
    {
        public int UserId { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string LearningStatus { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string? IdentityNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public string Status { get; set; }
    }
}
