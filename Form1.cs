
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_and_Login_UI
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        public static string login_email_address = "";
        public static string login_password = "";
        public static string sbs =  "";


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // create a graphics path with a rounded rectangle shape
            GraphicsPath path = new GraphicsPath();
            int cornerRadius = 20;
            int arcSize = cornerRadius * 2;

            path.StartFigure();
            path.AddArc(0, 0, arcSize, arcSize, 180, 90);
            path.AddLine(cornerRadius, 0, this.Width - cornerRadius, 0);
            path.AddArc(this.Width - arcSize, 0, arcSize, arcSize, 270, 90);
            path.AddLine(this.Width, cornerRadius, this.Width, this.Height - cornerRadius);
            path.AddArc(this.Width - arcSize, this.Height - arcSize, arcSize, arcSize, 0, 90);
            path.AddLine(this.Width - cornerRadius, this.Height, cornerRadius, this.Height);
            path.AddArc(0, this.Height - arcSize, arcSize, arcSize, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // attach event handlers to enable dragging of the form
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Music_Store_DB_Connect dB_Connect = new Music_Store_DB_Connect();
            string firstname = RegisterFirstNtext.Text;
            string lastname = RegisterLastNtext.Text;
            string email_address = RegisterEmailText.Text;
            string Phone_NO = RegisterPhoneText.Text;
            DateTime DOB = RegisterDatePicker.Value;
            string Password = RegisterPasswordText.Text;
            string re_Password = RegisterReEnterPasswordText.Text;
            
            //returns a true or false
            bool valid = Validation(firstname, lastname, email_address, Phone_NO, Password, re_Password);

            if (valid)
            {
                string encrpyt_password = password_encryptor(Password);
                dB_Connect.add_user(firstname, lastname, email_address, Phone_NO, DOB, encrpyt_password);
            }

        }
        //this is the validation method 
        private bool Validation(string firstname, string lastname, string email_address,string Phone_NO,string Password, string Re_EnterPassword)
        {
            
            bool Valid = true;
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (email_address == "")
            {
                MessageBox.Show("All required fields must be entered.");
                Valid = false;
            }
            if (! reg.Match(email_address).Success)
            {
                MessageBox.Show("Invalid Email Adress.");
                Valid = false;
            }
            if(Password == "")
            {
                MessageBox.Show("Password is Required");
                Valid = false;
            }
            if( Re_EnterPassword == "")
            {
                MessageBox.Show("RE-Enter Password Is Required!");
                Valid = false;
            }
            if( Password != Re_EnterPassword)
            {
                MessageBox.Show("Passwords don't Match!");
                Valid = false;
            }
            if(firstname == "" )
            {
                MessageBox.Show("First Name is required !");
                Valid = false;
            }
            if (lastname == "")
            {
                MessageBox.Show("Surname is required !");
                Valid = false;
            }
            if(Phone_NO.Length != 15)
            {
                MessageBox.Show("Invalid Phone Number Length");
                Valid = false;
            }
            Regex phone = new Regex(@"^\(\+27\) \d{9}$");

            if (! phone.Match(Phone_NO).Success)
            {
                MessageBox.Show("Enter a valid phone number");
                Valid = false;
            }
            return Valid;
        }
        public static string password_encryptor(string password)
        {
            //encrpyts user password
            var hash = SHA256.Create();

            var byteArray = Encoding.Default.GetBytes(password);

            var encrypted_password = hash.ComputeHash(byteArray);

            return Convert.ToBase64String(encrypted_password);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            //panel5.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.spotify.com/za-en/legal/end-user-agreement/");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Currently not available , try again later {ex.Message}");
            }
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Music_Store_DB_Connect music_store_db_connect = new Music_Store_DB_Connect();
            login_email_address = loginemailtext.Text;
            login_password = LoginPasswordtext.Text;
            sbs = login_email_address;

            if(loginemailtext.Text == "ITGURU99@admin.com"&& LoginPasswordtext.Text == "SeniorDeveloper")
            {
                this.Hide();
                var admin = new Admin_Dashboard();
                admin.Closed += (s, args) => this.Close();
                admin.Show();
            }
            else
            {
                bool valid = login_validation(login_email_address, login_password);

                if (valid)
                {
                    string encrypted_password = password_encryptor(login_password);
                    bool authorize = music_store_db_connect.login_user(login_email_address, encrypted_password);

                    if (authorize)
                    {
                        this.Hide();
                        grant_user_access();

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Unsuccessful login");

                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("All fields are required");
                }
            }

           
        }


        public void grant_user_access()
        {
            //this will check if the user is in the database and then grant access to the application
            string query = "SELECT CUSTOMER_TABLE.EMAIL_ADDRESS,SUBSCRIPTION_TABLE.SUBSCRIPTION_NAME,SUBSCRIPTION_TABLE.SUBSCRIPTION_START_DATE, SUBSCRIPTION_TABLE.SUBSCRIPTION_START_END_\r\n FROM CUSTOMER_TABLE\r\n INNER JOIN SUBSCRIPTION_TABLE\r\n ON CUSTOMER_TABLE.CUSTOMER_ID = SUBSCRIPTION_TABLE.CUSTOMER_ID\r\n Where CUSTOMER_TABLE.EMAIL_ADDRESS = @EMAIL_ADDRESS";

            using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
            {
                command.Parameters.AddWithValue("@EMAIL_ADDRESS", loginemailtext.Text);

                Music_Store_DB_Connect.con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var homepage = new HOME_Page();
                        homepage.Closed += (s, args) => this.Close();
                        homepage.Show();
                        Music_Store_DB_Connect.con.Close();

                    }
                    else
                    {
                        var Subscription = new Subscriptionform();
                        Subscription.Closed += (s, args) => this.Close();
                        Subscription.Show();
                        Music_Store_DB_Connect.con.Close();
                    }

                   
                }
            }
        }
     
        public static bool login_validation(string login_email_address, string login_password)
        {
            //validates the login, ensures no fields are empty
           
            if (login_email_address == "" || login_password == "")
            {
                 return false;
            }
            return true;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

