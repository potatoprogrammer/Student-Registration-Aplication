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
    public partial class Form2 : Form
    {
        static string conString = "Server=localhost; Database=college; Uid=root; Pwd=;";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public Form2()
        {
            InitializeComponent();

            //datagridview properties
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Student ID";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";
            dataGridView1.Columns[3].Name = "email";
            dataGridView1.Columns[4].Name = "Phone";
            dataGridView1.Columns[5].Name = "Program";
            dataGridView1.Columns[6].Name = "Joining Date";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //grid item selection
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        //this will populate gridview with the data
        private void populate(string std_id, string ft_name, string lt_name, string email, string phone, 
            string program, string j_date) {
            dataGridView1.Rows.Add(std_id, ft_name, lt_name, email, phone, program, j_date);
        }

        //clear form fields
        private void clear_fields() {
            txt_id.Text = null;
            txt_firstname.Text = null;
            txt_lastname.Text = null;
            txt_email.Text = null;
            txt_phone.Text = null;
            txt_program.Text = null;
            date_joining.Text = null;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            //DateTime picker
            date_joining.Format = DateTimePickerFormat.Short;
            date_joining.Value = DateTime.Today;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                txt_id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txt_firstname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_lastname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_email.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_phone.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_program.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                date_joining.Value = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[6].Value.ToString(), "yyyy-MM-dd", null);
            }
            else
            {
                MessageBox.Show("there is nothing on the datagridview");
            }
            
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            register_record(txt_id.Text, txt_firstname.Text, txt_lastname.Text,
                txt_email.Text, txt_phone.Text, txt_program.Text, date_joining.Text);
        }

        //register the records to the database
        private void register_record(string id, string fname, string lname, string email, string phone, 
            string program, string date)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname)
                || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(program) || string.IsNullOrEmpty(date))
            {
                MessageBox.Show("Please complete all the fields.");
            }
            else
            {
                //SQL QUERY
                string query = "INSERT INTO students(studentID, std_firstname, std_lastname, " +
                    "std_email, std_phone, std_program, std_joining_date)" +
                    "VALUES(@id, @fname, @lname, @email, @phone, @program, @date)";
                cmd = new MySqlCommand(query, con);

                //parameters
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@program", program);
                cmd.Parameters.AddWithValue("@date", date);

                //initiate con and exec insert
                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Student registered!");
                        
                    }
                    //close connection
                    con.Close();

                    //refresh the view with lates changes
                    //get_record(txt_id.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }

        private void view_Click(object sender, EventArgs e)
        {            
            get_record(txt_id.Text);
        }

        //reading part
        private void get_record(string id)
        {
            //clears the datagrid
            dataGridView1.Rows.Clear();

            if (string.IsNullOrEmpty(id)) {
                MessageBox.Show("Student ID is necessary.");
            }
            else
            {
                //sql query
                string query = "SELECT * FROM students WHERE  studentID=@id";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);                

                //initiate con and exec select
                try
                {
                    con.Open();

                    adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            populate(row[0].ToString(), row[1].ToString(), row[2].ToString(),
                                row[3].ToString(), row[4].ToString(), row[5].ToString(),
                                row[6].ToString());
                        }

                        //close connection
                        con.Close();

                        //clear dt
                        dt.Rows.Clear();
                    }
                    //close connection
                    con.Close();

                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine("error at get record function");
                    con.Close();
                }
            }

            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clear_fields();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            update_record(txt_id.Text, txt_firstname.Text, txt_lastname.Text,
                txt_email.Text, txt_phone.Text, txt_program.Text, date_joining.Text);
        }

        private void update_record(string id, string fname, string lname, string email, 
            string phone, string program, string date)
        {
            string id2 = id;
            //sql query
            string query = "UPDATE students SET std_firstname='"+ fname +
                "',  std_lastname='" + lname + "',  std_email='" + email + "'" +
                ",  std_phone='" + phone + "',  std_program='" + program + "'" +
                ",  std_joining_date='" + date + "' WHERE studentID='" + id +"'";
            cmd = new MySqlCommand(query, con);

            //initiate con and update 
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = query;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    clear_fields();
                    MessageBox.Show("Records updated.");
                    con.Close();
                }

                con.Clone();

               // get_record(id2);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Console.WriteLine("problem at updating");
                con.Close();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            delete_record(txt_id.Text);
        }

        private void delete_record(string id)
        {
            string query = "DELETE FROM students WHERE studentID='"+id+"'";
            cmd = new MySqlCommand(query, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = query;

                //ask for confirmation
                if (MessageBox.Show("Are you sure you want to delete this student records?", "DELETE",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        clear_fields();
                        MessageBox.Show("Student record deleted.");
                    }
                }
                con.Close();

            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
