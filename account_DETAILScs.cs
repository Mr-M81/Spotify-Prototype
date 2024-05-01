using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Registration_and_Login_UI
{
    public partial class account_DETAILScs : Form
    {
        public account_DETAILScs()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var back_to_home = new HOME_Page();
            back_to_home.Closed += (s, args) => this.Close();
            back_to_home.Show();
        }

        private void account_DETAILScs_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text = Form1.sbs;
            //Displays all user information , their start date and end date of their subscription, the package they have subscibed to. 
            string query = "SELECT CUSTOMER_TABLE.EMAIL_ADDRESS,SUBSCRIPTION_TABLE.SUBSCRIPTION_NAME,SUBSCRIPTION_TABLE.SUBSCRIPTION_START_DATE, SUBSCRIPTION_TABLE.SUBSCRIPTION_START_END_\r\n FROM CUSTOMER_TABLE\r\n INNER JOIN SUBSCRIPTION_TABLE\r\n ON CUSTOMER_TABLE.CUSTOMER_ID = SUBSCRIPTION_TABLE.CUSTOMER_ID\r\n Where CUSTOMER_TABLE.EMAIL_ADDRESS = @EMAIL_ADDRESS";
            string check = Form1.sbs;
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                command.Parameters.AddWithValue("@EMAIL_ADDRESS", check);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        UsernameLabel.Text = reader.GetString(0);
                        SPlabel.Text = reader.GetString(1);
                        SDlabel.Text = reader.GetDateTime(2).ToString();
                        EDlabel.Text = reader.GetDateTime(3).ToString();
                        Music_Store_DB_Connect.con.Close();
                    }
                    else
                    {
                    
                        Music_Store_DB_Connect.con.Close();
                    }
                }
                Music_Store_DB_Connect.con.Close();

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //this allows a user to end their own subscription
            string query = "delete from SUBSCRIPTION_TABLE from SUBSCRIPTION_TABLE\r\nINNER JOIN CUSTOMER_TABLE \r\nON SUBSCRIPTION_TABLE.CUSTOMER_ID = CUSTOMER_TABLE.CUSTOMER_ID\r\nWHERE CUSTOMER_TABLE.EMAIL_ADDRESS = @EMAIL_ADDRESS";
            string check = Form1.sbs;
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                
                try
                {
                    Music_Store_DB_Connect.con.Open();
                    command.Parameters.AddWithValue("@EMAIL_ADDRESS", check);
                    command.ExecuteNonQuery();
                    MessageBox.Show("You have unsubscribed");
                    SDlabel.Text = "None";
                    SPlabel.Text = "None";
                    EDlabel.Text = "None";
                    Unsubscribed_Form();                        
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);

                }
                finally
                {
                    Music_Store_DB_Connect.con.Close();
                }



            }
        }
        public void Unsubscribed_Form()
        {
            this.Hide();
            var UUV = new Unsubscribed_user_view();
            UUV.Closed += (s, args) => this.Close();
            UUV.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var unsubscribed_user = new Unsubscribed_user_view();
            unsubscribed_user.Closed += (s, args) => this.Close();
            unsubscribed_user.Show();
        }
    }
}