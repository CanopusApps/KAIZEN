using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Kaizen.Data.DataServices
{
	public class EditUserRepository : IEditUserRepository
	{
		public static string SqlConnectionString { get; set; }
		private static SqlConnection con = null;
		private static SqlCommand com = null;
		SqlDataAdapter da = null;
		public EditUserRepository()
		{
			var configuration = GetConfiguration();
			con = new SqlConnection(configuration.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);
		}
		public IConfigurationRoot GetConfiguration()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
			return builder.Build();
		}

        public string EditUserData(EditUserModel editUserModel)
        {
            string msg = "";
            try
            {
                using (SqlCommand com = new SqlCommand(StoredProcedures.Sp_Update_Users, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EmployeeID", editUserModel.EmpID);
                    com.Parameters.AddWithValue("@FirstName", editUserModel.FirstName);
                    com.Parameters.AddWithValue("@MiddleName", string.IsNullOrEmpty(editUserModel.MiddleName) ? (object)DBNull.Value : editUserModel.MiddleName);
                    com.Parameters.AddWithValue("@LastName", editUserModel.LastName);
                    com.Parameters.AddWithValue("@Email", editUserModel.Email);
                    com.Parameters.AddWithValue("@PhoneNo", editUserModel.PhoneNo);
                    com.Parameters.AddWithValue("@Gender", editUserModel.Gender.Substring(0, 1));
                    com.Parameters.AddWithValue("@Cid", editUserModel.Cid);
                    com.Parameters.AddWithValue("@Rid", editUserModel.Rid);
                    com.Parameters.AddWithValue("@Status", editUserModel.StatusName);
                    com.Parameters.AddWithValue("@Did", editUserModel.Did);
                    com.Parameters.AddWithValue("@Deptid", editUserModel.DeptId);
                    com.Parameters.AddWithValue("@ImageApprover", editUserModel.ImageApprover);
                    com.Parameters.AddWithValue("@BlockId", editUserModel.BlockId);
                    com.Parameters.AddWithValue("@ModifiedEmpId", editUserModel.ModifiedBy);

                    com.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                    com.Parameters.Add(new SqlParameter("@ReturnMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output });
                    com.Parameters.Add(new SqlParameter("@ReturnUser", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output });

                    con.Open();
                    com.ExecuteNonQuery();

                    var resultParam = com.Parameters["@result"].Value;
                    int res = resultParam == DBNull.Value ? 0 : Convert.ToInt32(resultParam);

                    var returnMessageParam = com.Parameters["@ReturnMessage"].Value;
                    string returnMessage = returnMessageParam == DBNull.Value ? string.Empty : Convert.ToString(returnMessageParam);

                    var returnMessageuser = com.Parameters["@ReturnUser"].Value;
                    string returnMes = returnMessageuser == DBNull.Value ? string.Empty : Convert.ToString(returnMessageuser);

                    if (!string.IsNullOrEmpty(returnMessage))
                    {
                        msg = "returnMessage";
                    }
                    else if (res == 1)
                    {
                        msg = "ok";
                    }
                    else if (!string.IsNullOrEmpty(returnMes))
                    {
                        msg = "Usertype";
                    }
                    else
                    {
                        msg = "Employee does not exist.";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }


    }
}
