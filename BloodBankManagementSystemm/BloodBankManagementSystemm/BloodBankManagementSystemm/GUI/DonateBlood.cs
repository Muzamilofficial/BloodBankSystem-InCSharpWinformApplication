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
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            BloodStock();
        }
        static string myconnstrn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrn);
        private void populate()
        {
            conn.Open();
            string query = "select * from TblDonor";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvViewDonor.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void BloodStock()
        {
            conn.Open();
            string query = "select * from TblBlood";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvBloodStock.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void DonateBlood_Load(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            txtbloodgroup.Text = "";
            txtName.Text = "";
        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            conn.Open();
            string query = "select * from TblBlood where BGroup = '" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
            conn.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Select a Donor");
            }
            else
            {
                try
                {
                    int stock = oldstock + 1;
                    string query = "UPDATE TblBlood SET BStock = " + stock + " where BGroup = '" + txtbloodgroup.Text + "'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Donated!");
                    conn.Close();
                    Reset();
                    BloodStock();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dgvViewDonor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtName.Text = dgvViewDonor.SelectedRows[0].Cells[1].Value.ToString();
            txtbloodgroup.Text = dgvViewDonor.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(txtbloodgroup.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodTransfer = new BloodTransfer();
            bloodTransfer.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            BloodStock bloodTransfer = new BloodStock();
            bloodTransfer.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewPatient bloodTransfer = new ViewPatient();
            bloodTransfer.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor patient = new ViewDonor();
            patient.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor patient = new Donor();
            patient.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard patient = new Dashboard();
            patient.Show();
            this.Hide();
        }
    }
}
