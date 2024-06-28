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
	public class DomainRepository : IDomainRepository
	{
		public static string SqlConnectionString { get; set; }

		public DomainRepository()
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


		public bool InsertDomain(DomainModel domainmodel)
		{
			bool status = false;
			try
			{

				com = new SqlCommand();
				DataTable dt = new DataTable();
				com.Connection = con;
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("@DomainName", domainmodel.DomainName);
				com.Parameters.AddWithValue("@CreatedBy", domainmodel.CreatedBy);
				com.CommandText = StoredProcedures.sp_InsertDomain;
				con.Open();
				com.ExecuteNonQuery();
				con.Close();
				status = true;
			}
			catch (Exception ex)
			{
                throw ex;
            }

			return status;

		}

		// For View record
		public bool DeleteDomain(int id)
		{
			bool status = false;

			try
			{
				com = new SqlCommand();
				com.Connection = con;
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("@Id", id);
				//com.Parameters.AddWithValue("@blockname", model.blockName);
				//com.Parameters.AddWithValue("@flag", model.flag);
				com.CommandText = StoredProcedures.sp_DeleteDomain;
				con.Open();
				com.ExecuteNonQuery();
				con.Close();
				status = true;
			}
			catch (Exception ex)
			{
                throw ex;
            }

			return status;
		}

		public bool UpdateDomainStatus(int id, bool status)
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
				com.CommandText = StoredProcedures.sp_UpdateDomainStatus;
				con.Open();
				com.ExecuteNonQuery();
				con.Close();
				updStatus = true;
			}
			catch (Exception ex)
			{
                throw ex;
            }

			return updStatus;
		}
		// For View record
		public DataSet GetDomaindetails()
		{
			DataSet ds = new DataSet();
			try
			{
				com = new SqlCommand();
				com.Connection = con;
				com.CommandType = CommandType.StoredProcedure;
				com.CommandText = StoredProcedures.Sp_GetDomains;
				SqlDataAdapter da = new SqlDataAdapter(com);
				da.Fill(ds);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return ds;
		}

        public bool UpdateDomainDetails(DomainModel domainmodel)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@domainId", domainmodel.Id);
                com.Parameters.AddWithValue("@domainname", domainmodel.DomainName);
				com.Parameters.AddWithValue("@ModifiedBy", domainmodel.ModifiedBy);
                com.CommandText = StoredProcedures.Sp_UpdateDomain;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }
    }

}
