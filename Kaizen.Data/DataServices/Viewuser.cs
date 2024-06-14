using Kaizen.Data.Constant;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Kaizen.Models.ViewUserModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices
{
    public class Viewuser : IViewuserData
    {
        public static string SqlConnectionString { get; set; }

        public Viewuser()
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

        public DataSet GetUserType(UserTypeModel model)
        {
            model.flag = "get";
            com = new SqlCommand();
            DataSet ds = new DataSet();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_Fetch_UserType;
              
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                return ds;
        }
        public DataSet GetDomain(DomainModel model)
        {
            model.flag = "get";
            com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = StoredProcedures.Sp_Fetch_Domain;

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }
        public DataSet GetDepartment(string DomainName)
        {
            com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DomainName", DomainName);
            com.CommandText = StoredProcedures.Sp_Fetch_Department;

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }
        public DataSet GetUser(UserGridModel model)
        {
            com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(model.Name) ? " " : model.Name);
            com.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(model.Email) ? " " : model.Email);
            com.Parameters.AddWithValue("@EmpID", string.IsNullOrEmpty(model.EmpID) ? " " : model.EmpID);
            com.Parameters.AddWithValue("@UserDesc", model.UserType == "All" ? "" : (string.IsNullOrEmpty(model.UserType) ? " " : model.UserType));
            com.Parameters.AddWithValue("@DomainDesc", model.Domain == "All" ? "" : (string.IsNullOrEmpty(model.Domain) ? " " : model.Domain));
            com.Parameters.AddWithValue("@DepartmentName", model.Department == "All" ? "" : (string.IsNullOrEmpty(model.Department) ? " " : model.Department));

            com.CommandText = StoredProcedures.Fetch_User;

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }
        public string DeleteUserData(UserGridModel model)
        {
            string msg = "";

            try
            {
                com = new SqlCommand();
                SqlDataAdapter da = null;
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", model.EmpID);
                com.CommandText = StoredProcedures.Sp_Delete_User;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Block Deleted Successfully !!";
            }
            catch (Exception ex) { }

            return msg;
        }
    }
}
