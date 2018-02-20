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
    public partial class Return : Form
    {
        String sqlConName = "datasource=localhost;port=3306;username=root;password=root;";
        public Return()
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
        private int checkIssue()
        {
            int i = 0;
            MySqlConnection myConn = connectToDb();
            MySqlCommand SelectCommand = new MySqlCommand("select count(id) from library_system.issue where email='"+email_txt.Text+"' and title='"+title_txt.Text+"';", myConn);
            MySqlDataReader myReader;
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Open();
            try
            {
                i = Convert.ToInt32(SelectCommand.ExecuteScalar());
                if(i==0)
                {
                    MessageBox.Show("You have not this book issued");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
            return i;
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
            int i = 0, id = 0;
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
                id = (int)myReader["id"];
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
        private void returnBook(int id)
        {
            MySqlConnection myConn = connectToDb(); string s="issued";
            MySqlCommand SelectCommand = new MySqlCommand("update library_system.book Set status='avail' where title_id='"+id+"' and status='"+s+"' LIMIT 1;", myConn);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
        }
       private int calculateDays()
        {
            string diff2="";
            MySqlConnection myConn = connectToDb(); DateTime s,s1=DateTime.Today;
            MySqlCommand SelectCommand = new MySqlCommand("Select issue_date from library_system.issue where email='"+email_txt.Text+"' and title='"+title_txt.Text+"';", myConn);
            MySqlDataReader myReader;
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Open();
            
            // myReader = SelectCommand.ExecuteReader();
            try
            {
                s = Convert.ToDateTime(SelectCommand.ExecuteScalar());
                //myReader = SelectCommand.ExecuteReader();
               // while(myReader.Read())
                {
                    //s = (DateTime)myReader["issue_date"];
                     diff2 = (s1 - s).TotalDays.ToString();
                    //MessageBox.Show(diff2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
            int i=Convert.ToInt32(diff2);
            return i;
        }
        private void addFine(int fine)
       {
           MySqlConnection myConn = connectToDb();
           MySqlCommand SelectCommand = new MySqlCommand("insert into library_system.fine (email,fin) values('" + email_txt.Text + "','" + fine + "');", myConn);
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
              // MessageBox.Show("Book Issued");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
           closeDbConnection(myConn);
       }
        private void update(int id)
        {
            MySqlConnection myConn = connectToDb();
            MySqlCommand SelectCommand = new MySqlCommand("delete from library_system.issue where email='"+email_txt.Text+"' and title='"+title_txt.Text+"' and artifact_id='"+id+"' LIMIT 1;", myConn);
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
                //MessageBox.Show("Book Issued");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDbConnection(myConn);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int fine = 0, ar = 0 ;
            int b = checkIssue();
            if(b>0)
            {
                if(CheckUser()==1)
                {
                    int id = CheckTitle();
                    if(id>0)
                    {
                        returnBook(id);
                        int days=calculateDays();
                        if(days>30 && id==1)
                        {
                            fine = (days - 30) * 50;
                        }
                        else if(days>15 && id==2)
                        {
                            fine = (days - 15) * 100;
                        }
                        if (fine > 0)
                        {
                            addFine(fine);
                        }
                        MySqlConnection myConn = connectToDb();
                        MySqlCommand SelectCommand = new MySqlCommand("select artifact_id from library_system.book where title_id='"+id + "';", myConn);
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
                            ar = (int)myReader["artifact_id"];
                            //count++;
                        }
                        closeDbConnection(myConn);
                        update(ar);
                        MessageBox.Show("Book Returned");

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
