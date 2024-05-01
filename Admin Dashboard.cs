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
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
            timer1.Start();

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {

            string query = "SELECT CUSTOMER_TABLE.FIRST_NAME, CUSTOMER_TABLE.LAST_NAME, CUSTOMER_TABLE.EMAIL_ADDRESS, CUSTOMER_TABLE.PASSWORD ,CUSTOMER_TABLE.PHONE_NO, CUSTOMER_TABLE.DATE_OF_BIRTH, SUBSCRIPTION_TABLE.SUBSCRIPTION_NAME, SUBSCRIPTION_TABLE.SUBSCRIPTION_START_DATE, SUBSCRIPTION_START_END_ FROM CUSTOMER_TABLE INNER JOIN SUBSCRIPTION_TABLE ON CUSTOMER_TABLE.CUSTOMER_ID = SUBSCRIPTION_TABLE.CUSTOMER_ID";

            // Creating an SqlDataAdapter object to execute the query and fill the DataSet
            SqlDataAdapter adapter = new SqlDataAdapter(query, Music_Store_DB_Connect.con);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

           
            dataGridView1.DataSource = dataSet.Tables[0];

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

          //this changes the data grid to a customized look
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LimeGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);



        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

            string message = $"Are you sure you want to delete user {guna2TextBox1.Text}";
            string Title = "Delete User";
            MessageBoxButtons boxButtons = MessageBoxButtons.YesNo;
            DialogResult dialogResult = MessageBox.Show(message, Title, boxButtons);

            if (dialogResult == DialogResult.Yes)
            {
                string query = " DELETE FROM SUBSCRIPTION_TABLE\r\n    WHERE CUSTOMER_ID IN (\r\n        SELECT CUSTOMER_ID\r\n        FROM CUSTOMER_TABLE\r\n        WHERE EMAIL_ADDRESS = @EMAIL_ADDRESS)\r\n\tDELETE FROM CUSTOMER_TABLE \r\n    WHERE EMAIL_ADDRESS = @EMAIL_ADDRESS";


                //this will delete a user from a database from an adminstrative view .
                using (SqlCommand command = new SqlCommand(query, Music_Store_DB_Connect.con))
                {
                    try
                    {
                        Music_Store_DB_Connect.con.Open();
                        command.Parameters.AddWithValue("@EMAIL_ADDRESS", guna2TextBox1.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("User has been deleted");

                        string query2 = "SELECT CUSTOMER_TABLE.FIRST_NAME, CUSTOMER_TABLE.LAST_NAME, CUSTOMER_TABLE.EMAIL_ADDRESS, CUSTOMER_TABLE.PASSWORD ,CUSTOMER_TABLE.PHONE_NO, CUSTOMER_TABLE.DATE_OF_BIRTH, SUBSCRIPTION_TABLE.SUBSCRIPTION_NAME, SUBSCRIPTION_TABLE.SUBSCRIPTION_START_DATE, SUBSCRIPTION_START_END_ FROM CUSTOMER_TABLE INNER JOIN SUBSCRIPTION_TABLE ON CUSTOMER_TABLE.CUSTOMER_ID = SUBSCRIPTION_TABLE.CUSTOMER_ID";

                        // Create a SqlDataAdapter to execute the query and fill the DataSet
                        SqlDataAdapter adapter = new SqlDataAdapter(query2, Music_Store_DB_Connect.con);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dataGridView1.DataSource = dataSet.Tables[0];

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
            else
            {
                //DO nothing
            }
            
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void lblSecond_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Form1();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
       

