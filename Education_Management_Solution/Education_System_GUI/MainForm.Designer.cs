namespace Education_System_GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPage1 = new TabPage();
            label11 = new Label();
            cbStatus = new ComboBox();
            viewScheduleBtn = new Button();
            label10 = new Label();
            admissionDatePicker = new DateTimePicker();
            label9 = new Label();
            cbLearningStatus = new ComboBox();
            label7 = new Label();
            birthDatePicker = new DateTimePicker();
            label8 = new Label();
            cbDepartment = new ComboBox();
            label6 = new Label();
            cbGender = new ComboBox();
            txtIdentify = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            txtId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            addUserBtn = new Button();
            updateUserBtn = new Button();
            deleteUserBtn = new Button();
            studentTable = new DataGridView();
            tabControl1 = new TabControl();
            viewGpaBtn = new Button();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentTable).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(viewGpaBtn);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(cbStatus);
            tabPage1.Controls.Add(viewScheduleBtn);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(admissionDatePicker);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(cbLearningStatus);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(birthDatePicker);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(cbDepartment);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(cbGender);
            tabPage1.Controls.Add(txtIdentify);
            tabPage1.Controls.Add(txtPassword);
            tabPage1.Controls.Add(txtEmail);
            tabPage1.Controls.Add(txtFullName);
            tabPage1.Controls.Add(txtId);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(addUserBtn);
            tabPage1.Controls.Add(updateUserBtn);
            tabPage1.Controls.Add(deleteUserBtn);
            tabPage1.Controls.Add(studentTable);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(958, 525);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quản lý sinh viên";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(8, 128);
            label11.Name = "label11";
            label11.Size = new Size(82, 21);
            label11.TabIndex = 28;
            label11.Text = "Trạng Thái";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(8, 152);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(167, 25);
            cbStatus.TabIndex = 27;
            // 
            // viewScheduleBtn
            // 
            viewScheduleBtn.Location = new Point(845, 327);
            viewScheduleBtn.Name = "viewScheduleBtn";
            viewScheduleBtn.Size = new Size(98, 42);
            viewScheduleBtn.TabIndex = 26;
            viewScheduleBtn.Text = "Xem lịch học";
            viewScheduleBtn.UseVisualStyleBackColor = true;
            viewScheduleBtn.Click += viewScheduleBtn_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(724, 10);
            label10.Name = "label10";
            label10.Size = new Size(115, 21);
            label10.TabIndex = 25;
            label10.Text = "Ngày nhập học";
            // 
            // admissionDatePicker
            // 
            admissionDatePicker.CustomFormat = "dd/MM/yyyy";
            admissionDatePicker.Format = DateTimePickerFormat.Custom;
            admissionDatePicker.Location = new Point(724, 34);
            admissionDatePicker.Name = "admissionDatePicker";
            admissionDatePicker.Size = new Size(221, 23);
            admissionDatePicker.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(724, 74);
            label9.Name = "label9";
            label9.Size = new Size(134, 21);
            label9.TabIndex = 23;
            label9.Text = "Trạng thái học tập";
            // 
            // cbLearningStatus
            // 
            cbLearningStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLearningStatus.Font = new Font("Segoe UI", 10F);
            cbLearningStatus.FormattingEnabled = true;
            cbLearningStatus.Location = new Point(724, 98);
            cbLearningStatus.Name = "cbLearningStatus";
            cbLearningStatus.Size = new Size(221, 25);
            cbLearningStatus.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(542, 10);
            label7.Name = "label7";
            label7.Size = new Size(80, 21);
            label7.TabIndex = 21;
            label7.Text = "Ngày sinh";
            // 
            // birthDatePicker
            // 
            birthDatePicker.Format = DateTimePickerFormat.Short;
            birthDatePicker.Location = new Point(542, 34);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.Size = new Size(167, 23);
            birthDatePicker.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(542, 74);
            label8.Name = "label8";
            label8.Size = new Size(45, 21);
            label8.TabIndex = 19;
            label8.Text = "Khoa";
            // 
            // cbDepartment
            // 
            cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDepartment.Font = new Font("Segoe UI", 10F);
            cbDepartment.FormattingEnabled = true;
            cbDepartment.Location = new Point(542, 98);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(167, 25);
            cbDepartment.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(358, 74);
            label6.Name = "label6";
            label6.Size = new Size(70, 21);
            label6.TabIndex = 15;
            label6.Text = "Giới tính";
            // 
            // cbGender
            // 
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.Font = new Font("Segoe UI", 10F);
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(358, 98);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(167, 25);
            cbGender.TabIndex = 14;
            // 
            // txtIdentify
            // 
            txtIdentify.Font = new Font("Segoe UI", 10F);
            txtIdentify.Location = new Point(358, 35);
            txtIdentify.Name = "txtIdentify";
            txtIdentify.Size = new Size(167, 25);
            txtIdentify.TabIndex = 13;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(173, 98);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(167, 25);
            txtPassword.TabIndex = 11;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(173, 35);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(167, 25);
            txtEmail.TabIndex = 9;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(8, 98);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(144, 25);
            txtFullName.TabIndex = 7;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(8, 35);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(144, 25);
            txtId.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(358, 11);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 12;
            label5.Text = "CCCD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(173, 74);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 10;
            label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(173, 11);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 8;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(8, 74);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 6;
            label2.Text = "Họ và tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(8, 11);
            label1.Name = "label1";
            label1.Size = new Size(117, 21);
            label1.TabIndex = 4;
            label1.Text = "Mã người dùng";
            // 
            // addUserBtn
            // 
            addUserBtn.Location = new Point(845, 183);
            addUserBtn.Name = "addUserBtn";
            addUserBtn.Size = new Size(98, 42);
            addUserBtn.TabIndex = 1;
            addUserBtn.Text = "Thêm";
            addUserBtn.UseVisualStyleBackColor = true;
            addUserBtn.Click += addUserBtn_Click;
            // 
            // updateUserBtn
            // 
            updateUserBtn.Location = new Point(845, 231);
            updateUserBtn.Name = "updateUserBtn";
            updateUserBtn.Size = new Size(98, 42);
            updateUserBtn.TabIndex = 2;
            updateUserBtn.Text = "Sửa";
            updateUserBtn.UseVisualStyleBackColor = true;
            updateUserBtn.Click += updateUserBtn_Click;
            // 
            // deleteUserBtn
            // 
            deleteUserBtn.Location = new Point(845, 279);
            deleteUserBtn.Name = "deleteUserBtn";
            deleteUserBtn.Size = new Size(98, 42);
            deleteUserBtn.TabIndex = 3;
            deleteUserBtn.Text = "Xoá";
            deleteUserBtn.UseVisualStyleBackColor = true;
            deleteUserBtn.Click += deleteUserBtn_Click;
            // 
            // studentTable
            // 
            studentTable.AllowUserToAddRows = false;
            studentTable.AllowUserToDeleteRows = false;
            studentTable.AllowUserToResizeColumns = false;
            studentTable.AllowUserToResizeRows = false;
            studentTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            studentTable.Location = new Point(6, 183);
            studentTable.MultiSelect = false;
            studentTable.Name = "studentTable";
            studentTable.ReadOnly = true;
            studentTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentTable.Size = new Size(818, 334);
            studentTable.TabIndex = 0;
            studentTable.CellClick += studentTable_CellClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(966, 553);
            tabControl1.TabIndex = 8;
            // 
            // viewGpaBtn
            // 
            viewGpaBtn.Location = new Point(845, 375);
            viewGpaBtn.Name = "viewGpaBtn";
            viewGpaBtn.Size = new Size(98, 42);
            viewGpaBtn.TabIndex = 29;
            viewGpaBtn.Text = "Xem điểm GPA";
            viewGpaBtn.UseVisualStyleBackColor = true;
            viewGpaBtn.Click += viewGpaBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 553);
            Controls.Add(tabControl1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)studentTable).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage1;
        private Button viewScheduleBtn;
        private Label label10;
        private DateTimePicker admissionDatePicker;
        private Label label9;
        private ComboBox cbLearningStatus;
        private Label label7;
        private DateTimePicker birthDatePicker;
        private Label label8;
        private ComboBox cbDepartment;
        private Label label6;
        private ComboBox cbGender;
        private TextBox txtIdentify;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private TextBox txtId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button addUserBtn;
        private Button updateUserBtn;
        private Button deleteUserBtn;
        private DataGridView studentTable;
        private TabControl tabControl1;
        private Label label11;
        private ComboBox cbStatus;
        private Button viewGpaBtn;
    }
}
