using Kaizen.Data.Constant;

using Kaizen.Models.AdminModel;
using Kaizen.Models.ViewUserModel;
using Microsoft.Extensions.Configuration;

using System.Data;

using System.Data.SqlClient;

using System.Linq;

using System.Reflection;

using System.Text;

using System.Threading.Tasks;

namespace Kaizen.Data.DataServices

{
	public class DepartmentRepository : IDepartmentRepository
	{
		public static string SqlConnectionString { get; set; }

		public DepartmentRepository()
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


		public bool InsertDepartment(string DomainName, int DomainId, string DepartmentName)
		{
			bool status = false;
			try
			{

				com = new SqlCommand();
				DataTable dt = new DataTable();
				com.Connection = con;
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("@DomainId", DomainId);
				com.Parameters.AddWithValue("@DomainName", DomainName);
				com.Parameters.AddWithValue("@DepartmentName", DepartmentName);
				com.CommandText = StoredProcedures.sp_InsertDepartment;
				con.Open();
				com.ExecuteNonQuery();
				con.Close();
				status = true;
			}
			catch (Exception ex)
			{
			}

			return status;

		}

		// For View record
		public bool DeleteDepartment(int id)
		{
			bool status = false;

			try
			{
				com = new SqlCommand();
				com.Connection = con;
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("@Id", id);
				com.CommandText = StoredProcedures.sp_DeleteDepartment;
				con.Open();
				com.ExecuteNonQuery();
				con.Close();
				status = true;
			}
			catch (Exception ex)
			{

			}

			return status;
		}

		public bool UpdateDepartmentStatus(int id, bool status)
		{
			bool updStatus = false;

			try
			{
				com = new SqlCommand();
				com.Connection = con;
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("@Id", id);
				com.Parameters.AddWithValue("@status", status);
				//com.Parameters.AddWithValue("@blockname", model.blockName);
				//com.Parameters.AddWithValue("@flag", model.flag);
				com.CommandText = StoredProcedures.sp_UpdateDepartmentStatus;
				con.Open();
				com.ExecuteNonQuery();
				con.Close();
				updStatus = true;
			}
			catch (Exception ex)
			{

			}

			return updStatus;
		}
		// For View record
		public DataSet GetDepartments()
		{
			DataSet ds = new DataSet();
			try
			{
				com = new SqlCommand();
				com.Connection = con;
				com.CommandType = CommandType.StoredProcedure;
				com.CommandText = StoredProcedures.Sp_GetDepartments;
				SqlDataAdapter da = new SqlDataAdapter(com);
				da.Fill(ds);
			}
			catch (Exception ex)
			{

			}
			return ds;
		}		

		//public DataSet GetDepartment(string DomainName)
		//{
		//	com = new SqlCommand();
		//	DataSet ds = new DataSet();
		//	com.Connection = con;
		//	com.CommandType = CommandType.StoredProcedure;
		//	com.Parameters.AddWithValue("@DomainName", DomainName);
		//	com.CommandText = StoredProcedures.sp_Fetch_Department;

		//	SqlDataAdapter da = new SqlDataAdapter(com);
		//	da.Fill(ds);
		//	return ds;
		//}

	}

}
