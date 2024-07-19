﻿using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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
            com.Parameters.AddWithValue("@startdate", model.StartDate );
            com.Parameters.AddWithValue("@enddate", model.EndDate);
            com.CommandText = StoredProcedures.Sp_Get_KaizenformReport;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
        

    }
}