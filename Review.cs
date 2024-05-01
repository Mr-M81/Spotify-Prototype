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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Registration_and_Login_UI
{
    public partial class Review : Form
    {
        public Review()
        {
            InitializeComponent();



        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            int track_id = 0;
            string query = "Select TRACK_ID\r\nfrom TRACK_TABLE\r\nWHERE TRACK_TITLE = @Track_Title";

            //this searches for the track title in order to provide the track id 
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                command.Parameters.AddWithValue("@Track_Title", comboBox2.Text);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    track_id = Convert.ToInt32(result);
                    Music_Store_DB_Connect.con.Close();
                }
                Music_Store_DB_Connect.con.Close();
            }
            string query1 = "SELECT CUSTOMER_ID FROM CUSTOMER_TABLE WHERE EMAIL_ADDRESS = @Email";
            int rating = int.Parse(comboBox1.Text);
            int customers_id = 0;

            // this collects the users id using their email address
            using (SqlCommand command = new SqlCommand(query1, Music_Store_DB_Connect.con))
            {
                string check = Form1.sbs;
                Music_Store_DB_Connect.con.Open();
                command.Parameters.AddWithValue("@Email", check);

                object result2 = command.ExecuteScalar();

                if (result2 != null)
                {
                    customers_id = Convert.ToInt32(result2);
                }
                Music_Store_DB_Connect.con.Close();
            }
            Music_Store_DB_Connect reviews = new Music_Store_DB_Connect();
            reviews.USER_REVIEW(rating, guna2TextBox2.Text, comboBox2.Text, customers_id, track_id);//this allows the user to write the review


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_home = new HOME_Page();
            back_to_home.Closed += (s, args) => this.Close();
            back_to_home.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            string query = "Select TRACK_TABLE.TRACK_TITLE\r\nfrom TRACK_TABLE\r\nInner Join ARTIST_TABLE \r\nOn TRACK_TABLE.ARTIST_ID = ARTIST_TABLE.ARTIST_ID\r\nwhere ARTIST_TABLE.ARTIST_PERFORMANCE_NAME Like @Artist_Stage_Name";

            //this will allow you to search a specific song by the artist stage name

            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                command.Parameters.AddWithValue("@Artist_Stage_Name", "%" + guna2TextBox1.Text + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    comboBox2.Items.Clear();

                    while (reader.Read())
                    {
                        string songTitle = reader.GetString(0);
                        comboBox2.Items.Add(songTitle);
                    }
                    Music_Store_DB_Connect.con.Close();
                    //If no songs were found, display a message
                    if (comboBox2.Items.Count == 0)
                    {
                        comboBox2.Items.Add("No songs found for the entered artist");
                    }
                 
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            string query = "Select TRACK_TABLE.TRACK_TITLE\r\nfrom TRACK_TABLE\r\nInner Join ARTIST_TABLE \r\nOn TRACK_TABLE.ARTIST_ID = ARTIST_TABLE.ARTIST_ID\r\nwhere ARTIST_TABLE.ARTIST_PERFORMANCE_NAME Like @Artist_Stage_Name";

            //this will allow you to search a specific song by the artist stage name
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                command.Parameters.AddWithValue("@Artist_Stage_Name", "%" + guna2TextBox1.Text + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    comboBox2.Items.Clear();

                    while (reader.Read())
                    {
                        string songTitle = reader.GetString(0);
                        comboBox2.Items.Add(songTitle);
                    }
                    Music_Store_DB_Connect.con.Close();
                    // If no songs were found, display a message
                    if (comboBox2.Items.Count == 0)
                    {
                        comboBox2.Items.Add("No songs found for the entered artist");
                    }
                   
                }
            }
        }
    }
}
