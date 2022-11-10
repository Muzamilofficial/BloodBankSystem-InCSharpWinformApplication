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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        static string myconnstrn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrn);
        private void GetData()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM TblDonor", conn);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            label14.Text = dataTable.Rows[0][0].ToString();
            SqlDataAdapter sda0 = new SqlDataAdapter("SELECT COUNT(*) FROM TBLTransfer", conn);
            DataTable dataTable0 = new DataTable();
            sda0.Fill(dataTable0);
            label15.Text = dataTable0.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT COUNT(*) FROM TBLEmployee", conn);
            DataTable dataTable1 = new DataTable();
            sda1.Fill(dataTable1);
            label16.Text = dataTable1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood", conn);
            DataTable dataTable2 = new DataTable();
            sda2.Fill(dataTable2);
            int BStock = int.Parse(dataTable2.Rows[0][0].ToString());
            lbltotal.Text = "" + BStock;

            SqlDataAdapter sda10 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "O+" + "'", conn);
            DataTable dataTable10 = new DataTable();
            sda10.Fill(dataTable10);            
            double OPLUS = (Convert.ToDouble(dataTable10.Rows[0][0].ToString()) / BStock) * 100;
            ////progressBar1.Value = Convert.ToInt32(OPLUS);

            SqlDataAdapter sda11 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "O-" + "'", conn);
            DataTable dataTable11 = new DataTable();
            sda11.Fill(dataTable11);            
            double ONeg = (Convert.ToDouble(dataTable11.Rows[0][0].ToString()) / BStock) * 100;
            //progressBar2.Value = Convert.ToInt32(ONeg);

            SqlDataAdapter sda12 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "A+" + "'", conn);
            DataTable dataTable12 = new DataTable();
            sda12.Fill(dataTable12);            
            double APLUS = (Convert.ToDouble(dataTable12.Rows[0][0].ToString()) / BStock) * 100;
           // progressBar3.Value = Convert.ToInt32(APLUS);

            SqlDataAdapter sda13 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "A-" + "'", conn);
            DataTable dataTable13 = new DataTable();
            sda13.Fill(dataTable13);            
            double ANeg = (Convert.ToDouble(dataTable13.Rows[0][0].ToString()) / BStock) * 100;
            //progressBar4.Value = Convert.ToInt32(ANeg);

            SqlDataAdapter sda14 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "B+" + "'", conn);
            DataTable dataTable14 = new DataTable();
            sda14.Fill(dataTable14);            
            double BPLUS = (Convert.ToDouble(dataTable14.Rows[0][0].ToString()) / BStock) * 100;
            //progressBar5.Value = Convert.ToInt32(BPLUS);

            SqlDataAdapter sda15 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "B-" + "'", conn);
            DataTable dataTable15 = new DataTable();
            sda15.Fill(dataTable15);            
            double BNEG = (Convert.ToDouble(dataTable15.Rows[0][0].ToString()) / BStock) * 100;
            //progressBar6.Value = Convert.ToInt32(BNEG);

            SqlDataAdapter sda16 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "AB+" + "'", conn);
            DataTable dataTable16 = new DataTable();
            sda16.Fill(dataTable16);            
            double ABPLUS = (Convert.ToDouble(dataTable16.Rows[0][0].ToString()) / BStock) * 100;
            //progressBar7.Value = Convert.ToInt32(ABPLUS);

            SqlDataAdapter sda17 = new SqlDataAdapter("SELECT COUNT(*) FROM TblBlood WHERE BGroup ='" + "AB-" + "'", conn);
            DataTable dataTable17 = new DataTable();
            sda17.Fill(dataTable17);            
            double ABNEG = (Convert.ToDouble(dataTable17.Rows[0][0].ToString()) / BStock) * 100;
            //progressBar8.Value = Convert.ToInt32(ABNEG);
            conn.Close();
        }
        private void GetBloodStock()
        {
            conn.Open();
            
            conn.Close();
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

        private void label8_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodTransfer = new BloodTransfer();
            bloodTransfer.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood bloodTransfer = new DonateBlood();
            bloodTransfer.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            GetData();
            GetBloodStock();
        }
    }
}
