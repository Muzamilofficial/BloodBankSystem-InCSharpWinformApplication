using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystemm.Classes
{
    class donorprop
    {
        public int DNum { get; set; }
        public string DName { get; set; }
        public int DAge { get; set; }
        public string DGender { get; set; }
        public string DPhone { get; set; }
        public string DAddress { get; set; }
        public string DBGroup { get; set; }
    }
    class donor
    {
        static string myconnstrn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public bool Insert(donorprop donorprop)
        {
            bool isSuccess = false;
            //Object of SQLConnection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrn);
            try
            {
                //SQL Query to get data from database
                String sql = "INSERT INTO TblDonor(DName, DAge, DGender, DPhone, DAddress, DBGroup) " +
                    "VALUES (@DName, @DAge, @DGender, @DPhone, @DAddress, @DBGroup)";
                //SQL Command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters to get the value from UI and pass it on SQL Query above
                cmd.Parameters.AddWithValue("@DName", donorprop.DName);
                cmd.Parameters.AddWithValue("@DAge", donorprop.DAge);
                cmd.Parameters.AddWithValue("@DGender", donorprop.DGender);
                cmd.Parameters.AddWithValue("@DPhone", donorprop.DPhone);
                cmd.Parameters.AddWithValue("@DAddress", donorprop.DAddress);
                cmd.Parameters.AddWithValue("@DBGroup", donorprop.DBGroup);                
                //Open Database Connection
                conn.Open();
                //Integer var to hold value after execution of query
                int rows = cmd.ExecuteNonQuery();
                //Values of rows will be greater than 0 if query executed successfully
                //ELSE it will be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //To close database connection
                conn.Close();
            }
            return isSuccess;
        }

        public DataTable Select()
        {
            //object to connect database
            SqlConnection conn = new SqlConnection(myconnstrn);
            //Database to hold data
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to get data from database
                String sql = "SELECT * FROM TblDonor";
                //SQL Command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //SQL Data Adapter to hold data from database temp.
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open Database Connection
                conn.Open();
                //Transfer Data from SQLDataAdapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //To close database connection
                conn.Close();
            }
            return dt;
        }

        public DataTable Search(string keywords)
        {
            //Object of SQLConnection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrn);
            //Database to hold data
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to search data from database
                String sql = "SELECT * FROM TblDonor WHERE DNum LIKE '%" + keywords + "%' OR DName LIKE '%" + keywords + "%' OR DBGroup LIKE '%" + keywords + "%' ";
                //SQL Command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //SQL Data Adapter to hold data from database temp.
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open Database Connection
                conn.Open();
                //Transfer Data from SQLDataAdapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //To close database connection
                conn.Close();
            }
            return dt;
        }
    }
}
