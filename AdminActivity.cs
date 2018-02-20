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
    public partial class AdminActivity : Form
    {
        String sqlConName = "datasource=localhost;port=3306;username=root;password=root;";
        public AdminActivity()
        {
            InitializeComponent();
        }
        private void closeDbConnection(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private MySqlConnection connectToDb()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(sqlConName);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return con;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = connectToDb();
            String SelectCommand="Select Sum(fin) as Total_fine from library_system.fine;";
            try
            {
                MySqlDataAdapter command2 = new MySqlDataAdapter(SelectCommand, myConn);
                DataSet gatherData = new DataSet();
                command2.Fill(gatherData);
                dataGridView1.DataSource = gatherData.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = connectToDb(); string s="issued";
            String SelectCommand = "Select count(id) as Books_Issued from library_system.book where status='"+s+"';";
            try
            {
                MySqlDataAdapter command2 = new MySqlDataAdapter(SelectCommand, myConn);
                DataSet gatherData = new DataSet();
                command2.Fill(gatherData);
                dataGridView2.DataSource = gatherData.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = connectToDb(); string s = "lost";
            String SelectCommand = "Select count(id) as Books_Lost from library_system.book where status='" + s + "';";
            try
            {
                MySqlDataAdapter command2 = new MySqlDataAdapter(SelectCommand, myConn);
                DataSet gatherData = new DataSet();
                command2.Fill(gatherData);
                dataGridView3.DataSource = gatherData.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = connectToDb(); string s = "avail";
            String SelectCommand = "Select count(id) as Available_Books from library_system.book where status='" + s + "';";
            try
            {
                MySqlDataAdapter command2 = new MySqlDataAdapter(SelectCommand, myConn);
                DataSet gatherData = new DataSet();
                command2.Fill(gatherData);
                dataGridView4.DataSource = gatherData.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
        }
    }
}
