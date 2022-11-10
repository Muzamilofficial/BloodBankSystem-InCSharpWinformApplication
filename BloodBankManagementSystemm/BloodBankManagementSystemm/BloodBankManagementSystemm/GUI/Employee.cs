using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystemm.GUI
{
    public partial class Employee : Form
    {
        static SqlConnection con = new SqlConnection("Data Source=DESKTOP-0IHE4SQ;Initial Catalog=project;Integrated Security=True");
        static SqlCommand scmd;
        public Employee()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            AdminLogin login = new AdminLogin();
            login.Show();
            this.Hide();
        }
        static string myconnstrn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrn);
        private void Reset()
        {
            txtName.Text = "";
            txtPassword.Text = "";
            key = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Some Information is Missing!");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO TBLEmployee VALUES ('" + txtName.Text + "', '" + txtPassword.Text + "')";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added!");
                    conn.Close();
                    Reset();
                    populate();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void populate()
        {
            conn.Open();
            string query = "select * from TBLEmployee";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvEmployee.DataSource = ds.Tables[0];
            conn.Close();
        }
        int key = 0;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Employee to Delete!");
            }
            else
            {
                try
                {
                    string query = "DELETE FROM TBLEmployee WHERE ENum = " + key + ";";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted!");
                    conn.Close();
                    Reset();
                    populate();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Some Information is missing!");
            }
            else
            {
                try
                {
                    string query = "UPDATE TBLEmployee SET EID = '" + txtName.Text + "', EPass = '" + txtPassword.Text + "' WHERE ENum = " + key + ";";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Edited!");
                    conn.Close();
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dgvEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtName.Text = dgvEmployee.SelectedRows[0].Cells[1].Value.ToString();
            txtPassword.Text = dgvEmployee.SelectedRows[0].Cells[2].Value.ToString();
            if (txtName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
