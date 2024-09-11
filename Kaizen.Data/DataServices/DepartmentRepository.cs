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


        public bool CreateDepartmentData(DepartmentModel departmentModel)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@DomainId", departmentModel.DomainId);
                com.Parameters.AddWithValue("@DomainName", departmentModel.DomainName);
                com.Parameters.AddWithValue("@department", departmentModel.DepartmentName);
                com.Parameters.AddWithValue("@Createdby", departmentModel.CreatedBy);
                com.CommandText = StoredProcedures.sp_InsertDepartment;
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
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
        }
        public bool UpdateDepartmentStatus(int id, bool status)
        {
            bool updStatus = false;
            string message = string.Empty;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", id);
                com.Parameters.AddWithValue("@status", status);
                com.CommandText = StoredProcedures.sp_UpdateDepartmentStatus;
                SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };
                com.Parameters.Add(messageParam);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                message = messageParam.Value.ToString();
                if (!string.IsNullOrEmpty(message))
                {
                    updStatus = false;
                }
                else
                {
                    updStatus = true;
                }
            }
            catch (Exception ex)
            {

            }
			finally
			{
				con.Close();
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
                throw ex;
            }
            return ds;
        }
        public DataSet GetDomainData()
        {
            com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = StoredProcedures.Sp_GetDomains;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }
        public bool UpdateDepartmentDetails(DepartmentModel departmentmodel)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@deptId", departmentmodel.DeptId);
                com.Parameters.AddWithValue("@DomainId", departmentmodel.DomainId);
                com.Parameters.AddWithValue("@DomainName", departmentmodel.DomainName);
                com.Parameters.AddWithValue("@department", departmentmodel.DepartmentName);
                com.Parameters.AddWithValue("@ModifiedBy", departmentmodel.ModifiedBY);
                com.CommandText = StoredProcedures.Sp_UpdateDepartment;
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
    }	

}
