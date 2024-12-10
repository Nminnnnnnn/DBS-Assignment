using Education_System_GUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_System_GUI.DAO
{
    public class StudentScheduleDAO : GeneralDAO
    {
        public List<StudentSchedule> GetSchedulesByStudentId(int studentId , string? semesterCode = null, DateTime? date = null, int? lessonNum = null, string? courseName = null, string? classroomName = null)
        {
            List<StudentSchedule> studentSchedules = new List<StudentSchedule>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetStudentSchedule", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@SemesterCode", semesterCode != null ? semesterCode : DBNull.Value);
                command.Parameters.AddWithValue("@Date", date != null && date.HasValue ? date.Value.Date : DBNull.Value);
                command.Parameters.AddWithValue("@LessonNum", lessonNum != null ? lessonNum.Value : DBNull.Value);
                command.Parameters.AddWithValue("@CourseName", courseName != null ? courseName : DBNull.Value);
                command.Parameters.AddWithValue("@ClassroomName", classroomName != null ? classroomName : DBNull.Value);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    studentSchedules.Add(new StudentSchedule
                    {
                        StartTime = Convert.ToDateTime(reader["StartTime"]),
                        EndTime = Convert.ToDateTime(reader["EndTime"]),
                        LessonNum = Convert.ToInt32(reader["LessonNum"]),
                        RoomName = reader["RoomName"].ToString(),
                        SubjectName = reader["SubjectName"].ToString(),
                        ClassName = reader["ClassName"].ToString(),
                        SemesterCode = reader["SemesterCode"].ToString(),
                        TeacherName = reader["TeacherName"].ToString(),
                        TeacherDegree = reader["TeacherDegree"].ToString()
                    });
                }
            }

            return studentSchedules;
        }
    }
}
