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
    public partial class HOME_Page : Form
    {
        public HOME_Page()
        {
            InitializeComponent();
            LikedGradientPanel1.Visible = true; //when the form opens it will automatically start with this panel instead of being black
            emailpresent.Text = Form1.sbs;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Image = Properties.Resources.Gym_Mode_IPhone_Wallpaper___IPhone_Wallpapers;
            label27.Text = "Gym Playlist";

            String query = "SELECT * FROM GymPlaylist\r\n";

            //populates created Gym playlist

            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int firstRecord = 0;
                    int secondRecord = 0;
                    int thirdRecord = 0;
                    while (reader.Read() && firstRecord < 6)
                    {
                        string firstValue = reader.GetString(0);
                        string secondValue = reader.GetString(1);
                        string thirdValue = reader.GetString(2);
                        switch (firstRecord)
                        {
                            case 0:
                                guna2Button17.Text = firstValue;
                                break;
                            case 1:
                                guna2Button15.Text = firstValue;
                                break;
                            case 2:
                                guna2Button14.Text = firstValue;
                                break;
                            case 3:
                                guna2Button13.Text = firstValue;
                                break;
                            case 4:
                                guna2Button12.Text = firstValue;
                                break;

                        }

                        firstRecord++;
                        switch (secondRecord)
                        {
                            case 0:
                                label25.Text = secondValue;
                                break;
                            case 1:
                                label24.Text = secondValue;
                                break;
                            case 2:
                                label23.Text = secondValue;
                                break;
                            case 3:
                                label22.Text = secondValue;
                                break;
                            case 4:
                                label21.Text = secondValue;
                                break;
                        }
                        secondRecord++;
                        switch (thirdRecord)
                        {
                            case 0:
                                label5.Text = thirdValue;
                                break;

                            case 1:
                                label4.Text = thirdValue;
                                break;
                            case 2:
                                label3.Text = thirdValue;
                                break;
                            case 3:
                                label2.Text = thirdValue;
                                break;
                            case 4:
                                label1.Text = thirdValue;
                                break;
                        }
                        thirdRecord++;

                    }
                    reader.Close();
                    Music_Store_DB_Connect.con.Close();

                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Image = Properties.Resources.Uncle_waffles;
            label27.Text = "LifeStyle Music";
            String query = "SELECT * FROM LifeStyle_Playlist\r\n";

            //populates created LifeStyle playlist

            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int firstRecord = 0;
                    int secondRecord = 0;
                    int thirdRecord = 0;
                    while (reader.Read() && firstRecord < 6)
                    {
                        string firstValue = reader.GetString(0);
                        string secondValue = reader.GetString(1);
                        string thirdValue = reader.GetString(2);
                        switch (firstRecord)
                        {
                            case 0:
                                guna2Button17.Text = firstValue;
                                break;
                            case 1:
                                guna2Button15.Text = firstValue;
                                break;
                            case 2:
                                guna2Button14.Text = firstValue;
                                break;
                            case 3:
                                guna2Button13.Text = firstValue;
                                break;
                            case 4:
                                guna2Button12.Text = firstValue;
                                break;

                        }

                        firstRecord++;
                        switch (secondRecord)
                        {
                            case 0:
                                label25.Text = secondValue;
                                break;
                            case 1:
                                label24.Text = secondValue;
                                break;
                            case 2:
                                label23.Text = secondValue;
                                break;
                            case 3:
                                label22.Text = secondValue;
                                break;
                            case 4:
                                label21.Text = secondValue;
                                break;
                        }
                        secondRecord++;
                        switch (thirdRecord)
                        {
                            case 0:
                                label5.Text = thirdValue;
                                break;

                            case 1:
                                label4.Text = thirdValue;
                                break;
                            case 2:
                                label3.Text = thirdValue;
                                break;
                            case 3:
                                label2.Text = thirdValue;
                                break;
                            case 4:
                                label1.Text = thirdValue;
                                break;
                        }
                        thirdRecord++;

                    }
                    reader.Close();
                    Music_Store_DB_Connect.con.Close();

                }
            }

        }

        private void Playlist_btn_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Image = Properties.Resources.Lofi_playlist;
            label27.Text = "Lofi Playlist";

            String query = "SELECT * FROM LofiPlaylist\r\n";

            //populates created Lofi playlist
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int firstRecord = 0;
                    int secondRecord = 0;
                    int thirdRecord = 0;
                    while (reader.Read() && firstRecord < 6)
                    {
                        string firstValue = reader.GetString(0);
                        string secondValue = reader.GetString(1);
                        string thirdValue = reader.GetString(2);
                        switch (firstRecord)
                        {
                            case 0:
                                guna2Button17.Text = firstValue;
                                break;
                            case 1:
                                guna2Button15.Text = firstValue;
                                break;
                            case 2:
                                guna2Button14.Text = firstValue;
                                break;
                            case 3:
                                guna2Button13.Text = firstValue;
                                break;
                            case 4:
                                guna2Button12.Text = firstValue;
                                break;
                        }
                        firstRecord++;
                        switch (secondRecord)
                        {
                            case 0:
                                label25.Text = secondValue;
                                break;
                            case 1:
                                label24.Text = secondValue;
                                break;
                            case 2:
                                label23.Text = secondValue;
                                break;
                            case 3:
                                label22.Text = secondValue;
                                break;
                            case 4:
                                label21.Text = secondValue;
                                break;
                        }
                        secondRecord++;
                        switch (thirdRecord)
                        {
                            case 0:
                                label5.Text = thirdValue;
                                break;

                            case 1:
                                label4.Text = thirdValue;
                                break;
                            case 2:
                                label3.Text = thirdValue;
                                break;
                            case 3:
                                label2.Text = thirdValue;
                                break;
                            case 4:
                                label1.Text = thirdValue;
                                break;
                        }
                        thirdRecord++;

                    }
                    reader.Close();
                    Music_Store_DB_Connect.con.Close();

                }

            }
        }

        private void Pop_songs_btn_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Image = Properties.Resources.Pop_cover_image;
            label27.Text = "Pop Playlist";

            String query = "SELECT * FROM PopPlaylist\r\n";

            //populates created Pop playlist

            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int firstRecord = 0;
                    int secondRecord = 0;
                    int thirdRecord = 0;
                    while (reader.Read() && firstRecord < 6)
                    {
                        string firstValue = reader.GetString(0);
                        string secondValue = reader.GetString(1);
                        string thirdValue = reader.GetString(2);
                        switch (firstRecord)
                        {
                            case 0:
                                guna2Button17.Text = firstValue;
                                break;
                            case 1:
                                guna2Button15.Text = firstValue;
                                break;
                            case 2:
                                guna2Button14.Text = firstValue;
                                break;
                            case 3:
                                guna2Button13.Text = firstValue;
                                break;
                            case 4:
                                guna2Button12.Text = firstValue;
                                break;
                        }
                        firstRecord++;
                        switch (secondRecord)
                        {
                            case 0:
                                label25.Text = secondValue;
                                break;
                            case 1:
                                label24.Text = secondValue;
                                break;
                            case 2:
                                label23.Text = secondValue;
                                break;
                            case 3:
                                label22.Text = secondValue;
                                break;
                            case 4:
                                label21.Text = secondValue;
                                break;
                        }
                        secondRecord++;
                        switch (thirdRecord)
                        {
                            case 0:
                                label5.Text = thirdValue;
                                break;

                            case 1:
                                label4.Text = thirdValue;
                                break;
                            case 2:
                                label3.Text = thirdValue;
                                break;
                            case 3:
                                label2.Text = thirdValue;
                                break;
                            case 4:
                                label1.Text = thirdValue;
                                break;
                        }
                        thirdRecord++;
                    }
                    reader.Close();
                    Music_Store_DB_Connect.con.Close();

                }

            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var albums = new Album();
            albums.Closed += (s, args) => this.Close();
            albums.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Artist = new Artist();
            Artist.Closed += (s, args) => this.Close();
            Artist.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_subscript = new Update_sub_user();
            back_to_subscript.Closed += (s, args) => this.Close();
            back_to_subscript.Show();
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            var to_review = new Review();
            to_review.Closed += (s, args) => this.Close();
            to_review.Show();
        }

        private void emailpresent_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var account = new account_DETAILScs();
            account.Closed += (s, args) => this.Close();
            account.Show();
        }

        private void HOME_Page_Load(object sender, EventArgs e)
        {
            guna2Button2.Text = PlayList_Creation.Playlistname;
            guna2Button7.Text = PlayList_Creation.Playlistname1;
            guna2Button3.Text = PlayList_Creation.Playlistname2;
            Pop_songs_btn.Text = PlayList_Creation.Playlistname3;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Create_Playlist = new PlayList_Creation();
            Create_Playlist.Closed += (s, args) => this.Close();
            Create_Playlist.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Form1();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
            
      
    

