using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Kaizen.Models.Theme;
using System.IO;

namespace Kaizen.Data.DataServices
{
    public class ThemeWorkerRepository : IThemeRepository
    {
        public static string SqlConnectionString { get; set; }
        private static SqlConnection con = null;
        private static SqlCommand com = null;
        public ThemeWorkerRepository()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);

            return builder.Build();
        }
        public bool AddTheme(ThemeModel model)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Theme", model.Theme);
                com.Parameters.AddWithValue("@SessionId", model.ModifiedBy);
                com.CommandText = StoredProcedures.SpUpdateTheme;
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
        public DataSet RetrieveTheme()
        {
            DataSet ds = new DataSet();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.SpGetTheme;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
