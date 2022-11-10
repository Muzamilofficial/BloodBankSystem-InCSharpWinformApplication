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
    class patientprop
    {
        public int PNum { get; set; }
        public string PName { get; set; }
        public int PAge { get; set; }
        public string PGender { get; set; }
        public string PPhone { get; set; }
        public string PAddress { get; set; }
        public string PBGroup { get; set; }
    }
    class patient
    {
        static string myconnstrn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public bool Insert(patientprop patientprop)
        {
            bool isSuccess = false;
            //Object of SQLConnection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrn);
            try
            {
                //SQL Query to get data from database
                String sql = "INSERT INTO TblPatient(PName, [PAge], PGender, PPhone, PAddress, PBGroup) " +
                    "VALUES (@PName, @PAge, @PGender, @PPhone, @PAddress, @PBGroup)";
                //SQL Command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters to get the value from UI and pass it on SQL Query above
                cmd.Parameters.AddWithValue("@PName", patientprop.PName);
                cmd.Parameters.AddWithValue("@PAge", patientprop.PAge);
                cmd.Parameters.AddWithValue("@PGender", patientprop.PGender);
                cmd.Parameters.AddWithValue("@PPhone", patientprop.PPhone);
                cmd.Parameters.AddWithValue("@PAddress", patientprop.PAddress);
                cmd.Parameters.AddWithValue("@PBGroup", patientprop.PBGroup);
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
                String sql = "SELECT * FROM TblPatient";
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
                String sql = "SELECT * FROM TblPatient WHERE PNum LIKE '%" + keywords + "%' OR PName LIKE '%" + keywords + "%' OR PBGroup LIKE '%" + keywords + "%' ";
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

        public bool Update(patientprop patientprop)
        {
            bool isSuccess = false;
            //Object of SQLConnection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrn);
            try
            {
                //SQL Query to hold data
                string sql = "UPDATE TblPatient SET PName=@PName, [PAge]=@PAge, PGender=@PGender, PPhone=@PPhone, PAddress=@PAddress, PBGroup=@PBGroup WHERE PNum=@PNum";
                //SQL Command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters to get the value from UI and pass it on SQL Query above
                cmd.Parameters.AddWithValue("@PName", patientprop.PName);
                cmd.Parameters.AddWithValue("@PAge", patientprop.PAge);
                cmd.Parameters.AddWithValue("@PGender", patientprop.PGender);
                cmd.Parameters.AddWithValue("@PPhone", patientprop.PPhone);
                cmd.Parameters.AddWithValue("@PAddress", patientprop.PAddress);
                cmd.Parameters.AddWithValue("@PBGroup", patientprop.PBGroup);
                cmd.Parameters.AddWithValue("@PNum", patientprop.PNum);
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
        public bool Delete(patientprop patientprop)
        {
            bool isSuccess = false;
            //Object of SQLConnection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrn);
            try
            {
                //String Var to delete data
                String sql = "DELETE FROM TblPatient WHERE PNum=@PNum";
                //SQL Command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters to get the value from UI and pass it on SQL Query above
                cmd.Parameters.AddWithValue("@PNum", patientprop.PNum);
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
    }
}
