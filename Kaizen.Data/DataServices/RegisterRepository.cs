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
    public class RegisterRepository : IRegisterRepository
    {
        public static string SqlConnectionString { get; set; }
        public RegisterRepository()
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
        public string Registeruser(RegisterModel registermodel)
        {
            string msg = "";
            int res;
            try
            {
                    SqlCommand com = new SqlCommand(StoredProcedures.Sp_Register, con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@UserID", registermodel.Name ?? (object)DBNull.Value);
                    com.Parameters.AddWithValue("@EmpID", registermodel.EmpId ?? (object)DBNull.Value);
                    com.Parameters.AddWithValue("@FirstName", registermodel.Name ?? (object)DBNull.Value);
                    com.Parameters.AddWithValue("@Gender", registermodel.Gender ?? (object)DBNull.Value);
                    com.Parameters.AddWithValue("@Did", registermodel.Did);
                    com.Parameters.AddWithValue("@Deptid", registermodel.DeptId);
                    com.Parameters.AddWithValue("@MobileNumber", registermodel.Phoneno ?? (object)DBNull.Value);
                    com.Parameters.AddWithValue("@Email", registermodel.Email ?? (object)DBNull.Value);
                    com.Parameters.AddWithValue("@Password", registermodel.Password ?? (object)DBNull.Value);

                    SqlParameter obreg = new SqlParameter();
                    obreg.ParameterName = "@result";
                    obreg.SqlDbType = SqlDbType.Bit;
                    obreg.Direction = ParameterDirection.Output;
                    com.Parameters.Add(obreg);
                    con.Open();
                    com.ExecuteNonQuery();
                    res = Convert.ToInt32(obreg.Value);
                    con.Close();
                    if (res == 0)
                    {
                        msg = "Success";
                    }
                    else
                    {
                        msg = "Duplicate Emp Id";
                    }
                    return msg;
                
                }
            catch (Exception ex)
            {
                msg = "An error occurred: " + ex.Message; // Log exception
            }
            finally
            {
                con.Close();
            }
            return msg;
        }

    }
}
