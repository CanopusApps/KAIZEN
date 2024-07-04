using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			{
				string msg = "";
				int res;
				try
				{
					SqlCommand com = new SqlCommand(StoredProcedures.Sp_Update_Users, con);
					com.CommandType = CommandType.StoredProcedure;
					com.Parameters.AddWithValue("@EmployeeID", editUserModel.EmpID);
					com.Parameters.AddWithValue("@FirstName", editUserModel.FirstName);
					if(editUserModel.MiddleName==null)
					{
                        com.Parameters.AddWithValue("@MiddleName", DBNull.Value);
                    }
					else
					{
                        com.Parameters.AddWithValue("@MiddleName", editUserModel.MiddleName);
                    }
                    
                    com.Parameters.AddWithValue("@LastName", editUserModel.LastName);
                    com.Parameters.AddWithValue("@Email", editUserModel.Email);
					//com.Parameters.AddWithValue("@Password", editUserModel.Password);
					com.Parameters.AddWithValue("@PhoneNo", editUserModel.PhoneNo);
					com.Parameters.AddWithValue("@Gender", editUserModel.Gender.Substring(0, 1));
					com.Parameters.AddWithValue("@Cid", editUserModel.Cid);
					com.Parameters.AddWithValue("@Rid", editUserModel.Rid);
					com.Parameters.AddWithValue("@Status", editUserModel.StatusName);
					com.Parameters.AddWithValue("@Did", editUserModel.Did);
					com.Parameters.AddWithValue("@Deptid", editUserModel.DeptId);
					com.Parameters.AddWithValue("@ImageApprover", editUserModel.ImageApprover);
					com.Parameters.AddWithValue("@ModifiedEmpId", editUserModel.ModifiedBy);
                    SqlParameter obreg = new SqlParameter();
					obreg.ParameterName = "@result";
					obreg.SqlDbType = SqlDbType.Bit;
					obreg.Direction = ParameterDirection.Output;
					com.Parameters.Add(obreg);
					con.Open();
					com.ExecuteNonQuery();
					res = Convert.ToInt32(obreg.Value);
					con.Close();
					if (res == 1)
					{
						msg = "ok";
					}
					else
					{
						msg = "Employee doesnot exist.";
					}
					return msg;
				}
				catch (Exception ex)
				{
					if (con.State == ConnectionState.Open)
					{
						msg = ex.Message;
						con.Close();
					}

				}
				return msg;
			}
		}
	}
}
