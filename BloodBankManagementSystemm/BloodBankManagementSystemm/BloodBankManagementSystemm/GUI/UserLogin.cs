using BloodBankManagementSystemm.GUI;
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

namespace BloodBankManagementSystemm
{
    public partial class frmLogin : Form
    {
        static SqlConnection con = new SqlConnection("Data Source=DESKTOP-0IHE4SQ;Initial Catalog=assigment1;Integrated Security=True");
        static SqlCommand scmd;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin admin = new AdminLogin();
            admin.Show();
            this.Hide();
        }
        static string myconnstrn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrn);
        private void btnlogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM TBLEmployee WHERE EID = '" + txtusername.Text + "' and EPass = '" + txtpassword.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Dashboard mainForm = new Dashboard();
                mainForm.Show();
                this.Hide();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password!");
            }
            conn.Close();
        }
    }
}
