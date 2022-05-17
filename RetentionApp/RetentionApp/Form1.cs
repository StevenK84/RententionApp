using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace RetentionApp
{

    public partial class Form1 : MaterialForm
    {
       
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            string connString = "server = 127.0.0.1; user id = root;password=7U6F7P2fd4;database=seniorproject;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand getMentorName = conn.CreateCommand();
            getMentorName.CommandText = "Select Mentor_Fname FROM  t_mentor";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader reader = getMentorName.ExecuteReader();
            while (reader.Read())
            {

                materialComboBox3.Items.Add(reader["Mentor_Fname"].ToString());
                materialComboBox1.Items.Add(reader["Mentor_Fname"].ToString());
            }
            conn.Close();

            MySqlConnection connMentee = new MySqlConnection(connString);
            MySqlCommand getMenteeName = connMentee.CreateCommand();
            getMenteeName.CommandText = "Select Mentee_Fname From t_mentee";
            try
            {
                connMentee.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader readerMentee = getMenteeName.ExecuteReader();
            while (readerMentee.Read())
            {
                materialComboBox2.Items.Add(readerMentee["Mentee_Fname"].ToString());
                materialComboBox4.Items.Add(readerMentee["Mentee_Fname"].ToString());
            }

            connMentee.Close();

            MySqlConnection connActivity = new MySqlConnection(connString);
            MySqlCommand getActivity = connActivity.CreateCommand();
            getActivity.CommandText = "Select distinct activity From t_activity";
            try
            {
                connActivity.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader readerActivity = getActivity.ExecuteReader();
            while (readerActivity.Read())
            {
                materialComboBox5.Items.Add(readerActivity["activity"].ToString());
                materialComboBox6.Items.Add(readerActivity["activity"].ToString());
            }

        }

        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;

        private void mat_switch1_CheckedChanged(object sender, EventArgs e)
        {
            if (mat_switch1.Checked)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
        }

       

        private void materialLabel1_Click(object sender, EventArgs e)
        {

           
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

   


        private void materialButton1_Click(object sender, EventArgs e)
        {

            getActivityInfo(materialComboBox5.Text, materialComboBox3.Text, materialComboBox4.Text);
           

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

       
        private void getMentorInfo(string a)
        {
            string info = materialComboBox1.Text;
            string connString = "server = 127.0.0.1; user id = root;password=7U6F7P2fd4;database=seniorproject;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand getMentorName = conn.CreateCommand();
            getMentorName.CommandText = "Select * FROM  t_mentor WHERE MENTOR_FNAME =  @a";
            getMentorName.Parameters.Add("@a", MySqlDbType.VarChar).Value = a;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader reader = getMentorName.ExecuteReader();
            while (reader.Read())
            {
                if (a == info)
                {
                    listBox1.Items.Add(reader["Mentor_Fname"].ToString());
                    listBox1.Items.Add(reader["Mentor_Lname"].ToString());
                    listBox1.Items.Add(reader["Mentor_Major"].ToString());
                }


            }

            

        }

        private void getMenteeInfo(string a)
        {
            string info = materialComboBox2.Text;
            string connString = "server = 127.0.0.1; user id = root;password=7U6F7P2fd4;database=seniorproject;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand getMenteeName = conn.CreateCommand();
            getMenteeName.CommandText = "Select * FROM  t_mentee WHERE MENTEE_FNAME =  @a";
            getMenteeName.Parameters.Add("@a", MySqlDbType.VarChar).Value = a;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader reader = getMenteeName.ExecuteReader();
            while (reader.Read())
            {
                if (a == info)
                {
                    listBox1.Items.Add(reader["Mentee_Fname"].ToString());
                    listBox1.Items.Add(reader["Mentee_Lname"].ToString());
                    listBox1.Items.Add(reader["Mentee_Major"].ToString());
                    listBox1.Items.Add(reader["MentorID"].ToString());
                }


            }



        }

        private void getAllActivties(string a)
        {
            string info = materialComboBox6.Text;
            string conActivity = "server = 127.0.0.1; user id = root;password=7U6F7P2fd4;database=seniorproject;";
            MySqlConnection connection = new MySqlConnection(conActivity);
            MySqlCommand getAllActivity = connection.CreateCommand();
            getAllActivity.CommandText = "Select * from t_activity where activity = @a";
            getAllActivity.Parameters.Add("@a", MySqlDbType.VarChar).Value = a;

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader reader = getAllActivity.ExecuteReader();
            while (reader.Read())
            {
                if (a == info)
                {
                    listBox1.Items.Add(reader["Activity"].ToString());
                    listBox1.Items.Add(reader["Mentor_Fname"].ToString());
                    listBox1.Items.Add(reader["Mentee_Fname"].ToString());
                    listBox1.Items.Add(reader["hours"].ToString());
                }


            }

        }

        private void getActivityInfo(string a, string b, string c)
        {
            string info = materialComboBox5.Text;
            string info2 = materialComboBox3.Text;
            string info3 = materialComboBox4.Text;
            string connString = "server = 127.0.0.1; user id = root;password=7U6F7P2fd4;database=seniorproject;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand getActivity = conn.CreateCommand();
            getActivity.CommandText = "select distinct * from t_activity where activity =  @a AND mentor_fname = @b AND mentee_fname = @c";
            getActivity.Parameters.Add("@a", MySqlDbType.VarChar).Value = a;
            getActivity.Parameters.Add("@b", MySqlDbType.VarChar).Value = b;
            getActivity.Parameters.Add("@c", MySqlDbType.VarChar).Value = c;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader reader = getActivity.ExecuteReader();
            while (reader.Read())
            {
                if (a == info && b == info2 && c == info3)
                {
                    listBox1.Items.Add(reader["Activity"].ToString());
                    listBox1.Items.Add(reader["Mentor_Fname"].ToString());
                    listBox1.Items.Add(reader["Mentee_Fname"].ToString());
                    listBox1.Items.Add(reader["hours"].ToString());
                }


            }

        }

        private void updateHours(string a, string b, string c, double d)
        {
            string info = materialComboBox5.Text;
            string info2 = materialComboBox3.Text;
            string info3 = materialComboBox4.Text;
            double hours = Double.Parse(materialTextBox1.Text);

            string connString = "server = 127.0.0.1; user id = root;password=7U6F7P2fd4;database=seniorproject;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand updateHours = conn.CreateCommand();
            updateHours.CommandText = "Update t_activity set hours = @d where activity =  @a AND mentor_fname = @b AND mentee_fname = @c";
            updateHours.Parameters.Add("@a", MySqlDbType.VarChar).Value = a;
            updateHours.Parameters.Add("@b", MySqlDbType.VarChar).Value = b;
            updateHours.Parameters.Add("@c", MySqlDbType.VarChar).Value = c;
            updateHours.Parameters.Add("@d", MySqlDbType.Double).Value = d;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader reader = updateHours.ExecuteReader();
           
        }
        private void materialButton4_Click(object sender, EventArgs e)
        {
            getMentorInfo(materialComboBox1.Text);
        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            getMenteeInfo(materialComboBox2.Text);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

            getAllActivties(materialComboBox6.Text);

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            updateHours(materialComboBox5.Text, materialComboBox3.Text, materialComboBox4.Text, Double.Parse(materialTextBox1.Text));

        }

       
    }
}

