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
    public partial class PlayList_Creation : Form
    {
        public static string Playlistname = "";
        public static string Playlistname1 = "";
        public static string Playlistname2 = "";
        public static string Playlistname3 = "";
        public static bool check = true;
        public PlayList_Creation()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int playlists = 0;
            int ns = 5;
            HOME_Page hOME_Page1 = new HOME_Page();
            if (guna2CheckBox7.Checked == true)
            {
                Playlistname = "LifeStyle Playlist";
                playlists = playlists + 1;
            }

            if (guna2CheckBox2.Checked == true)
            {
                Playlistname1 = "Gym Playlist";
                playlists = playlists + 1;
            }
            if (guna2CheckBox5.Checked == true)
            {
                Playlistname2 = "Lofi Playlist";
                playlists = playlists + 1;

            }
            if (guna2CheckBox6.Checked == true)
            {
                Playlistname3 = "Pop Playlist";
                playlists = playlists + 1;
            }


            //if (guna2CheckBox7.Checked == false)
            //{
            //    playlists = playlists - 1;

            //    // hOME_Page1.guna2Button2 = Properties.Resources.music1;
            //}
            //if (guna2CheckBox2.Checked == false)
            //{
                
            //    playlists -= 1;
            //}
            //if (guna2CheckBox5.Checked == false)
            //{
            //    playlists -= 1;

            //}
            //if (guna2CheckBox6.Checked == false)
            //{
            //    playlists -= 1;
            //}
            ns = ns * playlists;
            Playlist_Creation(playlists,ns);
            HOME_Page hOME_Page = new HOME_Page();
            this.Hide();
            var Open_Home = new HOME_Page();
            Open_Home.Closed += (s, args) => this.Close();
            Open_Home.Show();
        }

        private void guna2CheckBox7_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void Playlist_Creation(int playlists, int ns)
        {
            int num = 5;
            int customers_id = 0;
            string query = "Insert into PLAYLIST_TABLE VALUES (@NUMBER_OF_PLAYLISTS,@NO_OF_SONGS,@CUSTOMER_ID)";
            string query1 = "SELECT CUSTOMER_ID FROM CUSTOMER_TABLE WHERE EMAIL_ADDRESS = @Email";

           
            using (SqlCommand command = new SqlCommand(query1, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();

                string check = Form1.sbs;
                    
                command.Parameters.AddWithValue("@Email", check);

                object result2 = command.ExecuteScalar();

                if (result2 != null)
                {
                    customers_id = Convert.ToInt32(result2);
                    Music_Store_DB_Connect.con.Close();
                }
                Music_Store_DB_Connect.con.Close();

            }

            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                command.Parameters.AddWithValue("@NUMBER_OF_PLAYLISTS", playlists);
                command.Parameters.AddWithValue("@NO_OF_SONGS", ns);
                command.Parameters.AddWithValue("@CUSTOMER_ID", customers_id);

                    
                int exe = command.ExecuteNonQuery();
                if (exe > 0)
                {
                    MessageBox.Show("Playlist created !");
                    Music_Store_DB_Connect.con.Close();
                }
                Music_Store_DB_Connect.con.Close();

            }

           
        }
    }
}
