using System.Data;
using System.Data.SqlClient;
using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;

namespace Kaizen.Data.DataServices
{
    public class ForgotPasswordRepository : IForgotPasswordRepository
    {
        public static string SqlConnectionString { get; set; }
        public ForgotPasswordRepository()
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
        public string FetchEmail(string id)
        {
            string email = string.Empty;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.SpFetchEmail;
                com.Parameters.AddWithValue("@Id", id);

                con.Open();
                object result = com.ExecuteScalar();
                if (result != null)
                {
                    email = result.ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return email;
        }
        public bool UpdatePassword(LoginModel model)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.SpUpdatePassword;
                com.Parameters.AddWithValue("@Id", model.EmpId);
                com.Parameters.AddWithValue("@Pwd", model.Password);

                con.Open();
                int rowsAffected = com.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
                con.Close();
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
    }
}
