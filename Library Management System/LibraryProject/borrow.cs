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
    public partial class borrow : Form
    {
        public borrow()
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
        string bookID;
        string memberID;

        public void load()
        {
            try
            {
                sql = "select * from Borrowed_By";
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3]);
                }
                conClass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getPrimaryKey(string bookID, string memberID)
        {
            try
            {
                sql = "select * from Borrowed_By where B_ID = '" + bookID + "' and  M_ID = '" + memberID + "' ";
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                while (read.Read())
                {
                    txtBookId.Text = read[0].ToString();
                    txtMemberId.Text = read[1].ToString();
                    txtDueDate.Text = read[2].ToString();
                    txtReturnDate.Text = read[3].ToString();
                }
                conClass.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            choose ch = new choose();
            ch.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bookId;
            string memberId;
            string DueDate;
            string ReturnDate;
            bookId = txtBookId.Text;
            memberId = txtMemberId.Text;
            DueDate = txtDueDate.Text;
            ReturnDate = txtReturnDate.Text;

            if (mode == true && bookId.Length > 0 && memberId.Length > 0)
            {
                sql = "insert into Borrowed_By values (@0,@1,@2,@3)";
                con.Open();
                
                try
                {
                    SqlC = new SqlCommand(sql, con);
                    SqlC.Parameters.AddWithValue("0", bookId);
                    SqlC.Parameters.AddWithValue("1", memberId);
                    SqlC.Parameters.AddWithValue("2", DueDate);
                    SqlC.Parameters.AddWithValue("3", ReturnDate);
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Recorded ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtBookId.Clear();
                txtMemberId.Clear();
                txtDueDate.Clear();
                txtReturnDate.Clear();
            }
            else if (mode == false &&  bookId.Length > 0 && memberId.Length > 0)
            {  
                try
                {
                    sql = "update Borrowed_By set B_ID =@0 , M_ID=@1 , Due_Date=@2 , Return_Date=@3 where B_ID=@4 and M_ID=@5";
                    con.Open();
                    SqlC = new SqlCommand(sql, con);
                    SqlC.Parameters.AddWithValue("0", bookId);
                    SqlC.Parameters.AddWithValue("1", memberId);
                    SqlC.Parameters.AddWithValue("2", DueDate);
                    SqlC.Parameters.AddWithValue("3", ReturnDate);
                    SqlC.Parameters.AddWithValue("4", bookID);
                    SqlC.Parameters.AddWithValue("5", memberID);
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Updated ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtBookId.Clear();
                txtMemberId.Clear();
                txtDueDate.Clear();
                txtReturnDate.Clear();
                Save.Text = "Save";
                mode = true;
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBookId.Clear();
            txtMemberId.Clear();
            txtDueDate.Clear();
            txtReturnDate.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                mode = false;
                bookID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                memberID = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                getPrimaryKey(bookID ,memberID);
                Save.Text = "Edit";

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    mode = false;
                    bookID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    memberID = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    sql = "delete from Borrowed_By where  B_ID = '" + bookID + "'and  M_ID = '" + memberID + "' ";
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
    }
    
}
