using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Registration_and_Login_UI
{
    public partial class Subscriptionform : Form
    {
        public Subscriptionform()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            var home_page = new HOME_Page();
            home_page.Closed += (s, args) => this.Close();
            home_page.Show();

            string subscription_name=""; string price= ""; DateTime subscript_start = DateTime.Parse("2023/01/23"); DateTime subscript_end = DateTime.Parse("2023/05/23"); int customer_id=0;
            string check = Form1.sbs;
            int customers_id = 0;
            string query = "SELECT CUSTOMER_ID FROM CUSTOMER_TABLE WHERE EMAIL_ADDRESS = @Email";


            //this will allow a registered user to subscribe by checking their email address
            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                Music_Store_DB_Connect.con.Open();
                command.Parameters.AddWithValue("@Email", check);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    customers_id = Convert.ToInt32(result);
                    Music_Store_DB_Connect.con.Close();

                }
                Music_Store_DB_Connect.con.Close();
            }
            if (radioButton1.Checked == true)
            {
                subscription_name = radioButton1.Text;
                price = SP59.Text;
                subscript_start = DateTime.Now;
                subscript_end = subscript_start.AddDays(30);
                customer_id = customers_id;

            }
            if(radioButton2.Checked==true)
            {
                subscription_name = radioButton2.Text;
                price = PP79.Text;
                subscript_start = DateTime.Now;
                subscript_end = subscript_start.AddDays(30);
                customer_id = customers_id;


            }

            Music_Store_DB_Connect sub = new Music_Store_DB_Connect();
            sub.Subscribe_User(subscription_name, subscript_start, subscript_end, price,customer_id);//calling subscription method to sucessfully subscribe user 

        }
       
        private void Subscriptionform_Load(object sender, EventArgs e)
        {

        }
    }
}
