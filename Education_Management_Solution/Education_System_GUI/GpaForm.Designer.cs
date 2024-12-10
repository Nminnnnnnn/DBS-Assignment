namespace Education_System_GUI
{
    partial class GpaForm
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
            backBtn = new Button();
            txtCourseDetails = new RichTextBox();
            label2 = new Label();
            txtCredits = new TextBox();
            label1 = new Label();
            txtGPA = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Location = new Point(307, 383);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(98, 42);
            backBtn.TabIndex = 14;
            backBtn.Text = "Trở về";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // txtCourseDetails
            // 
            txtCourseDetails.Location = new Point(12, 171);
            txtCourseDetails.Name = "txtCourseDetails";
            txtCourseDetails.ReadOnly = true;
            txtCourseDetails.Size = new Size(393, 206);
            txtCourseDetails.TabIndex = 15;
            txtCourseDetails.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 17;
            label2.Text = "Tổng số tín chỉ";
            // 
            // txtCredits
            // 
            txtCredits.Location = new Point(12, 34);
            txtCredits.Name = "txtCredits";
            txtCredits.ReadOnly = true;
            txtCredits.Size = new Size(228, 23);
            txtCredits.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 72);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 19;
            label1.Text = "GPA";
            // 
            // txtGPA
            // 
            txtGPA.Location = new Point(12, 96);
            txtGPA.Name = "txtGPA";
            txtGPA.ReadOnly = true;
            txtGPA.Size = new Size(228, 23);
            txtGPA.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 147);
            label3.Name = "label3";
            label3.Size = new Size(126, 21);
            label3.TabIndex = 20;
            label3.Text = "Thông tin chi tiết";
            // 
            // GpaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 437);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtGPA);
            Controls.Add(label2);
            Controls.Add(txtCredits);
            Controls.Add(txtCourseDetails);
            Controls.Add(backBtn);
            Name = "GpaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xem điểm GPA";
            FormClosing += GpaForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backBtn;
        private RichTextBox txtCourseDetails;
        private Label label2;
        private TextBox txtCredits;
        private Label label1;
        private TextBox txtGPA;
        private Label label3;
    }
}