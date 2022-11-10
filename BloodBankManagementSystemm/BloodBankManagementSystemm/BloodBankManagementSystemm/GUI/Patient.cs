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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }
        patientprop patientprop = new patientprop();
        patient patient = new patient();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAge.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || cbBGroup.SelectedIndex == -1 || cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Some Information is missing!");
            }
            else
            {
                patientprop.PName = txtName.Text;
                patientprop.PAge = int.Parse(txtAge.Text);
                patientprop.PGender = cbGender.SelectedItem.ToString();
                patientprop.PPhone = txtPhone.Text;
                patientprop.PAddress = txtAddress.Text;
                patientprop.PBGroup = cbBGroup.SelectedItem.ToString();
                bool success = patient.Insert(patientprop);
                if (success == true)
                {
                    MessageBox.Show("Patient added!");
                    //Clearing TextBoxes
                    Clear();
                }
                else
                {
                    MessageBox.Show("Fail to add new Patient!");
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
            cbBGroup.SelectedIndex = -1;
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

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
            this.Hide();
        }
    }
}
