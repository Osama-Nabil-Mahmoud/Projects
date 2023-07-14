using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            load();
            LoadPublisher();
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
                sql = @"SELECT [B_ID]
                          ,[Title]
                          ,[Author]
                          ,[price]
                          ,[P_ID]
                          ,[Availability]
                      FROM [Library].[dbo].[books]";
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5]);
                }
                conClass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BooksClass b = new BooksClass();
            b.BookID = txt_book_Id.Text;
            b.Title = txt_title.Text;
            b.Author = txt_author.Text;
            b.Price = decimal.Parse(txt_price.Text);
            b.Availablity = txt_availablitiy.Text;
            b.Publisher_ID = ddl_publisher.SelectedValue?.ToString();

            if (mode == true && b.BookID.Length > 0)
            {
                sql = @"INSERT INTO [dbo].[books]
                               ([B_ID]
                               ,[Title]
                               ,[Author]
                               ,[price]
                               ,[Availability]
                               ,[P_ID])
                         VALUES
                               (@0,@1,@2,@3,@4,@5)";
                try
                {
                    con.Open();
                    SqlC = new SqlCommand(sql, con);
                    SqlC.Parameters.AddWithValue("0", b.BookID);
                    SqlC.Parameters.AddWithValue("1", b.Title);
                    SqlC.Parameters.AddWithValue("2", b.Author);
                    SqlC.Parameters.AddWithValue("3", b.Price);
                    SqlC.Parameters.AddWithValue("4", b.Availablity);
                    SqlC.Parameters.AddWithValue("5", b.Publisher_ID);
               
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Recorded ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txt_author.Clear();
                txt_availablitiy.Clear();
                txt_title.Clear();
                txt_book_Id.Clear();
                txt_price.Clear();
                ddl_publisher.SelectedIndex = -1;
            }
            else if (mode == false && b.BookID.Length > 0)
            {
                sql = @"UPDATE [dbo].[books]
                           SET [B_ID] = @0
                              ,[Title] = @1
                              ,[Author] = @2
                              ,[price] = @3
                              ,[Availability] = @4
                              ,[P_ID] = @5
                         WHERE [B_ID]=@6";
               
                try
                {
                    con.Open();
                    SqlC = new SqlCommand(sql, con);
                    SqlC.Parameters.AddWithValue("0", b.BookID);
                    SqlC.Parameters.AddWithValue("1", b.Title);
                    SqlC.Parameters.AddWithValue("2", b.Author);
                    SqlC.Parameters.AddWithValue("3", b.Price);
                    SqlC.Parameters.AddWithValue("4", b.Availablity);
                    SqlC.Parameters.AddWithValue("5", b.Publisher_ID);
                    SqlC.Parameters.AddWithValue("6", b.BookID);
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Updated ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txt_author.Clear();
                txt_availablitiy.Clear();
                txt_title.Clear();
                txt_book_Id.Clear();
                txt_price.Clear();
                ddl_publisher.SelectedIndex = -1;
                btn_book_save.Text = "Save";
                mode = true;
            }
            con.Close();
            load();
            LoadPublisher();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getID(id);
                btn_book_save.Text = "Edit";

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    mode = false;
                    id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    sql = "delete from Books where [B_ID] = '" + id + "' ";
                    conClass.OpenConection();
                    conClass.ExecuteQueries(sql);
                    conClass.CloseConnection();
                    MessageBox.Show("deleted......");
                    load();
                    LoadPublisher();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void getID(String ID)
        {
            sql = @"SELECT [B_ID]
                          ,[Title]
                          ,[Author]
                          ,[price]
                          ,[Availability]
                          ,[P_ID]
                      FROM [Library].[dbo].[books] WHERE [B_ID] = '" + ID + "' ";
            try
            {
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                string P_ID = "0";
                while (read.Read())
                {
                    txt_book_Id.Text = read[0].ToString();
                    txt_title.Text = read[1].ToString();
                    txt_author.Text = read[2].ToString();
                    txt_price.Text = read[3].ToString();
                    txt_availablitiy.Text = read[4].ToString();
                    P_ID = read[5].ToString();
                }
                conClass.CloseConnection();
                LoadPublisher(P_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadPublisher(string Id = null)
        {
            sql = @"SELECT
                      [p_ID],[name]
                  FROM [Library].[dbo].[publisher]";
            try
            {
                conClass.OpenConection();
                read = conClass.DataReader(sql);
                DataTable dt = new DataTable();
                dt.Load(read);
                ddl_publisher.DataSource = dt;
                ddl_publisher.DisplayMember = "name";
                ddl_publisher.ValueMember = "p_ID";
                if (!string.IsNullOrEmpty(id)) ddl_publisher.SelectedValue = id; else ddl_publisher.SelectedIndex = -1;
                ddl_publisher.DataSource = dt;
                conClass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_author.Clear();
            txt_availablitiy.Clear();
            txt_title.Clear();
            txt_book_Id.Clear();
            txt_price.Clear();
            ddl_publisher.SelectedIndex = -1;
            btn_book_save.Text = "Save";
            mode = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var bookId = txt_book_Id.Text;
            if (bookId.Length > 0)
            {
                sql = @"DELETE FROM [dbo].[books] WHERE [B_ID] = @0";
                
                try
                {
                    con.Open();
                    SqlC = new SqlCommand(sql, con);
                    SqlC.Parameters.AddWithValue("0", bookId);
                    SqlC.ExecuteNonQuery();
                    MessageBox.Show(" Deleted ...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txt_author.Clear();
                txt_availablitiy.Clear();
                txt_title.Clear();
                txt_book_Id.Clear();
                txt_price.Clear();
                ddl_publisher.SelectedIndex = -1;
                btn_book_save.Text = "Save";
                mode = true;
            }
            con.Close();
            load();
            LoadPublisher();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choose ch = new choose();
            ch.Show();
            this.Close();
        }
    }
}
