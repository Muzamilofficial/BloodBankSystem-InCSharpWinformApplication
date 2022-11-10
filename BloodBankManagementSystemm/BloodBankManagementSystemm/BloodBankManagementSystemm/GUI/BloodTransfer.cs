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
    public partial class BloodTransfer : Form
    {
        public BloodTransfer()
        {
            InitializeComponent();
            fillPatientCB();
        }
        static string myconnstrn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrn);
        private void fillPatientCB()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select PNum from TblPatient", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PName", typeof(int));
            dt.Load(rdr);
            cbPatientID.ValueMember = "PNum";
            cbPatientID.DataSource = dt;
            conn.Close();
        }
        private void GetData()
        {
            conn.Open();
            string query = "select * from TblPatient where PNum = '" + cbPatientID.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtPatientName.Text = dr["PName"].ToString();
                txtBloodGroup.Text = dr["PBGroup"].ToString();
            }
            conn.Close();
        }
        private void cbPatientID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(txtBloodGroup.Text);
            if (stock > 0)
            {
                btnTransfer.Visible = true;
                lblAvail.Text = "Stock Available";
                lblAvail.Visible = true;
            }
            else
            {
                lblAvail.Text = "Stock is not Available";
                lblAvail.Visible = true;
            }
        }
        int stock=0;
        private void GetStock(string Bgroup)
        {
            conn.Open();
            string query = "select * from TblBlood where BGroup = '" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["BStock"].ToString());
            }
            conn.Close();
        }
        private void Reset()
        {
            txtPatientName.Text = "";
            txtBloodGroup.Text = "";
            lblAvail.Visible = false;
            btnTransfer.Visible = false;
        }
        private void updateStock()
        {
            int newstock = stock - 1;
            try
            {
                string query = "UPDATE TblBlood SET BStock =" + newstock + " where BGroup = '" + txtBloodGroup.Text + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transfered!");
                conn.Close();
                GetStock(txtBloodGroup.Text);
                
                Reset();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text == "")
            {
                MessageBox.Show("Some Information is missing!");
            }
            else
            {
                string query = "INSERT INTO TBLTransfer values ('" + txtPatientName.Text + "','" + txtBloodGroup.Text + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transfered Successfully!");
                conn.Close();
                GetStock(txtBloodGroup.Text);
                Reset();
                updateStock();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor donor = new ViewDonor();
            donor.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewPatient patient = new ViewPatient();
            patient.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            BloodStock bloodTransfer = new BloodStock();
            bloodTransfer.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard bloodTransfer = new Dashboard();
            bloodTransfer.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood bloodTransfer = new DonateBlood();
            bloodTransfer.Show();
            this.Hide();
        }
    }
}
