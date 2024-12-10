using Education_System_GUI.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Education_System_GUI
{
    public partial class ScheduleForm : Form
    {
        StudentScheduleDAO studentScheduleDAO = new StudentScheduleDAO();
        DataTable dt = new DataTable();
        int studentId;
        Form parent;
        public ScheduleForm(Form parent, int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.parent = parent;
            dt.Columns.Add("Thời gian bắt đầu", typeof(object));
            dt.Columns.Add("Thời gian kết thúc", typeof(object));
            dt.Columns.Add("Tiết học", typeof(object));
            dt.Columns.Add("Phòng học", typeof(object));
            dt.Columns.Add("Môn học", typeof(object));
            dt.Columns.Add("Lớp", typeof(object));
            dt.Columns.Add("Học kỳ", typeof(object));
            dt.Columns.Add("Giáo viên", typeof(object));
            dt.Columns.Add("Học vị", typeof(object));
            UpdateTable();
        }

        public void UpdateTable(string? semesterCode = null, DateTime? date = null, int? lessonNum = null, string? courseName = null, string? classroomName = null)
        {
            try
            {
                dt.Rows.Clear();
                var list = studentScheduleDAO.GetSchedulesByStudentId(studentId, semesterCode, date, lessonNum, courseName, classroomName);
                if (list != null && list.Count > 0)
                {
                    foreach (var schedule in list)
                    {
                        dt.Rows.Add(schedule.StartTime.ToString("dd/MM/yyyy HH:mm"), schedule.EndTime.ToString("dd/MM/yyyy HH:mm"),
                                    schedule.LessonNum, schedule.RoomName, schedule.SubjectName, schedule.ClassName, schedule.SemesterCode, schedule.TeacherName, schedule.TeacherDegree);
                    }
                }
                table.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa thêm thủ tục vào database, hãy kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string semester = txtSemester.Text.Trim();
            string lesson = txtLesson.Text.Trim();
            string course = txtCourse.Text.Trim();
            string classroom = txtClass.Text.Trim();
            DateTime date = datePicker.Value;
            if (string.IsNullOrEmpty(semester) && string.IsNullOrEmpty(lesson) && string.IsNullOrEmpty(course) && string.IsNullOrEmpty(classroom))
            {
                UpdateTable(date: date);
                return;
            }
            int? lessonNum = null;
            string? semesterCode = null;
            string? courseName = null;
            string? classroomName = null;
            try
            {
                lessonNum = int.Parse(lesson);
            }
            catch (Exception ex)
            {

            }
            if (!string.IsNullOrEmpty(semester))
            {
                semesterCode = semester;
            }
            if (!string.IsNullOrEmpty(course))
            {
                courseName = course;
            }
            if (!string.IsNullOrEmpty(classroom))
            {
                classroomName = classroom;
            }
            UpdateTable(semesterCode: semesterCode, date: date.Date, lessonNum: lessonNum, courseName: courseName, classroomName: classroomName);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ScheduleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }
    }
}
