using Education_System_GUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Education_System_GUI
{
    public partial class GpaForm : Form
    {
        StudentGpaStatistic statistic;
        Form parent;
        public GpaForm(Form parent, StudentGpaStatistic statistic)
        {
            InitializeComponent();
            this.parent = parent;
            this.statistic = statistic;
            LoadData();
        }

        private void LoadData()
        {
            if(statistic.TotalGPA == -1 || statistic.TotalCredits == -1 || string.IsNullOrEmpty(statistic.CourseDetails))
            {
                txtCourseDetails.Text = "Chưa có!";
                txtCredits.Text = "Chưa có!";
                txtGPA.Text = "Chưa có!";
            } else
            {
                txtCourseDetails.Text = statistic.CourseDetails;
                txtCredits.Text = statistic.TotalCredits.ToString();
                txtGPA.Text = statistic.TotalGPA.ToString("0");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GpaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }
    }
}
