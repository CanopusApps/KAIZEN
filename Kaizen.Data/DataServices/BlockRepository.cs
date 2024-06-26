using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public class BlockRepository : IBlockRepository
    {
        public static string SqlConnectionString { get; set; }
		private static SqlConnection con = null;
		private static SqlCommand com = null;
		SqlDataAdapter da = null;

		public BlockRepository()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);

        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public bool InsertBlockDetails(string blockName)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@blockname", blockName);
                com.CommandText = StoredProcedures.sp_InsertBlockDetails;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
				status = true;
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return status;
        }

        public bool DeleteBlockData(int id)
        {
			bool status = false;

			try
			{
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id",id);
                //com.Parameters.AddWithValue("@blockname", model.blockName);
                //com.Parameters.AddWithValue("@flag", model.flag);
                com.CommandText = StoredProcedures.sp_DeleteBlockDetails;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return status;
        }

        public bool UpdateBlockData(int id, bool status)
        {
            bool updStatus = false;

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.Parameters.AddWithValue("@status", status);
                //com.Parameters.AddWithValue("@blockname", model.blockName);
                //com.Parameters.AddWithValue("@flag", model.flag);
                com.CommandText = StoredProcedures.sp_UpdateBlockDetails;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                updStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updStatus;
        }
        // For View record
        public DataSet GetBlockData()
        {
			DataSet ds = new DataSet();

			try
			{
		    com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = StoredProcedures.sp_GetBlockDetails;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return ds;

		}

        public bool UpdateBlockDetails(string blockName, int id)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@blockname", blockName);
                com.Parameters.AddWithValue("@blockId", id);
                com.CommandText = StoredProcedures.sp_UpdateBlock;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

    }
}
