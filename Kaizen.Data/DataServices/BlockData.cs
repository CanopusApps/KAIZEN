using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
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
        public string CreateBlockData(BlockModel model)
        {
            string msg = "";

            try
            {
                com = new SqlCommand();
                SqlDataAdapter da = null;
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", model.id);
                com.Parameters.AddWithValue("@blockname", model.blockName);
                com.Parameters.AddWithValue("@flag", model.flag);
                com.CommandText = StoredProcedures.SpCreateBlock;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Block Created Successfully !!";
            }
            catch (Exception ex) { }

            return msg;
        }

        public string DeleteBlockData(BlockModel model)
        {
            string msg = "";

            try
            {
                com = new SqlCommand();
                SqlDataAdapter da = null;
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", model.id);
                com.Parameters.AddWithValue("@blockname", model.blockName);
                com.Parameters.AddWithValue("@flag", model.flag);
                com.CommandText = StoredProcedures.SpCreateBlock;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Block Deleted Successfully !!";
            }
            catch (Exception ex) { }

            return msg;
        }
        // For View record
        public DataSet GetBlockData(BlockModel model)
        {
            com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Sr_no", model.id);
            com.Parameters.AddWithValue("@blockname", model.blockName);
            com.Parameters.AddWithValue("@flag", model.flag);
            com.CommandText = StoredProcedures.SpCreateBlock;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;

        }




    }
}
