using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_System_GUI.Models
{
    public class StudentSchedule
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int LessonNum { get; set; }

        public string RoomName { get; set; }

        public string SubjectName { get; set; }

        public string ClassName { get; set; }

        public string SemesterCode { get; set; }

        public string TeacherName { get; set; }

        public string TeacherDegree { get; set; }
    }
}
