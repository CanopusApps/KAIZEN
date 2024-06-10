using ASPNETCoreWeb.Constant;
using Kaizen.Data.DataContent;
using Kaizen.Web.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public class AccountData : IAccountData
    {

        public static string SqlConnectionString { get; set; }
   

        public AccountData() 
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
        public DataTable LoginCheckDAL(Login entitylog)
        {
                com = new SqlCommand();
                SqlDataAdapter da = null;
                DataTable dt = new DataTable();
              try
              {
                  com.Connection = con;
                  com.CommandType = CommandType.StoredProcedure;
                  com.Parameters.AddWithValue("@username", entitylog.UserName);
                  com.Parameters.AddWithValue("@password", entitylog.Password);
                  com.CommandText = StoredProcedures.Splogin;
                  com.CommandTimeout = 0;
                  con.Open();
                  da = new SqlDataAdapter(com);
                  da.Fill(dt);
              }
              catch (Exception ex) 
              {


              }
            return dt;
        }

    }
}
