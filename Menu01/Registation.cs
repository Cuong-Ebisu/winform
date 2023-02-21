using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;


namespace Menu01
{
    public partial class Registation : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        int ID;
        public Registation()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void Registation_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sqlStr = string.Format("SELECT *FROM EMPLOYEE");

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);

                System.Data.DataTable dtEmployee = new System.Data.DataTable();

                adapter.Fill(dtEmployee);

                gvEmployee.DataSource = dtEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" || txtFName.Text == "" || txtDesign.Text == "" || txtEmail.Text == "" || txtID.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("khong duoc de trong cac thong tin!");
            }
            else
            {
                try
                {
                    conn.Open();

                    string gender;
                    if (rbtnMale.Checked)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }

                    string sqlStr = string.Format("INSERT INTO EMPLOYEE(Employee_Name, Employee_FName, Employee_Degign, Employee_Email, Emp_ID, Gender, Addrss) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", txtName.Text, txtFName.Text, txtDesign.Text, txtEmail.Text, txtID.Text, gender, txtAddress.Text);

                    SqlCommand cmd = new SqlCommand(sqlStr, conn);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("luu thanh cong");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("luu that bai" + ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            display();
        }
        public void display()
        {
            try
            {
                conn.Open();

                string sqlStr = string.Format("SELECT *FROM EMPLOYEE");

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);

                System.Data.DataTable dtEmployee = new System.Data.DataTable();

                adapter.Fill(dtEmployee);

                gvEmployee.DataSource = dtEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtFName.Text == "" || txtDesign.Text == "" || txtEmail.Text == "" || txtID.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("khong duoc de trong cac thong tin!");
            }
            else
            {
                try
                {
                    conn.Open();

                    string gender;
                    if (rbtnMale.Checked)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }

                    string sqlStr = string.Format("UPDATE EMPLOYEE SET Employee_Name ='{0}', Employee_FName = '{1}', Employee_Degign ='{2}', Employee_Email = '{3}', Emp_ID = '{4}', Gender = '{5}', Addrss = '{6}' WHERE (Employee_ID = '{7}')", txtName.Text, txtFName.Text, txtDesign.Text, txtEmail.Text, txtID.Text, gender, txtAddress.Text, ID);

                    SqlCommand cmd = new SqlCommand(sqlStr, conn);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("sua thanh cong");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("sua that bai" + ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string gender;
                if (rbtnMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                string sqlStr = string.Format("DELETE FROM EMPLOYEE WHERE Employee_ID = '{0}' ", ID);

                SqlCommand cmd = new SqlCommand(sqlStr, conn);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("xoa thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("xoa that bai" + ex);
            }
            finally
            {
                conn.Close();
            }
            display();
        }

        private void gvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvEmployee_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ID = int.Parse(gvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = gvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtFName.Text = gvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDesign.Text = gvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = gvEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtID.Text = gvEmployee.Rows[e.RowIndex].Cells[5].Value.ToString();
            rbtnMale.Checked = true;
            rbtnFemale.Checked = false;

            if (gvEmployee.Rows[e.RowIndex].Cells[6].Value.ToString() == "Female")
            {
                rbtnMale.Checked = false;
                rbtnFemale.Checked = true;
            }
            txtAddress.Text = gvEmployee.Rows[e.RowIndex].Cells[7].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM EMPLOYEE WHERE Employee_Name like '%"+txtSearch.Text+"%'", conn);

            System.Data.DataTable dtEmployee = new System.Data.DataTable();

            adapter.Fill(dtEmployee);

            gvEmployee.DataSource = dtEmployee;
            conn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application Excell = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = Excell.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)Excell.ActiveSheet;
                Excell.Visible = true;

                for (int j = 2; j <= gvEmployee.Rows.Count; j++)
                {
                    for (int i = 1; i <= 1; i++)
                    {
                        ws.Cells[j, i] = gvEmployee.Rows[j - 2].Cells[i - 1].Value;
                    }
                }
                for (int i = 1; i < gvEmployee.Columns.Count + 1; i++)
                {
                    ws.Cells[1, i] = gvEmployee.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < gvEmployee.Columns.Count - 1; i++)
                {
                    for (int j = 0; j < gvEmployee.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] = gvEmployee.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
