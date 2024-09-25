using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Kaizen.Data.DataServices
{
    public class RegisterRepository : IRegisterRepository
    {
        string hashedPassword;
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
        //public string Registeruser(RegisterModel registermodel)
        //{
        //    string msg = "";
        //    int res;
        //    try
        //    {
        //        using (SHA256 sha256 = SHA256.Create())
        //        {
        //            byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(registermodel.Password));
        //            StringBuilder hashPasswordBuilder = new StringBuilder();
        //            foreach (byte b in hashValue)
        //            {
        //                hashPasswordBuilder.Append(b.ToString("x2"));
        //            }
        //            hashedPassword = hashPasswordBuilder.ToString();

        //            SqlCommand com = new SqlCommand(StoredProcedures.Sp_Register, con);
        //            com.CommandType = CommandType.StoredProcedure;
        //            com.CommandType = CommandType.StoredProcedure;
        //            com.Parameters.AddWithValue("@UserID", registermodel.Name ?? (object)DBNull.Value);
        //            com.Parameters.AddWithValue("@EmpID", registermodel.EmpId ?? (object)DBNull.Value);
        //            com.Parameters.AddWithValue("@FirstName", registermodel.Name ?? (object)DBNull.Value);
        //            com.Parameters.AddWithValue("@Gender", registermodel.Gender ?? (object)DBNull.Value);
        //            com.Parameters.AddWithValue("@Did", registermodel.Did);
        //            com.Parameters.AddWithValue("@Deptid", registermodel.DeptId);
        //            com.Parameters.AddWithValue("@MobileNumber", registermodel.Phoneno ?? (object)DBNull.Value);
        //            com.Parameters.AddWithValue("@Email", registermodel.Email ?? (object)DBNull.Value);
        //            com.Parameters.AddWithValue("@Password", hashedPassword ?? (object)DBNull.Value);

        //            SqlParameter obreg = new SqlParameter();
        //            obreg.ParameterName = "@result";
        //            obreg.SqlDbType = SqlDbType.Bit;
        //            obreg.Direction = ParameterDirection.Output;
        //            com.Parameters.Add(obreg);
        //            con.Open();
        //            com.ExecuteNonQuery();
        //            res = Convert.ToInt32(obreg.Value);
        //            con.Close();
        //            if (res == 0)
        //            {
        //                msg = "Success";
        //            }
        //            else
        //            {
        //                msg = "Duplicate Emp Id";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = "An error occurred: " + ex.Message; // Log exception
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return msg;
        //}

        /// <summary>
        /// Registers a new user by executing a stored procedure with the provided RegisterModel data and returns a result message.
        /// </summary>
        /// <param name="registermodel">The model containing the user registration data.</param>
        /// <returns>A string message indicating the result of the registration process, such as "Success" or "Duplicate Emp Id".</returns>
        public string Registeruser(RegisterModel registermodel)
        {
            string msg = "";
            int res;
            try
            {
                SqlCommand com = new SqlCommand(StoredProcedures.Sp_Register, con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserID", registermodel.EmpId ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@EmpID", registermodel.EmpId ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@FirstName", registermodel.FirstName ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@MiddleName", registermodel.MiddleName ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@LastName", registermodel.LastName ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@Gender", registermodel.Gender ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@Did", registermodel.Did);
                com.Parameters.AddWithValue("@Deptid", registermodel.DeptId);
                com.Parameters.AddWithValue("@BlockId", registermodel.BlockId);
                com.Parameters.AddWithValue("@MobileNumber", registermodel.Phoneno ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@Email", registermodel.Email ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@Password", registermodel.Password ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@Cadre", registermodel.Cid);

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
