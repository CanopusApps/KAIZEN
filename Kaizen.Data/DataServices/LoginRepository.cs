using DocumentFormat.OpenXml.Spreadsheet;
using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public class LoginRepository : ILoginRepository
    {
        public static string SqlConnectionString { get; set; }
        public LoginRepository() {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
            return builder.Build();
        }
        private static SqlConnection con = null;
        private static SqlCommand com = null;
        public DataTable loginuser(LoginModel loginmodel)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Login", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", loginmodel.EmpId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dataTable);
                return dataTable;

            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                con.Close();
            }
            return dataTable;
        }

        public DataSet usermanager(string EmpId)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_GetUserManager", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", EmpId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public DataSet FetchCountlist()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Fetch_Count", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public bool USERLOGIN(string EmpId)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@USERID", EmpId);
                com.Parameters.AddWithValue("@COMMAND", 0);
                com.CommandText = StoredProcedures.SP_USERLOG;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
        }
        public bool USERLOGOUT(string EmpId)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@USERID", EmpId);
                com.Parameters.AddWithValue("@COMMAND", 1);
                com.CommandText = StoredProcedures.SP_USERLOG;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}             
			return status;
        }

        public DataSet GetWinnerImages()
        {
            DataSet ds = new DataSet();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_LoginWinnerDetails;
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Open();

                com.ExecuteNonQuery();
                con.Close();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return ds;

        }
    }
}
