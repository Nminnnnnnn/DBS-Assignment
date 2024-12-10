using Education_System_GUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Education_System_GUI.DAO
{
    public class StudentDAO : GeneralDAO
    {
        public (bool, string) Add(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("InsertStudentAndUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Password", student.Password);
                command.Parameters.AddWithValue("@FullName", student.FullName);
                if(student.IdentityNumber != null)
                {
                    command.Parameters.AddWithValue("@IdentityNumber", student.IdentityNumber);
                }
                if(student.BirthDate != null)
                {
                    command.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                }
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@Department", student.Department);
                command.Parameters.AddWithValue("@Status", student.Status);
                command.Parameters.AddWithValue("@AdmissionDate", student.AdmissionDate);
                command.Parameters.AddWithValue("@LearningStatus", student.LearningStatus);

                // Declare the output parameter
                SqlParameter errorMessageParam = new SqlParameter
                {
                    ParameterName = "@ErrorMessage",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = -1,  // -1 for MAX
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(errorMessageParam);

                connection.Open();
                bool res = false;
                int row = command.ExecuteNonQuery();
                if(row > 0)
                {
                    res = true;
                }
                return (res, errorMessageParam.Value == DBNull.Value ? null : (string)errorMessageParam.Value);
            }
        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Student INNER JOIN [User] ON Student.UserId = [User].Id;";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        IdentityNumber = reader["IdentityNumber"].ToString() ?? null,
                        BirthDate = reader["BirthDate"] as DateTime? ?? null,
                        Gender = reader["Gender"].ToString(),
                        Department = reader["Department"].ToString(),
                        Status = reader["Status"].ToString(),
                        AdmissionDate = Convert.ToDateTime(reader["AdmissionDate"]),
                        LearningStatus = reader["LearningStatus"].ToString()
                    });
                }
            }

            return students;
        }

        public Student GetStudentById(int id)
        {
            Student Student = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Student" +
                    " INNER JOIN [User] ON Student.UserId = [User].Id" +
                    " WHERE Student.UserId = @UserId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Student = new Student
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        IdentityNumber = reader["IdentityNumber"].ToString() ?? null,
                        BirthDate = reader["BirthDate"] as DateTime? ?? null,
                        Gender = reader["Gender"].ToString(),
                        Department = reader["Department"].ToString(),
                        Status = reader["Status"].ToString(),
                        AdmissionDate = Convert.ToDateTime(reader["AdmissionDate"]),
                        LearningStatus = reader["LearningStatus"].ToString()
                    };
                }
            }
            return Student;
        }

        public StudentGpaStatistic GetStudentGpaStatistic(int studentId)
        {
            StudentGpaStatistic statistic = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.CalculateStudentGPA(@StudentId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    try
                    {
                        statistic = new StudentGpaStatistic
                        {
                            TotalCredits = reader["TotalCredits"] != null ? Convert.ToInt32(reader["TotalCredits"]) : -1,
                            TotalGPA = reader["GPA"] != null ? Convert.ToDouble(reader["GPA"]) : -1,
                            CourseDetails = reader["GPA"] != null ? reader["CourseDetails"].ToString() : "",
                        };
                    } catch(Exception e)
                    {
                        statistic = new StudentGpaStatistic
                        {
                            TotalCredits = -1,
                            TotalGPA = -1,
                            CourseDetails = ""
                        };
                    }
                }
            }
            return statistic;
        }

        public (bool, string) Update(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateStudentAndUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", student.UserId);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Password", student.Password);
                command.Parameters.AddWithValue("@FullName", student.FullName);
                if (student.IdentityNumber != null)
                {
                    command.Parameters.AddWithValue("@IdentityNumber", student.IdentityNumber);
                }
                if (student.BirthDate != null)
                {
                    command.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                }
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@Department", student.Department);
                command.Parameters.AddWithValue("@Status", student.Status);
                command.Parameters.AddWithValue("@AdmissionDate", student.AdmissionDate);
                command.Parameters.AddWithValue("@LearningStatus", student.LearningStatus);
                // Declare the output parameter
                SqlParameter errorMessageParam = new SqlParameter
                {
                    ParameterName = "@ErrorMessage",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = -1,  // -1 for MAX
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(errorMessageParam);

                connection.Open();
                bool res = false;
                int row = command.ExecuteNonQuery();
                if (row > 0)
                {
                    res = true;
                }
                return (res, errorMessageParam.Value == DBNull.Value ? null : (string)errorMessageParam.Value);
            }
        }

        public (bool, string) Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteStudentAndUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", id);
                // Declare the output parameter
                SqlParameter errorMessageParam = new SqlParameter
                {
                    ParameterName = "@ErrorMessage",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = -1,  // -1 for MAX
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(errorMessageParam);
                connection.Open();
                bool res = false;
                int row = command.ExecuteNonQuery();
                if (row > 0)
                {
                    res = true;
                }
                return (res, errorMessageParam.Value == DBNull.Value ? null : (string)errorMessageParam.Value);
            }
        }
    }
}
