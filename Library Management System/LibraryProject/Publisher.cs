using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LibraryProject
{
    public partial class Publisher : Form
    {
        public Publisher()
        {
            InitializeComponent();
            load();

        }
        ConnectionClass conClass = new ConnectionClass();
        bool mode = true;
        string sql;
        SqlDataReader read;
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        SqlCommand SqlC;
        string id;

        public void load()
        {
            try
            {
                sql = "select * from Publisher";
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2]);
                }
                conClass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getID(String ID)
        {
            sql = "select * from Publisher where P_ID = '" +ID + "' ";
            conClass.OpenConection();
            read = conClass.DataReader(sql);
            while (read.Read())
            {
                textBox1.Text = read[0].ToString();
                textBox2.Text = read[1].ToString();
                //txtlname.Text = read[2].ToString();
                textBox4.Text = read[2].ToString();
                //txtphone.Text = read[4].ToString();
            }
            conClass.CloseConnection();
        }
        //public DataTable LOGIN2(string id, string pwd)
        //{
        //    DAL.DataACesslyer DL = new DAL.DataACesslyer();
        //    SqlParameter[] paramm = new SqlParameter[2];
        //    paramm[0] = new SqlParameter("@id", SqlDbType.VarChar);
        //    paramm[0].Value = id;
        //    paramm[0] = new SqlParameter("@pwd", SqlDbType.VarChar);
        //    paramm[0].Value = pwd;
        //    DL.open();
        //    DataTable dt = new DataTable();
        //    dt = DL.selectdata("SP_LOGIN", paramm);
        //    return dt;

        //}
        //public Publisher()
        //{
        //    InitializeComponent();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            
            classpublisher m = new classpublisher();
            m.id = textBox1.Text;
            m.F_Name = textBox2.Text;
           m. Address = textBox4.Text;
            if (mode == true && m.id.Length > 0)
            {
                try
                { 
                sql = "insert into Publisher values (@0,@1,@2)";
                con.Open();
                SqlC = new SqlCommand(sql, con);
                SqlC.Parameters.AddWithValue("0", m.id);
                SqlC.Parameters.AddWithValue("1", m.F_Name);
               
                SqlC.Parameters.AddWithValue("2", m.Address);
                
                
                
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Recorded ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                textBox1.Clear();
                textBox2.Clear();
                //txtlname.Clear();
                textBox4.Clear();
                //txtphone.Clear();
            }
            else if (mode == false && m.id.Length > 0)
            {
                try
                { 
                sql = "update Publisher set p_ID =@0 ,name=@1,p_Address=@2";
                con.Open();
                SqlC = new SqlCommand(sql, con);
                SqlC.Parameters.AddWithValue("0", m.id);
                SqlC.Parameters.AddWithValue("1", m.F_Name);
                
                SqlC.Parameters.AddWithValue("2", m.Address);
                
               
                
                
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Updated ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                textBox1.Clear();
                textBox2.Clear();
                
                textBox4.Clear();
                //txtphone.Clear();
                button1.Text = "Save";
                mode = true;
            }
            con.Close();
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
        //    //{
        //    //    mode = false;
        //    //    id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    //    getID(id);
        //    //    button1.Text = "Edit";

        //    //}
        //    //else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
        //    //{
        //    //    mode = false;
        //    //    id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    //    sql = "delete from Publisher where ID = '" + id + "' ";
        //    //    conClass.OpenConection();
        //    //    conClass.ExecuteQueries(sql);
        //    //    conClass.CloseConnection();
        //    //    MessageBox.Show("deleted......");
        //    //}
        //}

        private void Publisher_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            textBox4.Clear();

            button1.Text = "Save";
            mode = true;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    mode = false;
                    id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    getID(id);
                    button1.Text = "Edit";

                }
            
            
           
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    mode = false;
                    id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    sql = "delete from Publisher where P_ID = '" + id + "' ";
                    conClass.OpenConection();
                    conClass.ExecuteQueries(sql);
                    conClass.CloseConnection();
                    MessageBox.Show("deleted......");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choose ch = new choose();
            ch.Show();
            this.Close();

        }
    }
}


