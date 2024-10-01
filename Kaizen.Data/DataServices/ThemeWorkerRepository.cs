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
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = StoredProcedures.SpAddTheme;
                    com.Parameters.AddWithValue("@Theme", model.Theme);
                    com.Parameters.AddWithValue("@StartDate", model.StartDate); 
                    com.Parameters.AddWithValue("@EndDate", model.EndDate); 
                    com.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                    con.Open();
                    com.ExecuteNonQuery();

                   
                    status = true;
                }
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


        public DataSet GetActiveTheme(DateTime currentDate)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con; 
                    com.CommandType = CommandType.StoredProcedure;  
                    com.CommandText = StoredProcedures.SpGetActiveTheme; 
                    using (SqlDataAdapter da = new SqlDataAdapter(com))
                    {
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return ds;
        }

        public bool DeleteTheme(int id, bool forceDelete = false)
        {
            bool status = false;

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ThemeId", id);
                com.Parameters.AddWithValue("@ForceDelete", forceDelete); 
                com.CommandText = StoredProcedures.SpDeleteTheme;
                com.Parameters.Add(new SqlParameter("@ReturnMessage", SqlDbType.Int) { Direction = ParameterDirection.Output });
                con.Open();
                com.ExecuteNonQuery();
                var returnMessage = com.Parameters["@ReturnMessage"].Value;
                int returnMes = returnMessage == DBNull.Value ? 0 : Convert.ToInt32(returnMessage);
                if (returnMes == 5)
                {
                    // Active theme, cannot delete
                    status = false; 
                }
                else if (returnMes == 1)
                {
                    // Successfully deleted
                    status = true; 
                }
                else
                {
                    // Handle other cases, e.g., returnMes == 1 (failed to delete)
                    status = false; 
                }
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
