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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=root;";
            string Query ="insert into library_system.user(fname,email,pass) values('"+this.fname_txt.Text+"','"+this.email_txt.Text+"','"+this.password_txt.Text+"');";
            MySqlConnection conDataBase = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query,conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Signed Up");
                while (myReader.Read())
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frm_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
