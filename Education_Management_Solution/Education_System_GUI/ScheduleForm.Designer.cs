namespace Education_System_GUI
{
    partial class ScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            table = new DataGridView();
            txtSemester = new TextBox();
            searchBtn = new Button();
            datePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label3 = new Label();
            txtCourse = new TextBox();
            label4 = new Label();
            txtLesson = new TextBox();
            label5 = new Label();
            txtClass = new TextBox();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // table
            // 
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToResizeColumns = false;
            table.AllowUserToResizeRows = false;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Location = new Point(12, 125);
            table.MultiSelect = false;
            table.Name = "table";
            table.ReadOnly = true;
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table.Size = new Size(818, 367);
            table.TabIndex = 1;
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(12, 85);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(75, 23);
            txtSemester.TabIndex = 2;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(372, 84);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(86, 24);
            searchBtn.TabIndex = 3;
            searchBtn.Text = "Tìm kiếm";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // datePicker
            // 
            datePicker.CustomFormat = "dd/MM/yyyy";
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.Location = new Point(12, 35);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(180, 23);
            datePicker.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(47, 21);
            label1.TabIndex = 5;
            label1.Text = "Ngày";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 6;
            label2.Text = "Học kỳ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(93, 60);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 8;
            label3.Text = "Môn học";
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(93, 84);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(87, 23);
            txtCourse.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(186, 61);
            label4.Name = "label4";
            label4.Size = new Size(64, 21);
            label4.TabIndex = 10;
            label4.Text = "Tiết học";
            // 
            // txtLesson
            // 
            txtLesson.Location = new Point(186, 85);
            txtLesson.Name = "txtLesson";
            txtLesson.Size = new Size(87, 23);
            txtLesson.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(279, 60);
            label5.Name = "label5";
            label5.Size = new Size(66, 21);
            label5.TabIndex = 12;
            label5.Text = "Lớp học";
            // 
            // txtClass
            // 
            txtClass.Location = new Point(279, 84);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(87, 23);
            txtClass.TabIndex = 11;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(732, 66);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(98, 42);
            backBtn.TabIndex = 13;
            backBtn.Text = "Trở về";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 504);
            Controls.Add(backBtn);
            Controls.Add(label5);
            Controls.Add(txtClass);
            Controls.Add(label4);
            Controls.Add(txtLesson);
            Controls.Add(label3);
            Controls.Add(txtCourse);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datePicker);
            Controls.Add(searchBtn);
            Controls.Add(txtSemester);
            Controls.Add(table);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xem lịch học";
            FormClosing += ScheduleForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table;
        private TextBox txtSemester;
        private Button searchBtn;
        private DateTimePicker datePicker;
        private Label label1;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label3;
        private TextBox txtCourse;
        private Label label4;
        private TextBox txtLesson;
        private Label label5;
        private TextBox txtClass;
        private Button backBtn;
    }
}