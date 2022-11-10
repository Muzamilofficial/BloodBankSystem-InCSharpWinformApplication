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
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }
        donorprop donorprop = new donorprop();
        donor donor = new donor();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text=="" || txtAge.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || cbBloodGroup.SelectedIndex == -1 || cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Some Information is missing!");
            }
            else
            {
                donorprop.DName = txtName.Text;
                donorprop.DAge = int.Parse(txtAge.Text);
                donorprop.DGender = cbGender.SelectedItem.ToString();
                donorprop.DPhone = txtPhone.Text;
                donorprop.DAddress = txtAddress.Text;
                donorprop.DBGroup = cbBloodGroup.SelectedItem.ToString();
                bool success = donor.Insert(donorprop);
                if (success == true)
                {
                    MessageBox.Show("Donor added!");
                    //Clearing TextBoxes
                    Clear();                    
                }
                else
                {
                    MessageBox.Show("Fail to add new donor!");
                }
            }
        }
        public void Clear()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            cbGender.SelectedIndex = -1;
            cbBloodGroup.SelectedIndex = -1;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard donateBlood = new Dashboard();
            donateBlood.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor donateBlood = new ViewDonor();
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
    }
}
