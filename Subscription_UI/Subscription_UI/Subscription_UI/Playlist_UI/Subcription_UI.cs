using Playlist_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subscription_UI
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void Home_btn_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Subscription_UI_Load(object sender, EventArgs e)
        {

        }

        public void guna2Button5_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == false || radioButton2.Checked == false)
            {
                MessageBox.Show("Choose a subsciption package ");
            }
            this.Hide();
            var playList = new tap_me() ;
            playList.Closed += (s, args) => this.Close();
            playList.Show();
        }
        public void grant_user_access()
        {
            
        }


    }
}
