using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Library_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=root;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            try
            {
                MySqlCommand SelectCommand = new MySqlCommand("select * from library_system.user where email='"+this.username_txt.Text+"' and pass='"+this.password_txt.Text+"';", myConn);
                MySqlDataReader myReader; 
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while(myReader.Read())
                {
                    count++;
                }
                if (count==1)
                {
                    //MessageBox.Show("Username and Password is correct");
                    this.Hide();
                    SearchArtifact s = new SearchArtifact();
                    s.ShowDialog();
                }
                else if(count>1)
                {
                    MessageBox.Show("Duplicate Username and Password...Access Denied.");
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect...Please Try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root;";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from library_system.admin where email='" + this.username_txt.Text + "' and pass='" + this.password_txt.Text + "';", myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                   // MessageBox.Show("Username and Password is correct");
                    this.Hide();
                    AdminActivity a = new AdminActivity();
                    a.Show();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate Username and Password...Access Denied.");
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect...Please Try again");
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frm_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp s = new SignUp();
            s.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
