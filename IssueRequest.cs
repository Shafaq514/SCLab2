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
    public partial class IssueRequest : Form
    {
        String sqlConName = "datasource=localhost;port=3306;username=root;password=root;";
        public IssueRequest()
        {
            InitializeComponent();
        }
        private void initInputBox()
        {
            //loadCombo(artifact_combo, "library_system", "artifact", "name", "id");
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
        private void closeDbConnection(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private int CheckUser()
        {
            int i = 0;
            MySqlConnection myConn = connectToDb();
            MySqlCommand SelectCommand = new MySqlCommand("select * from library_system.user where email='" + this.email_txt.Text + "';", myConn);
            MySqlDataReader myReader;
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    i = 1;
                }
                else
                {
                    MessageBox.Show("Email does not exists");
                }
            closeDbConnection(myConn);
            return i;
        }
        private int CheckTitle()
        {
            int i = 0,id=0;
            MySqlConnection myConn = connectToDb();
            MySqlCommand SelectCommand = new MySqlCommand("select id from library_system.title where name='" + this.title_txt.Text + "';", myConn);
            MySqlDataReader myReader;
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Open();
            myReader = SelectCommand.ExecuteReader();
           // int count = 0;
            while (myReader.Read())
            {
                id=(int)myReader["id"];
                //count++;
            }
            if (id > 0)
            {
                i = 1;
            }
            else
            {
                MessageBox.Show("Title does not exists");
            }
            closeDbConnection(myConn);
            return id;
        }
        private int checkBook(int id)
        {
            string s = "avail"; int i = 0,ret=0;
            MySqlConnection myConn = connectToDb();
            MySqlCommand SelectCommand = new MySqlCommand("Select artifact_id from library_system.book where title_id='" + id + "'and status='" + s + "';", myConn);
            MySqlDataReader myReader;
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Open();
            myReader = SelectCommand.ExecuteReader();
            // int count = 0;
            while (myReader.Read())
            {
                i = (int)myReader["artifact_id"];
                //count++;
            }
            if(i>0)
            {
                ret = i;
            }
            else
            {
                MessageBox.Show("Book is not available");
            }
            closeDbConnection(myConn);
            return ret;
        }
        private void issueBook(int cb)
        {
            DateTime thisDay = DateTime.Today;
            String publishDate = thisDay.ToString("yyyy-MM-dd");
            MySqlConnection myConn = connectToDb();
            MySqlCommand SelectCommand = new MySqlCommand("insert into library_system.issue(email,title,issue_date,artifact_id) values('"+email_txt.Text+"','"+title_txt.Text+"','"+publishDate+"','"+cb+"');", myConn);
            MySqlDataReader myReader;
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Open();
           // myReader = SelectCommand.ExecuteReader();
            try
            {
                myReader = SelectCommand.ExecuteReader();
                MessageBox.Show("Book Issued");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
        }
        private int checkIssue(int cb)
        {
            int i = 0;
            MySqlConnection myConn = connectToDb();
            MySqlCommand SelectCommand = new MySqlCommand("select count(id) from library_system.issue where email='"+email_txt.Text+"' and artifact_id="+cb+";", myConn);
            MySqlDataReader myReader;
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Open();
            try
            {
                i=Convert.ToInt32(SelectCommand.ExecuteScalar());
                if((i>=3 && cb==1)||(i>=2 && cb==2))
                {
                    i = 0;
                    MessageBox.Show("You Already have reached limit");
                }
                else
                {
                    i = 1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
            return i;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckUser()==1)
            {
                int id = CheckTitle();
                if(id>0)
                {
                    int cb = checkBook(id);
                    if(cb>0)
                    {
                        if (checkIssue(cb) == 1)
                        {
                            issueBook(cb);
                            SearchArtifact sa = new SearchArtifact();
                            this.Hide();
                            sa.ShowDialog();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
        }
    }
}
