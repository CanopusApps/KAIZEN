using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.WinnersList;
using Microsoft.Extensions.Configuration;


namespace Kaizen.Data.DataServices
{
    public class WinnersListRepository : IWinnersListRepository
    {
        public static string SqlConnectionString { get; set; }

        public WinnersListRepository()
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


        public bool AddWinner(WinnersListModel model)
        {
            bool status = false;
            SqlCommand com = null;

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.SpAddWinner;
                com.Parameters.AddWithValue("@EmpGUID", model.EmpGUID);
                com.Parameters.AddWithValue("@Category", model.Category);
                com.Parameters.AddWithValue("@StartDate", model.StartDate);
                com.Parameters.AddWithValue("@EndDate", model.EndDate);
                com.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@Status", "Active");
                com.Parameters.AddWithValue("@winnerimg", model.winnerimagefilepath ?? (object)DBNull.Value);

                SqlParameter resultParam = new SqlParameter
                {
                    ParameterName = "@result",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                com.Parameters.Add(resultParam);

                con.Open();
                com.ExecuteNonQuery();
                bool result = (bool)resultParam.Value;
                status = !result;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (com != null) com.Dispose();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return status;
        }

        public bool UpdateWinner (WinnersListModel model)
        {
            bool updStatus = false;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.AddWithValue("@WID", model.Id);               
                com.Parameters.AddWithValue("@ID", model.EmpID);             //
                com.Parameters.AddWithValue("@StartDate", model.StartDate);  //UPDATED START DATE
                com.Parameters.AddWithValue("@EndDate", model.EndDate);      //UPDATED END DATE
                com.Parameters.AddWithValue("@imgpath",model.winnerimagefilepath);
                com.Parameters.AddWithValue("@SessionId", model.ModifiedBy); //SESSION ID
                com.CommandText = StoredProcedures.SpUpdateWinner;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                updStatus = true;
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

        public string ToggleStatus(WinnersListModel model)
        {
            String statusResult= null;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Id", model.Id);
                com.Parameters.AddWithValue("@Stat", model.Status);
                com.CommandText = StoredProcedures.SpUpdateWinnerStatus;
                con.Open();
                com.ExecuteNonQuery();

                object result = com.ExecuteScalar();
                statusResult = result.ToString();
                con.Close();
            }
            catch(Exception ex)
            {
                
            }
			finally
			{
				con.Close();
			}
			return statusResult;
        }
        public bool DeleteWinner(int id, String sd, String ed)
        {
            bool status = false;

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(sd) ? (object)DBNull.Value : DateTime.Parse(sd));
                com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(ed) ? (object)DBNull.Value : DateTime.Parse(ed));
                com.CommandText = StoredProcedures.SpDeleteWinner;
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
        public DataSet GetWinners()
        {
            DataSet ds = new DataSet();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.SpGetWinnersList;
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
