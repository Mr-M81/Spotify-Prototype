using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_and_Login_UI
{
    public partial class Update_sub_user : Form
    {
        public Update_sub_user()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //this will allow the user to upgrade/downgrade their subscription if they wish to do so.
            string query = "UPDATE SUBSCRIPTION_TABLE\r\nSET SUBSCRIPTION_NAME = @NEW_SUBSCRIPTION , SUBSCRIPTION_PRICE = @NEW_PRICE FROM SUBSCRIPTION_TABLE\r\nINNER JOIN CUSTOMER_TABLE \r\nON SUBSCRIPTION_TABLE.CUSTOMER_ID = CUSTOMER_TABLE.CUSTOMER_ID\r\nWHERE CUSTOMER_TABLE.EMAIL_ADDRESS = @EMAIL_ADDRESS";
            string check = Form1.sbs;
            //int customer_id = 100;
            if (radioButton1.Checked == true)
            {
                using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
                {
                    Music_Store_DB_Connect.con.Open();
                    try
                    {
                        command.Parameters.AddWithValue("@EMAIL_ADDRESS", check);
                        command.Parameters.AddWithValue("@NEW_SUBSCRIPTION", radioButton1.Text);
                        command.Parameters.AddWithValue("@NEW_PRICE", SP59.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("SUCCESS");

                    }
                    catch (Exception error)
                    {

                        MessageBox.Show(error.Message);
                    }
                    Music_Store_DB_Connect.con.Close();
                }
            }
            if(radioButton2.Checked == true)
            {
                using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
                {
                    Music_Store_DB_Connect.con.Open();
                    try
                    {
                        command.Parameters.AddWithValue("@EMAIL_ADDRESS", check);
                        command.Parameters.AddWithValue("@NEW_SUBSCRIPTION", radioButton2.Text);
                        command.Parameters.AddWithValue("@NEW_PRICE", PP79.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("SUCCESS");

                    }
                    catch (Exception error)
                    {

                        MessageBox.Show(error.Message);
                    }
                    Music_Store_DB_Connect.con.Close();
                }
            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var home_page = new HOME_Page();
            home_page.Closed += (s, args) => this.Close();
            home_page.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
