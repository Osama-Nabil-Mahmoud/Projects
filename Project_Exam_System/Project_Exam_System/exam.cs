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
    public partial class exam : Form
    {
        private const CommandType storedProcedure = CommandType.StoredProcedure;
        string submitted_answer1;
        string submitted_answer2;
        string submitted_answer3;
        string submitted_answer4;
        string submitted_answer5;
        string submitted_answer6;
        string submitted_answer7;
        string submitted_answer8;
        string submitted_answer9;
        string submitted_answer10;

        List<int> fetched_ques_array = new List<int>();
       int exam_id = 0;
        public exam()
        {
            InitializeComponent();

            // generate random question using stored procedure and fetch ques id into array 

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=exam-system;Integrated Security=True");
                    conn.Open();
                    String query = "exec rand_ques'" + choose_course.sub_name + "' ,7,3";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        fetched_ques_array.Add(int.Parse(dr["ques_id"].ToString()));
                    }


            // get ques header , choices and add to form 

            String query1 = " get_ques_choices '" + fetched_ques_array[0] + "' ";
            cmd = new SqlCommand(query1, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q1.Text = dr["ques_header"].ToString();
                q1_op1.Text = dr["ques_choice1"].ToString();
                q1_op2.Text = dr["ques_choice2"].ToString();
                q1_op3.Text = dr["ques_choice3"].ToString();
                q1_op4.Text = dr["ques_choice4"].ToString();

            }

            String query2 = "get_ques_choices'" + fetched_ques_array[1] + "' ";
            cmd = new SqlCommand(query2, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q2.Text = dr["ques_header"].ToString();
                q2_op1.Text = dr["ques_choice1"].ToString();
                q2_op2.Text = dr["ques_choice2"].ToString();
                q2_op3.Text = dr["ques_choice3"].ToString();
                q2_op4.Text = dr["ques_choice4"].ToString();

            }

            String query3 = "get_ques_choices'" + fetched_ques_array[2] + "' ";
            cmd = new SqlCommand(query3, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q3.Text = dr["ques_header"].ToString();
                q3_op1.Text = dr["ques_choice1"].ToString();
                q3_op2.Text = dr["ques_choice2"].ToString();
                q3_op3.Text = dr["ques_choice3"].ToString();
                q3_op4.Text = dr["ques_choice4"].ToString();

            }

            String query4 = "get_ques_choices'" + fetched_ques_array[3] + "' ";
            cmd = new SqlCommand(query4, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q4.Text = dr["ques_header"].ToString();
                q4_op1.Text = dr["ques_choice1"].ToString();
                q4_op2.Text = dr["ques_choice2"].ToString();
                q4_op3.Text = dr["ques_choice3"].ToString();
                q4_op4.Text = dr["ques_choice4"].ToString();

            }

            String query5 = "get_ques_choices'" + fetched_ques_array[4] + "' ";
            cmd = new SqlCommand(query5, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q5.Text = dr["ques_header"].ToString();
                q5_op1.Text = dr["ques_choice1"].ToString();
                q5_op2.Text = dr["ques_choice2"].ToString();
                q5_op3.Text = dr["ques_choice3"].ToString();
                q5_op4.Text = dr["ques_choice4"].ToString();
            }


            String query6 = "get_ques_choices'" + fetched_ques_array[5] + "' ";
            cmd = new SqlCommand(query6, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q6.Text = dr["ques_header"].ToString();
                q6_op1.Text = dr["ques_choice1"].ToString();
                q6_op2.Text = dr["ques_choice2"].ToString();
                q6_op3.Text = dr["ques_choice3"].ToString();
                q6_op4.Text = dr["ques_choice4"].ToString();
            }

            String query7 = "get_ques_choices'" + fetched_ques_array[6] + "' ";
            cmd = new SqlCommand(query7, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q7.Text = dr["ques_header"].ToString();
                q7_op1.Text = dr["ques_choice1"].ToString();
                q7_op2.Text = dr["ques_choice2"].ToString();
                q7_op3.Text = dr["ques_choice3"].ToString();
                q7_op4.Text = dr["ques_choice4"].ToString();
            }


            String query8 = "get_ques_choices'" + fetched_ques_array[7] + "' ";
            cmd = new SqlCommand(query8, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q8.Text = dr["ques_header"].ToString();
                q8_op1.Text = dr["ques_choice1"].ToString();
                q8_op2.Text = dr["ques_choice2"].ToString();
                q8_op3.Text = dr["ques_choice3"].ToString();
                q8_op4.Text = dr["ques_choice4"].ToString();
            }




            String query9 = "get_ques_choices'" + fetched_ques_array[8] + "' ";
            cmd = new SqlCommand(query9, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q9.Text = dr["ques_header"].ToString();
                q9_op1.Text = dr["ques_choice1"].ToString();
                q9_op2.Text = dr["ques_choice2"].ToString();
                q9_op3.Text = dr["ques_choice3"].ToString();
                q9_op4.Text = dr["ques_choice4"].ToString();
            }

            String query10 = "get_ques_choices'" + fetched_ques_array[9] + "' ";
            cmd = new SqlCommand(query10, conn);
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                q10.Text = dr["ques_header"].ToString();
                q10_op1.Text = dr["ques_choice1"].ToString();
                q10_op2.Text = dr["ques_choice2"].ToString();
                q10_op3.Text = dr["ques_choice3"].ToString();
                q10_op4.Text = dr["ques_choice4"].ToString();
            }

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }





       


        private void exam_Load(object sender, EventArgs e)
        {

        }

        public static int final_score = 0;

        // check student answer and assign it to var 
        private void chk_q1()
        {
            if (q1_op1.Checked)
                submitted_answer1 = q1_op1.Text;
            if (q1_op2.Checked)
                submitted_answer1 = q1_op2.Text;
            if (q1_op3.Checked)
                submitted_answer1 = q1_op3.Text;
            if (q1_op4.Checked)
                submitted_answer1 = q1_op4.Text;
        }
        private void chk_q2()
        {
            if (q2_op1.Checked)
                submitted_answer2 = q2_op1.Text;
            if (q2_op2.Checked)
                submitted_answer2 = q2_op2.Text;
            if (q2_op3.Checked)
                submitted_answer2 = q2_op3.Text;
            if (q2_op4.Checked)
                submitted_answer2 = q2_op4.Text;

        }
        private void chk_q3()
        {
            if (q3_op1.Checked)
                submitted_answer3 = q3_op1.Text;
            if (q3_op2.Checked)
                submitted_answer3 = q3_op2.Text;
            if (q3_op3.Checked)
                submitted_answer3 = q3_op3.Text;
            if (q3_op4.Checked)
                submitted_answer3 = q3_op4.Text;
        }
        private void chk_q4()
        {

            if (q4_op1.Checked)
                submitted_answer4 = q4_op1.Text;
            if (q4_op2.Checked)
                submitted_answer4 = q4_op2.Text;
            if (q4_op3.Checked)
                submitted_answer4 = q4_op3.Text;
            if (q4_op4.Checked)
                submitted_answer4 = q4_op4.Text;
        }
        private void chk_q5()
        {
            if (q5_op1.Checked)
                submitted_answer5 = q5_op1.Text;
            if (q5_op2.Checked)
                submitted_answer5 = q5_op2.Text;
            if (q5_op3.Checked)
                submitted_answer5 = q5_op3.Text;
            if (q5_op4.Checked)
                submitted_answer5 = q5_op4.Text;
        }
        private void chk_q6()
        {

            if (q6_op1.Checked)
                submitted_answer6 = q6_op1.Text;
            if (q6_op2.Checked)
                submitted_answer6 = q6_op2.Text;
            if (q6_op3.Checked)
                submitted_answer6 = q6_op3.Text;
            if (q6_op4.Checked)
                submitted_answer6 = q6_op4.Text;
        }
        private void chk_q7()
        {
            if (q7_op1.Checked)
                submitted_answer7 = q7_op1.Text;
            if (q7_op2.Checked)
                submitted_answer7 = q7_op2.Text;
            if (q7_op3.Checked)
                submitted_answer7 = q7_op3.Text;
            if (q7_op4.Checked)
                submitted_answer7 = q7_op4.Text;
        }
        private void chk_q8()
        {
            if (q8_op1.Checked)
                submitted_answer8 = q8_op1.Text;
            if (q8_op2.Checked)
                submitted_answer8 = q8_op2.Text;
            if (q8_op3.Checked)
                submitted_answer8 = q8_op3.Text;
            if (q8_op4.Checked)
                submitted_answer8 = q8_op4.Text;
        }
        private void chk_q9()
        {
            if (q9_op1.Checked)
                submitted_answer9 = q9_op1.Text;
            if (q9_op2.Checked)
                submitted_answer9 = q9_op2.Text;
            if (q9_op3.Checked)
                submitted_answer9 = q9_op3.Text;
            if (q9_op4.Checked)
                submitted_answer9 = q9_op4.Text;
        }
        private void chk_q10()
        {
            if (q10_op1.Checked)
                submitted_answer10 = q10_op1.Text;
            if (q10_op2.Checked)
                submitted_answer10 = q10_op2.Text;
            if (q10_op3.Checked)
                submitted_answer10 = q10_op3.Text;
            if (q10_op4.Checked)
                submitted_answer10 = q10_op4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chk_q1();
            chk_q2();
            chk_q3();
            chk_q4();
            chk_q5();
            chk_q6();
            chk_q7();
            chk_q8();
            chk_q9();
            chk_q10();

   
            SqlConnection conn2 = new SqlConnection("Data Source=.;Initial Catalog=exam-system;Integrated Security=True");

            // insert new exam id into exam table using stored
            SqlCommand saving_exam_id = new SqlCommand("saving_exam_id", conn2);

            // save each ques id in this exam and student answer for this ques into exam taken table 

            SqlCommand saving_ques1 = new SqlCommand("saving_ques'" + fetched_ques_array[0] + "','" + submitted_answer1 + "'", conn2);
            SqlCommand saving_ques2 = new SqlCommand("saving_ques'" + fetched_ques_array[1] + "','" + submitted_answer2 + "'", conn2);
            SqlCommand saving_ques3 = new SqlCommand("saving_ques'" + fetched_ques_array[2] + "','" + submitted_answer3 + "'", conn2);
            SqlCommand saving_ques4 = new SqlCommand("saving_ques'" + fetched_ques_array[3] + "','" + submitted_answer4 + "'", conn2);
            SqlCommand saving_ques5 = new SqlCommand("saving_ques'" + fetched_ques_array[4] + "','" + submitted_answer5 + "'", conn2);
            SqlCommand saving_ques6 = new SqlCommand("saving_ques'" + fetched_ques_array[5] + "','" + submitted_answer6 + "'", conn2);
            SqlCommand saving_ques7 = new SqlCommand("saving_ques'" + fetched_ques_array[6] + "','" + submitted_answer7 + "'", conn2);
            SqlCommand saving_ques8 = new SqlCommand("saving_ques'" + fetched_ques_array[7] + "','" + submitted_answer8 + "'", conn2);
            SqlCommand saving_ques9 = new SqlCommand("saving_ques'" + fetched_ques_array[8] + "','" + submitted_answer9 + "'", conn2);
            SqlCommand saving_ques10 = new SqlCommand("saving_ques'" + fetched_ques_array[9] + "','" + submitted_answer10 + "'", conn2);


            conn2.Open();
            saving_exam_id.ExecuteNonQuery();
            saving_ques1.ExecuteNonQuery();
            saving_ques2.ExecuteNonQuery();
            saving_ques3.ExecuteNonQuery();
            saving_ques4.ExecuteNonQuery();
            saving_ques5.ExecuteNonQuery();
            saving_ques6.ExecuteNonQuery();
            saving_ques7.ExecuteNonQuery();
            saving_ques8.ExecuteNonQuery();
            saving_ques9.ExecuteNonQuery();
            saving_ques10.ExecuteNonQuery();


            // get final score 
            SqlCommand exam_score = new SqlCommand("exam_final_score", conn2);
            exam_score.CommandType = storedProcedure;
            exam_score.Parameters.Add("@st_mark", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            exam_score.ExecuteScalar();
            final_score = Convert.ToInt32(exam_score.Parameters["@st_mark"].Value) * 10 ;


            conn2.Close();
            this.Hide();
            view_result obj = new view_result();
            obj.Show();

            
        }
    }
}
