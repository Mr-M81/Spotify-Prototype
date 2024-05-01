using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Registration_and_Login_UI
{
    public partial class Artist : Form
    {
        SoundPlayer player;
        public Artist()
        {
            InitializeComponent();
            LofiGradientPanel3.Visible = true;
            richTextBox1.Text = "Kendrick Lamar: Born on June 17, 1987, in Compton, California, Kendrick Lamar is a highly acclaimed rapper known for his introspective lyrics and socially conscious themes. He has won multiple Grammy Awards and made a significant impact on the rap genre.";
            player = new SoundPlayer();


        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_album = new Album();
            back_to_album.Closed += (s, args) => this.Close();
            back_to_album.Show();
            checker2 = true;
        }

        private void Playlist_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_home = new HOME_Page();
            back_to_home.Closed += (s, args) => this.Close();
            back_to_home.Show();
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
            LofiGradientPanel3.Visible = true;
            guna2PictureBox5.Image = Properties.Resources.Kendrick_Lamar;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = guna2Button2.Text;
            richTextBox1.Text="Kendrick Lamar: Born on June 17, 1987, in Compton, California, Kendrick Lamar is a highly acclaimed rapper known for his introspective lyrics and socially conscious themes. He has won multiple Grammy Awards and made a significant impact on the rap genre.";

        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            var to_review = new Review();
            to_review.Closed += (s, args) => this.Close();
            to_review.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_subscript = new Subscriptionform();
            back_to_subscript.Closed += (s, args) => this.Close();
            back_to_subscript.Show();
        }

        private void Artist_Load(object sender, EventArgs e)
        {
            //DIsplays all the artists in the database with their top 5 songs.
            emailpresent.Text = Form1.sbs;
            string query = "Select * from Name_of_artist";
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int recordCount = 0;

                    while (reader.Read() && recordCount < 8)
                    {
                        string recordValue = reader.GetString(0); // Assuming the record value is in the first column
                        switch (recordCount)
                        {
                            case 0:
                                guna2Button2.Text = recordValue;
                                break;
                            case 1:
                                guna2Button3.Text = recordValue;
                                break;
                            case 2:
                                guna2Button7.Text = recordValue;
                                break;
                            case 3:
                                guna2Button11.Text = recordValue;
                                break;
                            case 4:
                                guna2Button13.Text = recordValue;
                                break;
                            case 5:
                                Artistbtn6btn.Text = recordValue;
                                break;
                            case 6:
                                Artist7btn.Text = recordValue;
                                break;
                            case 7:
                                Artist8btn.Text = recordValue;
                                break;
                        }

                        recordCount++;
                    }
                    reader.Close();
                    Music_Store_DB_Connect.con.Close(); // Close the connection
                }
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var account = new account_DETAILScs();
            account.Closed += (s, args) => this.Close();
            account.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            checker2 = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Properties.Resources.Eminem;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            checker2 = false;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = guna2Button3.Text;
            richTextBox1.Text = "Eminem: Marshall Mathers III, known as Eminem, was born on October 17, 1972, in St. Joseph, Missouri. He rose to fame as a rapper known for his raw and provocative lyrics, addressing personal struggles, and providing social commentary. Eminem has achieved numerous awards and record-breaking album sales.";


        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Properties.Resources.black_coffee;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = guna2Button7.Text;
            richTextBox1.Text = "Black Coffee: Nkosinathi Innocent Maphumulo, professionally known as Black Coffee, is a South African DJ, producer, and entrepreneur. He gained international recognition for his soulful and melodic sound, blending African rhythms with electronic music, and has won several DJ awards.";

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Properties.Resources.kabza;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = guna2Button11.Text;
            richTextBox1.Text = "Kabza de Small: Kabza de Small, born Kabelo Motha on November 27, 1992, in Mpumalanga, South Africa, is a prominent figure in the Amapiano genre. He is known for his unique production style, blending Amapiano with other genres, and has played a pivotal role in popularizing Amapiano globally.";

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Properties.Resources.Drake;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = guna2Button13.Text;
            richTextBox1.Text = "Drake: Born Aubrey Drake Graham on October 24, 1986, in Toronto, Canada, Drake is a versatile artist who achieved tremendous success as both an actor and a musician. With multiple Grammy Awards and chart-topping hits, he has become one of the most influential figures in the music industry, seamlessly blending rap and R&B.";

        }

        private void Artistbtn6btn_Click(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Properties.Resources.The_Weekndjpg;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = Artistbtn6btn.Text;
            richTextBox1.Text = "The Weeknd: Abel Makkonen Tesfaye, professionally known as The Weeknd, emerged as a Canadian singer, songwriter, and producer. With his distinctive falsetto vocals and dark, atmospheric sound, he captivated audiences worldwide. The Weeknd's chart-topping hits and electrifying performances have solidified his status as a prominent figure in contemporary R&B and pop music.";

        }

        private void Artist7btn_Click(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Properties.Resources.Bryson_Tiller;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = Artist7btn.Text;
            richTextBox1.Text = "Bryson Tiller: Bryson Tiller, born on January 2, 1993, in Louisville, Kentucky, is an American singer, songwriter, and rapper. He gained recognition with his debut album Trapsoul, which showcased his smooth vocals and introspective lyrics. Tiller's unique blend of R&B and hip-hop influences has resonated with listeners and established him as a rising star in the music industry.";

        }

        private void Artist8btn_Click(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Properties.Resources.Maroon_5;
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            RetrieveAlbumSongs(clickedButton);
            label57.Text = Artist8btn.Text;
            richTextBox1.Text = "Maroon 5: Maroon 5 is a Grammy Award-winning American pop-rock band formed in Los Angeles, California, in 1994. Led by frontman Adam Levine, the band gained worldwide fame with their catchy melodies and infectious pop sound. With numerous hit singles and sold-out tours, Maroon 5 has remained a dominant force in the music industry, continuously evolving their sound while maintaining their signature style.";


        }
        private void RetrieveAlbumSongs(Guna.UI2.WinForms.Guna2Button clickedButton)
        {
            LofiGradientPanel3.Visible = true;

            string query = "SELECT TOP 5 TRACK_TABLE.TRACK_TITLE, TRACK_TABLE.TRACK_LENGTH, ARTIST_TABLE.ARTIST_MONTHLY_LISTENERS, ARTIST_TABLE.NO_OF_FOLLOWERS FROM ARTIST_TABLE INNER JOIN TRACK_TABLE ON TRACK_TABLE.ARTIST_ID = ARTIST_TABLE.ARTIST_ID WHERE TRACK_TABLE.ARTIST_ID = (SELECT ARTIST_ID FROM ARTIST_TABLE WHERE ARTIST_PERFORMANCE_NAME LIKE CONCAT('%', @ARTIST_NAME, '%'));";

            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                command.Parameters.AddWithValue("@ARTIST_NAME", clickedButton.Text);

                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int recordCount = 0;
                    int recordCount2 = 0;

                    while (reader.Read() && recordCount < 5)
                    {
                        string recordValue = reader.GetString(0); // Assuming the record value is in the first column
                        string recordValue2 = reader.GetString(1); // Assuming the record value is in the second column

                        double recordValue3 = reader.GetDouble(2); // Assuming the record value is in the first column
                        int recordValue4 = reader.GetInt32(3); // Assuming the record value is in the second column


                        // Assign the value to the corresponding label based on the record count
                        switch (recordCount)
                        {
                            case 0:
                                guna2Button27.Text = recordValue;
                                label4.Text = recordValue3.ToString();
                                label5.Text = recordValue4.ToString();
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
                            
                        }

                        recordCount++;

                        switch (recordCount2)
                        {
                            case 0:
                                label50.Text = recordValue2;
                                break;
                            case 1:
                                label49.Text = recordValue2;
                                break;
                            case 2:
                                label48.Text = recordValue2;
                                break;
                            case 3:
                                label47.Text = recordValue2;
                                break;
                            case 4:
                                label46.Text = recordValue2;
                                break;
                            
                        }
                        recordCount2++;
                    }

                    reader.Close();
                    Music_Store_DB_Connect.con.Close(); // Close the connection
                }
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }
        public static bool checker2 = true;
        private void LofiGradientPanel3_Paint(object sender, PaintEventArgs e)
        {
            if (checker2)
            {
                RetrieveAlbumSongs(guna2Button2);
                label57.Text = guna2Button2.Text;


            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            //string audiofilePath = $"{Application.StartupPath}\\drake_started_from_the_bottom_explicit_mp3_63578.mp3";
            //player.SoundLocation = audiofilePath;
            //player.Play();
            Play_StartingfromBottom();
        }
        public void Play_StartingfromBottom()
        {
            string audiofilePath = $"{Application.StartupPath}\\drake_started_from_the_bottom_explicit_mp3_63578.wav";
            player.SoundLocation = audiofilePath;
            player.Play();
        }
        public void Play_ecimbini()
        {
            string audiofilePath = $"{Application.StartupPath}\\emcimbini_live_mp3_67342.wav";
            player.SoundLocation = audiofilePath;
            player.Play();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            Play_ecimbini();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            play_blininglights();
        }
        public void play_blininglights()
        {
            string audiofilePath = $"{Application.StartupPath}\\the_weeknd_blinding_lights_lyrics_mp3_67498.wav";
            player.SoundLocation = audiofilePath;
            player.Play();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Form1();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            play_notafriad();
        }
        public void play_notafriad()
        {
            string audiofilePath = $"{Application.StartupPath}\\Eminem - Not Afraid.wav";
            player.SoundLocation = audiofilePath;
            player.Play();
        }
    }
}
