using BloodBankManagementSystemm.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystemm.GUI
{
    public partial class ViewDonor : Form
    {
        public ViewDonor()
        {
            InitializeComponent();
        }
        donorprop donorprop = new donorprop();
        donor donor = new donor();
        private void ViewDonor_Load(object sender, EventArgs e)
        {
            DataTable dataTable = donor.Select();
            dgvViewDonor.DataSource = dataTable;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the users based on keywords
            String keywords = txtSearch.Text;
            //Textbox is empty or not
            if (keywords != null)
            {
                //IF textbox is not empty display users on DGV based on keywords
                DataTable dt = donor.Search(keywords);
                dgvViewDonor.DataSource = dt;
            }
            else
            {
                //Display all users
                DataTable dataTable = donor.Select();
                dgvViewDonor.DataSource = dataTable;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard donateBlood = new Dashboard();
            donateBlood.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donateBlood = new Donor();
            donateBlood.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient donateBlood = new Patient();
            donateBlood.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewPatient donateBlood = new ViewPatient();
            donateBlood.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            BloodStock donateBlood = new BloodStock();
            donateBlood.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            BloodTransfer donateBlood = new BloodTransfer();
            donateBlood.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
            this.Hide();
        }
    }
}
