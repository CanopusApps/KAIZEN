using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.DashboardModel;
using Microsoft.Extensions.Configuration;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(startDate) ? (object)DBNull.Value : DateTime.Parse(startDate));
                com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(endDate) ? (object)DBNull.Value : DateTime.Parse(endDate));
                com.Parameters.AddWithValue("@Cadre", model.Cadre == "All" ? "" : (string.IsNullOrEmpty(model.Cadre) ? " " : model.Cadre));

                com.Parameters.AddWithValue("@Block", model.Block == "All" ? "" : (string.IsNullOrEmpty(model.Block) ? " " : model.Block));

                com.Parameters.Add("@Domain", SqlDbType.VarChar).Value = model.Domain == "All" ? (object)DBNull.Value : (string.IsNullOrEmpty(model.Domain) ? (object)DBNull.Value : model.Domain);
                com.Parameters.Add("@Department", SqlDbType.VarChar).Value =  model.Department == "All" || model.Department == "Select Department" ? (object)DBNull.Value :  (string.IsNullOrEmpty(model.Department) ? (object)DBNull.Value : model.Department);

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
                com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(startDate) ? " " : startDate);
                com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(endDate) ? " " : endDate);
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
                com.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(startDate) ? " " : startDate);
                com.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(endDate) ? " " : endDate);
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
    }
}
