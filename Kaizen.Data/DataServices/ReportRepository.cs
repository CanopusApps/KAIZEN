using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.ReportModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Kaizen.Models.DashboardModel;

namespace Kaizen.Data.DataServices
{
    public class ReportRepository : IReportRepository
    {
        public static string SqlConnectionString { get; set; }
        public ReportRepository()
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
        public DataTable GetKaizenformData(KaizenReportModel model)
        {
            com = new SqlCommand();
            DataTable dt = new DataTable();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@startdate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
            com.Parameters.AddWithValue("@enddate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
            com.CommandText = StoredProcedures.Sp_Get_KaizenformReport;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBlockReportData(KaizenReportModel model)
        {
            com = new SqlCommand();
            DataTable dt = new DataTable();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@startdate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
            com.Parameters.AddWithValue("@enddate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
            com.CommandText = StoredProcedures.Sp_Get_BlockformReport;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDomainReportData(KaizenReportModel model)
        {
            com = new SqlCommand();
            DataTable dt = new DataTable();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@startdate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
            com.Parameters.AddWithValue("@enddate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
            com.CommandText = StoredProcedures.Sp_Get_DomainformReport;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDepartmentReportData(KaizenReportModel model)
        {
            com = new SqlCommand();
            DataTable dt = new DataTable();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@startdate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
            com.Parameters.AddWithValue("@enddate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
            com.CommandText = StoredProcedures.Sp_Get_DepartmentformReport;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetUsersReportData(KaizenReportModel model)
        {
            com = new SqlCommand();
            DataTable dt = new DataTable();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@startdate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
            com.Parameters.AddWithValue("@enddate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
            com.CommandText = StoredProcedures.Sp_Get_UserformReport;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;

        }
        public DataTable GetUserLogformData(KaizenReportModel model)
        {
            com = new SqlCommand();
            DataTable dt = new DataTable();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@startdate", string.IsNullOrEmpty(model.StartDate) ? " " : model.StartDate);
            com.Parameters.AddWithValue("@enddate", string.IsNullOrEmpty(model.EndDate) ? " " : model.EndDate);
            com.CommandText = StoredProcedures.Sp_Get_UserLogformReport;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;

        }  
        public DataSet GetDashboardData(DashboardModel model)
        {
            SqlCommand com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = StoredProcedures.Sp_Get_AllDashboardReports;
            string startDate = model.StartDate;
            string endDate = model.EndDate;

            DateTime parsedStartDate;
            DateTime parsedEndDate;

            com.Parameters.AddWithValue("@StartDate", DateTime.TryParse(startDate, out parsedStartDate) ? (object)parsedStartDate : DBNull.Value);
            com.Parameters.AddWithValue("@EndDate", DateTime.TryParse(endDate, out parsedEndDate) ? (object)parsedEndDate : DBNull.Value);
            com.Parameters.AddWithValue("@Domain", string.IsNullOrEmpty(model.Domain) ? " " : model.Domain);


            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }
    }
}
