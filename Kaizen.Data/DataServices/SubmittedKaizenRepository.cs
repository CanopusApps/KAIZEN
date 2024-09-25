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
using DocumentFormat.OpenXml.Wordprocessing;
using System.Globalization;

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
        //This function is used to fetch Approval Status List from DB using Sp - Sp_Get_Approval_Status .
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
        //This function is used to fetch Kaizen List from DB using Sp - Sp_Get_Kaizen_Details .
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

                        //com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
                        //com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
                        if (DateTime.TryParse(model.StartDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                        {
                            com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                        }

                        if (DateTime.TryParse(model.EndDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                        {
                            com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                        }
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
        //This function is used to fetch Kaizen List from DB using Sp - Sp_Get_kaizen_details_On_clickdashboard on click of Dashboard componnent . .
        public DataSet GetKaizenListOnclickDashboard(KaizenListModel model)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                try
                {
                    using (SqlCommand com = new SqlCommand(StoredProcedures.Sp_Get_kaizen_details_On_clickdashboard, con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        var customDateFormat = "dd-MM-yyyy";
                        var culture = CultureInfo.CurrentCulture;

                        if (DateTime.TryParse(model.StartDate, culture, DateTimeStyles.None, out DateTime parsedStartDate) ||
                            DateTime.TryParseExact(model.StartDate, customDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedStartDate))
                        {
                            com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                        }

                        if (DateTime.TryParse(model.EndDate, culture, DateTimeStyles.None, out DateTime parsedEndDate) ||
                            DateTime.TryParseExact(model.EndDate, customDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedEndDate))
                        {
                            com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                        }

                        com.Parameters.AddWithValue("@Domain", model.Domain == "--Select Domain--" ? "" : (string.IsNullOrEmpty(model.Domain) ? " " : model.Domain));
                        com.Parameters.AddWithValue("@Department", model.Department == "--Select Department--" ? "" : (string.IsNullOrEmpty(model.Department) ? " " : model.Department));
                        com.Parameters.AddWithValue("@Block", model.Block == "--Select Block--" ? "" : (string.IsNullOrEmpty(model.Block) ? " " : model.Block));
                        com.Parameters.AddWithValue("@Cadre", string.IsNullOrEmpty(model.Cadre) ? " " : model.Cadre);
                        com.Parameters.AddWithValue("@Status", model.Status == "--Select Status--" ? "" : (string.IsNullOrEmpty(model.Status) ? " " : model.Status));
                        com.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(model.role) ? " " : model.role);
                        com.Parameters.AddWithValue("@UserId", string.IsNullOrEmpty(model.UserId) ? " " : model.UserId);
                     

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
        //This Function is used to Delete Kaizen as per KaizenId and UserId from DB using Sp - Sp_Delete_Kaizens .
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
