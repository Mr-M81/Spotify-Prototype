using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_and_Login_UI
{
    //This is the class that enables the application to interact with our database, and assists with performing all our CRUD functionality.
    internal class Music_Store_DB_Connect  
    {
        private static string connection_string = "Data Source=LAPTOP-5B31S57L;Initial Catalog=SPOTIFY;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(connection_string);

        //Method that registers the user.
        public void add_user(string firstname, string lastname, string email_address, string phone_no, DateTime DOB, string password)
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("STORE_USER_DATA", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FIRST_NAME", firstname);
                command.Parameters.AddWithValue("@LAST_NAME", lastname);
                command.Parameters.AddWithValue("@EMAIL_ADDRESS", email_address);
                command.Parameters.AddWithValue("@PHONE_NO", phone_no);
                command.Parameters.AddWithValue("@DATE_OF_BIRTH", DOB);
                command.Parameters.AddWithValue("@PASSWORD", password);

                int exc = command.ExecuteNonQuery();
                if (exc > 0)
                {
                   MessageBox.Show("Sucess");
                }
                con.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                con.Close();

            }
        }

        //This method allows a user to subscribe to a music package
        public void Subscribe_User(string subscription_name, DateTime Subscription_Startdate, DateTime subscription_enddate, string Subs_price, int customer_id)
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SUBSCRIBE_USER", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SUBSCRIPTION_NAME ", subscription_name);
                command.Parameters.AddWithValue("@SUBSCRIPTION_START_DATE ", Subscription_Startdate);
                command.Parameters.AddWithValue("@SUBSCRIPTION_START_END_", subscription_enddate);
                command.Parameters.AddWithValue("@SUBSCRIPTION_PRICE", Subs_price);
                command.Parameters.AddWithValue("@CUSTOMER_ID", customer_id);
                int exc = command.ExecuteNonQuery();
                if (exc > 0)
                {
                    MessageBox.Show("You have Sucessfully subscribed !");
                }
                con.Close();

            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
                con.Close();
            }
        }

        //this method allows the user to login by reading into the database and comparing the email and password of the user by what is stored in the database
        public bool login_user(string email_address, string password)
        {
            con.Open();
            SqlCommand command = new SqlCommand("LOGIN_USER", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EMAIL_ADDRESS", email_address);
            command.Parameters.AddWithValue("@PASSWORD", password);

            SqlDataReader read_data = command.ExecuteReader();
            read_data.Read();

            if (read_data.HasRows)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
       
        // this method allows a user to review a song of any artist, this will also write into the database once a review has been made.
        public void USER_REVIEW (int RATING, string REVIEW_TEXT, string song_name,int CUSTOMER_ID, int TRACK_ID)
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("Review", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Rating ", RATING);
                command.Parameters.AddWithValue("@REVIEW", REVIEW_TEXT);
                command.Parameters.AddWithValue("@REVIEWED_SONG", song_name);
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                command.Parameters.AddWithValue("@TRACK_ID", TRACK_ID);
                
                int exc = command.ExecuteNonQuery();
                if (exc > 0)
                {
                    MessageBox.Show("Your review has been successfully submitted thankyou");
                }
                con.Close();

            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
                con.Close();
            }
        }

    }
}
    