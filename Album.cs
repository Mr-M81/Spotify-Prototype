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

namespace Registration_and_Login_UI
{
    public partial class Album : Form
    {
        public Album()
        {
            InitializeComponent();
            LofiGradientPanel3.Visible = true; // when the form opens it will automatically start with this panel instead of being black
           

        }


        private void Album_Load(object sender, EventArgs e)
        {
            
            emailpresent.Text = Form1.sbs;
            string query = "SELECT TOP 6 ALBUM_TITLE FROM ALBUM_TABLE\r\nORDER BY NEWID()";
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int recordCount = 0;

                    while (reader.Read() && recordCount < 6)
                    {
                        string recordValue = reader.GetString(0);

                        switch (recordCount)
                        {
                            case 0:
                                Album1btn.Text = recordValue;
                                break;
                            case 1:
                                Album2tbn.Text = recordValue;
                                break;
                            case 2:
                                album3btn.Text = recordValue;
                                break;
                            case 3:
                                album4tbn.Text = recordValue;
                                break;
                            case 4:
                                Album5btn.Text = recordValue;
                                break;
                            case 5:
                                Album6btn.Text = recordValue;
                                break;
                        }
                        recordCount++;
                    }
                    reader.Close();
                    Music_Store_DB_Connect.con.Close();
                }
            }
        }

        private void Pop_songs_btn_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton); //the clicked button  has been passed to the method
            label57.Text = album4tbn.Text;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton); //the clicked button  has been passed to the method
            label57.Text = Album2tbn.Text;
            checker = false;
        }

        private void Home_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_home = new HOME_Page();
            back_to_home.Closed += (s, args) => this.Close();
            back_to_home.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton); //the clicked button  has been passed to the method
            label57.Text = Album1btn.Text;
           
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Artist = new Artist();
            Artist.Closed += (s, args) => this.Close();
            Artist.Show();
            checker = true;
        }

        private void Playlist_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_home = new HOME_Page();
            back_to_home.Closed += (s, args) => this.Close();
            back_to_home.Show();
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            var to_review = new Review();
            to_review.Closed += (s, args) => this.Close();
            to_review.Show();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_subscript = new Subscriptionform();
            back_to_subscript.Closed += (s, args) => this.Close();
            back_to_subscript.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var account = new account_DETAILScs();
            account.Closed += (s, args) => this.Close();
            account.Show();
        }

        private void emailpresent_Click(object sender, EventArgs e)
        {

        }
        public static bool checker = true;
        private void LofiGradientPanel3_Paint(object sender, PaintEventArgs e)
        {
            
            if (checker)
            {
                RetrieveAlbumSongs(Album1btn);
                label57.Text = Album1btn.Text;
            }
            
        }
        


        private void album3btn_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton); //the clicked button  has been passed to the method
            label57.Text = album3btn.Text;
        }

        //this method takes in an object of a button but not just any button, specifically a clicked button that a user has pressed.
        // it then displays all information related to that button click event. In this case a button clicked reveals all songs related to an album.
        private void RetrieveAlbumSongs(Guna.UI2.WinForms.Guna2Button clickedButton) 
        {
            LofiGradientPanel3.Visible = true;

            string query = "SELECT TRACK_TITLE, TRACK_LENGTH FROM TRACK_TABLE INNER JOIN ALBUM_TABLE ON TRACK_TABLE.ALBUM_ID = ALBUM_TABLE.ALBUM_ID WHERE ALBUM_TABLE.ALBUM_TITLE LIKE @ALBUM_TITLE";
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                command.Parameters.AddWithValue("@ALBUM_TITLE", clickedButton.Text);

                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int recordCount = 0;
                    int recordCount2 = 0;

                    while (reader.Read() && recordCount < 6)
                    {
                        string recordValue = reader.GetString(0); // Assuming the record value is in the first column
                        string recordValue2 = reader.GetString(1); // Assuming the record value is in the second column

                        // Assign the value to the corresponding label based on the record count
                        switch (recordCount)
                        {
                            case 0:
                                guna2Button27.Text = recordValue;
                                break;
                            case 1:
                                guna2Button1.Text = recordValue;
                                break;
                            case 2:
                                guna2Button8.Text = recordValue;
                                break;
                            case 3:
                                guna2Button9.Text = recordValue;
                                break;
                            case 4:
                                guna2Button10.Text = recordValue;
                                break;
                            case 5:
                                guna2Button2.Text = recordValue;
                                break;
                        }

                        recordCount++;

                        switch (recordCount2)
                        {
                            case 0:
                                label1.Text = recordValue2;
                                break;
                            case 1:
                                label2.Text = recordValue2;
                                break;
                            case 2:
                                label3.Text = recordValue2;
                                break;
                            case 3:
                                label4.Text = recordValue2;
                                break;
                            case 4:
                                label5.Text = recordValue2;
                                break;
                            case 5:
                                label6.Text = recordValue2;
                                break;
                        }
                        recordCount2++;
                    }

                    reader.Close();
                    Music_Store_DB_Connect.con.Close(); // Close the connection
                }
            }
        }

        private void Album5btn_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton); //the clicked button  has been passed to the method
            label57.Text = Album5btn.Text;
        }

        private void Album6btn_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton); //the clicked button  has been passed to the method
            label57.Text = Album6btn.Text;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            checker = true;            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Form1();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
