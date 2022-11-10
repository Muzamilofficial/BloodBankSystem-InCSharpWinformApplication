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
    public partial class ViewPatient : Form
    {
        public ViewPatient()
        {
            InitializeComponent();
        }
        patientprop patientprop = new patientprop();
        patient patient = new patient();
        private void ViewPatient_Load(object sender, EventArgs e)
        {
            DataTable dataTable = patient.Select();
            dgvViewPatient.DataSource = dataTable;
        }

        private void dgvViewPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            txtName.Text = dgvViewPatient.Rows[RowIndex].Cells[1].Value.ToString();
            txtAge.Text = dgvViewPatient.Rows[RowIndex].Cells[2].Value.ToString();
            txtPhone.Text = dgvViewPatient.Rows[RowIndex].Cells[4].Value.ToString();
            cbGender.SelectedItem = dgvViewPatient.Rows[RowIndex].Cells[3].Value.ToString();
            cbBGroup.SelectedItem = dgvViewPatient.Rows[RowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvViewPatient.Rows[RowIndex].Cells[5].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAge.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || cbBGroup.SelectedIndex == -1 || cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Some Information is missing!");
            }
            else
            {
                //Fetch values from Form            
                patientprop.PName = txtName.Text;
                patientprop.PAge = int.Parse(txtAge.Text);
                patientprop.PPhone = txtPhone.Text;
                patientprop.PGender = cbGender.SelectedItem.ToString();
                patientprop.PAddress = txtAddress.Text;
                patientprop.PBGroup = cbBGroup.SelectedItem.ToString();
                //Boolean variable to check data updated successfully or not
                bool success = patient.Update(patientprop);
                if (success == true)
                {
                    MessageBox.Show("Patient Detail Updated!");
                    //Clearing TextBoxes
                    Clear();
                    //Refresh data in DGV
                    DataTable dt = patient.Select();
                    dgvViewPatient.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Fail to Update Patient Detail!");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAge.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || cbBGroup.SelectedIndex == -1 || cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Some Information is missing!");
            }
            else
            {
                //Boolean variable to check data deleted successfully or not
                bool success = patient.Delete(patientprop);
                if (success == true)
                {
                    MessageBox.Show("Patient Deleted!");
                    //Clearing TextBoxes
                    Clear();
                    //Refresh data in DGV
                    DataTable dt = patient.Select();
                    dgvViewPatient.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Fail to delete Patient!");
                }
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