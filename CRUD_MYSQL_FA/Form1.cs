
/*This project is supposed to have a CRUD with a login, for students records used by employees*/




using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_MYSQL_FA
{
    public partial class Form1 : Form
    {
        static string conString = "Server=localhost; Database=college; Uid=root; Pwd=;";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd;
        //MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //converts the dada in the fields to text and passes it to the method
            //do_login(txt_user.Text,txt_password.Text);
            do_login(txt_user.Text,txt_password.Text);
        }

        //Read
        private void do_login(string username, string password)
        {
            //sql query
            string query = "SELECT * FROM employees WHERE emp_username = @username AND emp_password = @password";
            cmd = new MySqlCommand(query, con);

            //params
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
                       

            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
               
                if (reader.HasRows)
                {
                    con.Close();
                    MessageBox.Show("Welcome!");
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.Show();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Username and or Password.");
                    con.Close();
                }

                //Close Connection
                con.Close();

                //clear dt
                //dt.Rows.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Console.WriteLine("error at login");
                //close connection
                con.Close();
            }
        }
    }
}
