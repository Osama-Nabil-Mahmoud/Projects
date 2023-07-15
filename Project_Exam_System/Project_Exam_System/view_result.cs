using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Exam_System
{
    public partial class view_result : Form
    {

        public view_result()
        {
            InitializeComponent();

            label1.Text = exam.final_score.ToString() + " % "; 
        }



        Timer timer;
        int counter = 5; 

        private void view_result_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer.Stop();
                this.Close();
                login obj = new login();
                obj.Show();
            }

        }

       


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
