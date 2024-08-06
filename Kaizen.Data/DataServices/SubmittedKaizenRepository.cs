using Kaizen.Data.Constant;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;
using System.Data.OleDb;
namespace Kaizen.Data.DataServices
{
    public class SubmittedKaizenRepository : ISubmittedKaizenRepository
    {
        public static string SqlConnectionString { get; set; }

        public SubmittedKaizenRepository()
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

        public DataSet GetApprovalStatus(string UserType)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserType", UserType);
                com.CommandText = StoredProcedures.Sp_Get_Approval_Status;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetKaizenList(KaizenListModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
                com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
                com.Parameters.AddWithValue("@Domain", model.Domain == "--Select Domain--" ? "" : (string.IsNullOrEmpty(model.Domain) ? " " : model.Domain));
                com.Parameters.AddWithValue("@Department", model.Department == "--Select Department--" ? "" : (string.IsNullOrEmpty(model.Department) ? " " : model.Department));
                com.Parameters.AddWithValue("@KaizenTheme", string.IsNullOrEmpty(model.KaizenTheme) ? " " : model.KaizenTheme);
                com.Parameters.AddWithValue("@Status", model.Status == "--Select Status--" ? "" : (string.IsNullOrEmpty(model.Status) ? " " : model.Status));
                com.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(model.role) ? " " : model.role);
                com.Parameters.AddWithValue("@UserId", string.IsNullOrEmpty(model.UserId) ? " " : model.UserId);

                com.CommandText = StoredProcedures.Sp_Get_Kaizen_Details;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public bool DeleteKaizenData(int KaizenId,string UserId)
        {
            bool status = false;

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenId", KaizenId);
                com.Parameters.AddWithValue("@UserId", UserId);
                com.CommandText = StoredProcedures.Sp_Delete_Kaizens;
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
