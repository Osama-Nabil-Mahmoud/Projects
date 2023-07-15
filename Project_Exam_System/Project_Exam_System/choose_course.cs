using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_Exam_System
{
    public partial class choose_course : Form
    {
        public choose_course()
        {
            InitializeComponent();
            SqlConnection conn2 = new SqlConnection("Data Source=.;Initial Catalog= exam-system;Integrated Security=True");
            SqlCommand cmd3 = new SqlCommand("exec show_name2", conn2);
            conn2.Open();
            student_name.Text = Convert.ToString(cmd3.ExecuteScalar());
            conn2.Close();
        }

        private void choose_course_Load(object sender, EventArgs e)
        {

        }

        public static string sub_name = "";
   
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sub_name = "sql";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sub_name = "python";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sub_name = "oop";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            sub_name = "c#";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn2 = new SqlConnection("Data Source=.;Initial Catalog=exam-system;Integrated Security=True");
            SqlCommand cmd_course = new SqlCommand("insert_selected_course '" + sub_name + "'", conn2);
            conn2.Open();
            cmd_course.ExecuteNonQuery();
            conn2.Close();
            this.Hide();
            exam ex = new exam();
            ex.Show();
        }

   
    }
}
