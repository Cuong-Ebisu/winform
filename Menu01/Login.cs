using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Menu01
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUserName.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter user name and password");
                }
                else
                {
                    conn.Open();
                    string sqlStr = string.Format("SELECT *FROM UserLogin");
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if(txtUserName.Text == "admin" && txtPassword.Text == "admin")
                    {
                        MessageBox.Show("You have successfully logged in");
                        Form1 form= new Form1();
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please check user name and password");
                    }

                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();   
            }
        }
    }
}
