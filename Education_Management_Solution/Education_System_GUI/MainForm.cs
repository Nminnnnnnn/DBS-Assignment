using Education_System_GUI.DAO;
using Education_System_GUI.Models;
using System.Data;

namespace Education_System_GUI
{
    public partial class MainForm : Form
    {
        StudentDAO studentDAO = new StudentDAO();
        DataTable studentDt = new DataTable();
        public MainForm()
        {
            InitializeComponent();
            studentDt.Columns.Add("Mã người dùng", typeof(object));
            studentDt.Columns.Add("Email", typeof(object));
            studentDt.Columns.Add("Họ và tên", typeof(object));
            studentDt.Columns.Add("CCCD", typeof(object));
            studentDt.Columns.Add("Ngày sinh", typeof(object));
            studentDt.Columns.Add("Mật khẩu", typeof(object));
            studentDt.Columns.Add("Giới tính", typeof(object));
            studentDt.Columns.Add("Khoa", typeof(object));
            studentDt.Columns.Add("Ngày nhập học", typeof(object));
            studentDt.Columns.Add("Tình trạng học tập", typeof(object));
            studentDt.Columns.Add("Trạng thái", typeof(object));
            cbGender.Items.Add("Nam");
            cbGender.Items.Add("Nữ");
            cbGender.Items.Add("Khác");
            cbGender.SelectedIndex = 0;
            cbLearningStatus.Items.Add("Đang học");
            cbLearningStatus.Items.Add("Nghỉ học");
            cbLearningStatus.SelectedIndex = 0;
            cbStatus.Items.Add("Hoạt động");
            cbStatus.Items.Add("Ngưng hoạt động");
            cbStatus.SelectedIndex = 0;
            cbDepartment.Items.Add("Công nghệ thông tin");
            cbDepartment.Items.Add("Kinh tế");
            cbDepartment.Items.Add("Ngoại ngữ");
            cbDepartment.Items.Add("Luật");
            cbDepartment.SelectedIndex = 0;
            UpdateStudentList();
        }

        public void ClearField()
        {
            cbGender.SelectedIndex = 0;
            cbLearningStatus.SelectedIndex = 0;
            cbDepartment.SelectedIndex = 0;
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtIdentify.Text = "";
            txtId.Text = "";
            birthDatePicker.Value = DateTime.Now;
            admissionDatePicker.Value = DateTime.Now;
        }

