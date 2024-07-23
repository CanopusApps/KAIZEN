using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kaizen.Data.DataServices
{
    public class ProfileRepository : IProfileRepository
    {
        public static string SqlConnectionString { get; set; }
        private static SqlConnection con = null;
        private static SqlCommand com = null;
        SqlDataAdapter da = null;
        public ProfileRepository()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public DataTable UserProfileData(ProfileModel profileModel)
        {
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_Get_KaizenProfileDetails;
                com.Parameters.AddWithValue("@EmpId", profileModel.EmpID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public bool UpdateUserProfileData(ProfileModel model)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_UserProfile;
                com.Parameters.AddWithValue("@EmpID", model.EmpID);
                com.Parameters.AddWithValue("@FirstName", model.FirstName);
                com.Parameters.AddWithValue("@MiddleName", model.MiddleName);
                com.Parameters.AddWithValue("@LastName", model.LastName);
                com.Parameters.AddWithValue("@Email", model.Email);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close(); 
            }
            return status;
        }
    }
}