using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_and_Login_UI
{
    public partial class Unsubscribed_user_view : Form
    {
        public Unsubscribed_user_view()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var write_subscription = new Subscriptionform();
            write_subscription.Closed += (s, args) => this.Close();
            write_subscription.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            var account = new account_DETAILScs();
            account.Closed += (s, args) => this.Close();
            account.guna2Button1.Hide();// Hide the button on the correct instance
            account.guna2Button2.Hide(); // Hide the button on the correct instance
            account.guna2Button3.Show(); // Show the button on the correct instance
            account.Show();


        }

        private void Unsubscribed_user_view_Load(object sender, EventArgs e)
        {
            emailpresent.Text = Form1.sbs;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //this can allow a user to delete the application if they wish to do so
            string message = "Are you sure you want to delete this application";
            string Title = "Delete  App";
            MessageBoxButtons boxButtons = MessageBoxButtons.YesNo;
            DialogResult dialogResult = MessageBox.Show(message, Title, boxButtons);

            if(dialogResult == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                //DO nothing
            }
           
        }
    }
}