        public void UpdateStudentList()
        {
            List<Student> students = studentDAO.GetAllStudents();

            studentDt.Rows.Clear();
            foreach (Student student in students)
            {
                string birthDate = student.BirthDate == null ? "" : student.BirthDate.Value.ToString("dd/MM/yyyy");
                string identityNumber = student.IdentityNumber == null ? "" : student.IdentityNumber;
                string learningStatus = student.LearningStatus == LearningStatus.Active.ToString() ? "Đang học" : "Nghỉ học";
                string status = student.Status == UserStatus.Active.ToString() ? "Hoạt động" : "Ngưng hoạt động";
                studentDt.Rows.Add(student.UserId, student.Email, student.FullName, identityNumber, birthDate
                    , student.Password, student.Gender, student.Department
                    , student.AdmissionDate.ToString("dd/MM/yyyy"), learningStatus, status);
            }
            studentTable.DataSource = studentDt;
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string identityNumber = txtIdentify.Text;
            DateTime birthDate = birthDatePicker.Value;
            DateTime admissionDate = admissionDatePicker.Value;
            string department = cbDepartment.SelectedItem.ToString();
            string gender = cbGender.SelectedItem.ToString();
            string status = cbStatus.SelectedItem.ToString() == "Hoạt động" ? "Active" : "Deactive";
            string learningStatus = cbLearningStatus.SelectedItem.ToString() == "Đang học" ? "Active" : "Deactive";
            try
            {
                var result = studentDAO.Add(new Student()
                {
                    AdmissionDate = admissionDate,
                    Email = email,
                    Password = password,
                    FullName = fullName,
                    IdentityNumber = identityNumber,
                    BirthDate = birthDate,
                    Department = department,
                    Gender = gender,
                    LearningStatus = learningStatus,
                    Status = status
                });
                if (result.Item1)
                {
                    ClearField();
                    UpdateStudentList();
                    MessageBox.Show(result.Item2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Item2, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa thêm thủ tục vào database, hãy kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateUserBtn_Click(object sender, EventArgs e)
        {
            if (studentTable.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để chỉnh sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = txtId.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string identityNumber = txtIdentify.Text;
            DateTime birthDate = birthDatePicker.Value;
            DateTime admissionDate = admissionDatePicker.Value;
            string department = cbDepartment.SelectedItem.ToString();
            string gender = cbGender.SelectedItem.ToString();
            string status = cbStatus.SelectedItem.ToString() == "Hoạt động" ? "Active" : "Deactive";
            string learningStatus = cbLearningStatus.SelectedItem.ToString() == "Đang học" ? "Active" : "Deactive";
            int userId = int.Parse(id);
            var existStudent = studentDAO.GetStudentById(userId);
            if (existStudent == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var result = studentDAO.Update(new Student()
                {
                    UserId = userId,
                    AdmissionDate = admissionDate,
                    Email = email,
                    Password = password,
                    FullName = fullName,
                    IdentityNumber = identityNumber,
                    BirthDate = birthDate,
                    Department = department,
                    Gender = gender,
                    LearningStatus = learningStatus,
                    Status = status,
                });
                if (result.Item1)
                {
                    ClearField();
                    UpdateStudentList();
                    MessageBox.Show(result.Item2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Item2, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa thêm thủ tục vào database, hãy kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (studentTable.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = txtId.Text;
            int userId = int.Parse(id);
            var existStudent = studentDAO.GetStudentById(userId);
            if (existStudent == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var result = studentDAO.Delete(userId);
                if (result.Item1)
                {
                    ClearField();
                    UpdateStudentList();
                    MessageBox.Show(result.Item2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Item2, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa thêm thủ tục vào database, hãy kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void studentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (studentTable.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = studentTable.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells[0].Value);
            Student student = studentDAO.GetStudentById(userId);
            if (student == null)
            {
                return;
            }
            txtId.Text = student.UserId.ToString();
            txtEmail.Text = student.Email;
            txtPassword.Text = student.Password;
            if (student.BirthDate != null)
            {
                birthDatePicker.Value = student.BirthDate.Value;
            }
            if (student.IdentityNumber != null)
            {
                txtIdentify.Text = student.IdentityNumber;
            }
            txtFullName.Text = student.FullName;
            admissionDatePicker.Value = student.AdmissionDate;
            cbGender.SelectedItem = student.Gender;
            cbDepartment.SelectedItem = student.Department;
            if (student.LearningStatus == LearningStatus.Active.ToString())
            {
                cbLearningStatus.SelectedIndex = 0;
            }
            else
            {
                cbLearningStatus.SelectedIndex = 1;
            }
            if (student.Status == LearningStatus.Active.ToString())
            {
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                cbStatus.SelectedIndex = 1;
            }
        }

        private void viewScheduleBtn_Click(object sender, EventArgs e)
        {
            if (studentTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xem thời khóa biểu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = studentTable.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells[0].Value);
            new ScheduleForm(this, userId).Show();
            Visible = false;
        }

        private void viewGpaBtn_Click(object sender, EventArgs e)
        {
            if (studentTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xem thời khóa biểu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = studentTable.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells[0].Value);
            try
            {
                var statistic = studentDAO.GetStudentGpaStatistic(userId);
                if (statistic == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin điểm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                new GpaForm(this, statistic).Show();
                Visible = false;
            } catch(Exception ex)
            {
                MessageBox.Show("Chưa thêm thủ tục vào database, hãy kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
