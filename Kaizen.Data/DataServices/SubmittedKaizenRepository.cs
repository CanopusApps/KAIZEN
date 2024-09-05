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

namespace Kaizen.Data.DataServices
{
    public class SubmittedKaizenRepository : ISubmittedKaizenRepository
    {
        public static string SqlConnectionString { get; set; }

        public SubmittedKaizenRepository()
        {
            var configuration = GetConfiguration();
            SqlConnectionString = configuration.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public DataSet GetApprovalStatus(string UserType)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                try
                {
                    using (SqlCommand com = new SqlCommand(StoredProcedures.Sp_Get_Approval_Status, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@UserType", UserType);

                        SqlDataAdapter da = new SqlDataAdapter(com);
                        da.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ds;
        }

        public DataSet GetKaizenList(KaizenListModel model)
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                try
                {
                    using (SqlCommand com = new SqlCommand(StoredProcedures.Sp_Get_Kaizen_Details, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;

                        com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
                        com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
                        com.Parameters.AddWithValue("@Domain", model.Domain == "--Select Domain--" ? "" : (string.IsNullOrEmpty(model.Domain) ? " " : model.Domain));
                        com.Parameters.AddWithValue("@Department", model.Department == "--Select Department--" ? "" : (string.IsNullOrEmpty(model.Department) ? " " : model.Department));
                        com.Parameters.AddWithValue("@KaizenTheme", string.IsNullOrEmpty(model.KaizenTheme) ? " " : model.KaizenTheme);
                        com.Parameters.AddWithValue("@Status", model.Status == "--Select Status--" ? "" : (string.IsNullOrEmpty(model.Status) ? " " : model.Status));
                        com.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(model.role) ? " " : model.role);
                        com.Parameters.AddWithValue("@UserId", string.IsNullOrEmpty(model.UserId) ? " " : model.UserId);
                        com.Parameters.AddWithValue("@BenefitArea", string.IsNullOrEmpty(model.BenefitArea) ? " " : model.BenefitArea);

                        SqlDataAdapter da = new SqlDataAdapter(com);
                        da.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ds;
        }

        public bool DeleteKaizenData(int KaizenId, string UserId)
        {
            bool status = false;

            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                try
                {
                    using (SqlCommand com = new SqlCommand(StoredProcedures.Sp_Delete_Kaizens, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@KaizenId", KaizenId);
                        com.Parameters.AddWithValue("@UserId", UserId);

                        con.Open();
                        com.ExecuteNonQuery();
                        status = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return status;
        }
    }
}
