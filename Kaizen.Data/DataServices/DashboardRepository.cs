using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.DashboardModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Kaizen.Data.DataServices
{
    public class DashboardRepository : IDashboardRepository
    {
        public static string SqlConnectionString { get; set; }

        public DashboardRepository() {
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
        public DataSet GetKaizenCount(DashboardModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;

                if (!string.IsNullOrEmpty(startDate) && startDate.Length == 4 && int.TryParse(startDate, out _))
                {
                    startDate = $"01-01-{startDate}";
                }
                if (!string.IsNullOrEmpty(endDate) && endDate.Length == 4 && int.TryParse(endDate, out _))
                {
                    endDate = $"31-12-{endDate}";
                }
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                com.Parameters.AddWithValue("@Cadre", model.Cadre == "--Select Cadre--" ? "" : (string.IsNullOrEmpty(model.Cadre) ? " " : model.Cadre));

                com.Parameters.AddWithValue("@Block", model.Block == "--Select Block--" ? "" : (string.IsNullOrEmpty(model.Block) ? " " : model.Block));

                com.Parameters.Add("@Domain", SqlDbType.VarChar).Value = model.Domain == "--Select Domain--" ? (object)DBNull.Value : (string.IsNullOrEmpty(model.Domain) ? (object)DBNull.Value : model.Domain);
                com.Parameters.Add("@Department", SqlDbType.VarChar).Value =  model.Department == "--Select Department--" || model.Department == "Select Department" ? (object)DBNull.Value :  (string.IsNullOrEmpty(model.Department) ? (object)DBNull.Value : model.Department);

                com.CommandText = StoredProcedures.Sp_DashboardFilter;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetDomainKaizenCount(DashboardModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                com.CommandText = StoredProcedures.Sp_Get_DashboardDomains;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Getmanagetdomaindepartment(DashboardModel model, string Empid)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                com.Parameters.AddWithValue("@EmpId", Empid);              
                com.CommandText = StoredProcedures.Sp_Get_DashboardManagerDomainDepartment;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetDepartmentKaizenCount(DashboardModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                com.CommandText = StoredProcedures.Sp_Get_DashboardDepartments;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetGraphKaizenCount(DashboardModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;
                if (!string.IsNullOrEmpty(startDate) && startDate.Length == 4 && int.TryParse(startDate, out _))
                {
                    startDate = $"01-01-{startDate}";
                }
                if (!string.IsNullOrEmpty(endDate) && endDate.Length == 4 && int.TryParse(endDate, out _))
                {
                    endDate = $"31-12-{endDate}";
                }
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                com.CommandText = StoredProcedures.Sp_Get_Dashboardgraphs;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetDepartmentGraphKaizenCount(DashboardModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;
                if (!string.IsNullOrEmpty(startDate) && startDate.Length == 4 && int.TryParse(startDate, out _))
                {
                    startDate = $"01-01-{startDate}";
                }
                if (!string.IsNullOrEmpty(endDate) && endDate.Length == 4 && int.TryParse(endDate, out _))
                {
                    endDate = $"31-12-{endDate}";
                }
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                com.Parameters.AddWithValue("@Domainname",model.Domain);
                com.CommandText = StoredProcedures.Sp_Get_DashboardDepartmentgraph;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetOtherKaizenCount(DashboardModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                com.Parameters.AddWithValue("@Block", model.Block == "--Select Block--" ? "" : (string.IsNullOrEmpty(model.Block) ? " " : model.Block));
                com.Parameters.Add("@Domain", SqlDbType.VarChar).Value = model.Domain == "--Select Domain--" ? (object)DBNull.Value : (string.IsNullOrEmpty(model.Domain) ? (object)DBNull.Value : model.Domain);
                com.Parameters.Add("@Department", SqlDbType.VarChar).Value = model.Department == "--Select Department--" || model.Department == "Select Department" ? (object)DBNull.Value : (string.IsNullOrEmpty(model.Department) ? (object)DBNull.Value : model.Department);
                com.CommandText = StoredProcedures.sp_GetKaizenStatisticsByApprovalTypes;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetEmployeeDashboardCount(DashboardModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                string startDate = model.StartDate;
                string endDate = model.EndDate;

                if (!string.IsNullOrEmpty(startDate) && startDate.Length == 4 && int.TryParse(startDate, out _))
                {
                    startDate = $"01-01-{startDate}";
                }
                if (!string.IsNullOrEmpty(endDate) && endDate.Length == 4 && int.TryParse(endDate, out _))
                {
                    endDate = $"31-12-{endDate}";
                }
                //com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(startDate) ? (object)DBNull.Value : DateTime.Parse(startDate));
                //com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(endDate) ? (object)DBNull.Value : DateTime.Parse(endDate));
                if (DateTime.TryParse(startDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                {
                    com.Parameters.AddWithValue("@StartDate", parsedStartDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (DateTime.TryParse(endDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    com.Parameters.AddWithValue("@EndDate", parsedEndDate);
                }
                else
                {
                    com.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }

                com.CommandText = StoredProcedures.sp_GetEmployeeDashboardDetails;
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
