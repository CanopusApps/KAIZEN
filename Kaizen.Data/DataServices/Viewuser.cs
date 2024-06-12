using Kaizen.Data.Constant;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Kaizen.Models.ViewUserModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public class Viewuser : IViewuserData
    {
        public static string SqlConnectionString { get; set; }

        public Viewuser()
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

        public DataSet GetUserType(UserTypeModel model)
        {
            model.flag = "get";
            com = new SqlCommand();
            DataSet ds = new DataSet();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_Fetch_UserType;
              
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                return ds;
        }
        public DataSet GetDomain(DomainModel model)
        {
            model.flag = "get";
            com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = StoredProcedures.Sp_Fetch_Domain;

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }
    }
}
