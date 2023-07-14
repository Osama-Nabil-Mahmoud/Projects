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
    public partial class Member : Form
    {
        
        public Member()
        {
            InitializeComponent();
            load();
            
        }
        ConnectionClass conClass = new ConnectionClass();
        bool mode = true;
        string sql;
        SqlDataReader read;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Library;Integrated Security=True");
        SqlCommand SqlC;
        string id;

        public void load()
        {
            try
            {
                sql = "select * from member";
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4]);
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
            try
            {
                sql = "select * from Member where ID = '" + ID + "' ";
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                while (read.Read())
                {
                    txtid.Text = read[0].ToString();
                    txtfname.Text = read[1].ToString();
                    txtlname.Text = read[2].ToString();
                    txtaddress.Text = read[3].ToString();
                    txtphone.Text = read[4].ToString();
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
            MemeberClass m = new MemeberClass();
            m.id = txtid.Text;
            m.F_Name = txtfname.Text;
            m.L_Name = txtlname.Text;
            m.Address = txtaddress.Text;
            m.Phone = txtphone.Text;
            if(mode == true && m.id.Length>0)
            {
                try
                    {
                    sql = "insert into Member values (@0,@1,@2,@3,@4)";
                    con.Open();
                    SqlC = new SqlCommand(sql, con);
                    SqlC.Parameters.AddWithValue("0" , m.id);
                    SqlC.Parameters.AddWithValue("1", m.F_Name);
                    SqlC.Parameters.AddWithValue("2", m.L_Name);
                    SqlC.Parameters.AddWithValue("3", m.Address);
                    SqlC.Parameters.AddWithValue("4", m.Phone);
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Recorded ...");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtid.Clear();
                txtfname.Clear();
                txtlname.Clear();
                txtaddress.Clear();
                txtphone.Clear();
            }
            else if(mode == false && m.id.Length > 0)
            {
                try
                {
                    sql = "update Member set ID =@0 ,F_Name=@1,L_Name=@2,Address=@3,phone=@4 where ID=@5";
                    con.Open();
                    SqlC = new SqlCommand(sql, con);
                    SqlC.Parameters.AddWithValue("0", m.id);
                    SqlC.Parameters.AddWithValue("1", m.F_Name);
                    SqlC.Parameters.AddWithValue("2", m.L_Name);
                    SqlC.Parameters.AddWithValue("3", m.Address);
                    SqlC.Parameters.AddWithValue("4", m.Phone);
                    SqlC.Parameters.AddWithValue("5", id);
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Updated ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtid.Clear();
                txtfname.Clear();
                txtlname.Clear();
                txtaddress.Clear();
                txtphone.Clear();
                save.Text = "Save";
                mode = true;
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getID(id);
                save.Text = "Edit";

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    mode = false;
                    id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    sql = "delete from Member where ID = '" + id + "' ";
                    conClass.OpenConection();
                    conClass.ExecuteQueries(sql);
                    conClass.CloseConnection();
                    MessageBox.Show("deleted......");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtfname.Clear();
            txtlname.Clear();
            txtaddress.Clear();
            txtphone.Clear();
            save.Text = "Save";
            mode = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            choose ch = new choose();
            ch.Show();
            this.Close();
        }
    }
}
