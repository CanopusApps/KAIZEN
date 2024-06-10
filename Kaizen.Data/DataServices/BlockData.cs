using ASPNETCoreWeb.Constant;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public class BlockData : IBlockData
    {
        public static string SqlConnectionString { get; set; }

        public BlockData()
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

        public string CreateBlockData(string blockName, out string msg)
        {
            msg = "";

            com = new SqlCommand();
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@blockname", blockName);
            com.CommandText = StoredProcedures.SpCreateBlock;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            msg = "Block Created Successfully !!";
            return msg;




        }




    }
}
