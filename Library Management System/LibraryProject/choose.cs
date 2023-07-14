using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class choose : Form
    {
        public choose()
        {
            InitializeComponent();
            load();
        }
        ConnectionClass conClass = new ConnectionClass();
        string sql;
        SqlDataReader read;
        public void load()
        {
            try
            {
                sql = "select * from memberBorrow";
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4],read[5]);
                }
                conClass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Books Bk = new Books();
            Bk.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Member m = new Member();
            m.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Publisher p = new Publisher();
            p.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            borrow b = new borrow();
            b.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
