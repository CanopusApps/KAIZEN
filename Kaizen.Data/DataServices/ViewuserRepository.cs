using Kaizen.Data.Constant;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices
{
    public class ViewuserRepository : IViewuserRepository
    {
        public static string SqlConnectionString { get; set; }

        public ViewuserRepository()
        {
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

        public DataSet GetUser(UserGridModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(model.Name) ? " " : model.Name);
                com.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(model.Email) ? " " : model.Email);
                com.Parameters.AddWithValue("@EmpID", string.IsNullOrEmpty(model.EmpID) ? " " : model.EmpID);
                com.Parameters.AddWithValue("@UserDesc", model.UserType == "All" ? "" : (string.IsNullOrEmpty(model.UserType) ? " " : model.UserType));
                com.Parameters.AddWithValue("@DomainDesc", model.Domain == "All" ? "" : (string.IsNullOrEmpty(model.Domain) ? " " : model.Domain));
                com.Parameters.AddWithValue("@DepartmentName", model.Department == "All" ? "" : (string.IsNullOrEmpty(model.Department) ? " " : model.Department));

                com.CommandText = StoredProcedures.sp_getUsers;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public bool DeleteUserData(int id)
        {
            bool deleteStatus = false;

            try
            {
                com = new SqlCommand();
                SqlDataAdapter da = null;
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.CommandText = StoredProcedures.sp_Delete_User;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                deleteStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return deleteStatus;
        }

        public DataSet GetStatus()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_Get_Status;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
    }
}
