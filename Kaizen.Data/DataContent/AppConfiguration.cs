using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using ASPNETCoreWeb.Constant;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Kaizen.Data.DataContent
{
    public class AppConfiguration
    {
        public static string SqlConnString { get; set; }
        public static SqlConnection con = null;
        public AppConfiguration()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
            return builder.Build();
        }



    }
}
