using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string username = textBox1.Text;
                string password = textBox2.Text;



                if (((this.textBox1.Text == "admin") || (this.textBox1.Text == "Admin")) && ((this.textBox2.Text == "admin") || (this.textBox2.Text == "Admin")))
                {



                    MessageBox.Show("Welcome " + username);
                    choose cho = new choose();
                    cho.ShowDialog();
                    this.Hide();
                }
                else
                    MessageBox.Show("Please Enter the right user and password");

            
        }
    }
}
