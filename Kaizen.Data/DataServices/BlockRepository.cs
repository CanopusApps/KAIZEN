﻿using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

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

        public bool InsertBlockDetails(BlockModel blockmodel)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@blockname",  blockmodel.BlockName);
                com.Parameters.AddWithValue("@CreatedBy",  blockmodel.CreatedBy);
                com.CommandText = StoredProcedures.sp_InsertBlockDetails;
                com.Parameters.Add(new SqlParameter("@ReturnMessage", SqlDbType.Int) { Direction = ParameterDirection.Output });
                con.Open();
                com.ExecuteNonQuery();
                var returnMessage = com.Parameters["@ReturnMessage"].Value;
                int returnMes = returnMessage == DBNull.Value ? 0 : Convert.ToInt32(returnMessage);
                if (returnMes == 5)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
			finally
			{
				con.Close();
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
                com.Parameters.Add(new SqlParameter("@ReturnMessage", SqlDbType.Int){Direction = ParameterDirection.Output});
                con.Open();
                com.ExecuteNonQuery();
                var returnMessage = com.Parameters["@ReturnMessage"].Value;
                int returnMes = returnMessage == DBNull.Value ? 0 : Convert.ToInt32(returnMessage);
                if (returnMes == 5)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
        }

        //     public bool UpdateBlockData(int id, bool status)
        //     {
        //         bool updStatus = false;

        //         try
        //         {
        //             com = new SqlCommand();
        //             com.Connection = con;
        //             com.CommandType = CommandType.StoredProcedure;
        //             com.Parameters.AddWithValue("@Id", id);
        //             com.Parameters.AddWithValue("@status", status);
        //             //com.Parameters.AddWithValue("@blockname", model.blockName);
        //             //com.Parameters.AddWithValue("@flag", model.flag);
        //             com.CommandText = StoredProcedures.sp_UpdateBlockDetails;
        //             con.Open();
        //             com.ExecuteNonQuery();
        //             con.Close();
        //             updStatus = true;
        //         }
        //         catch (Exception ex)
        //         {
        //             throw ex;
        //         }
        //finally
        //{
        //	con.Close();
        //}

        //return updStatus;
        //     }
        public bool UpdateBlockData(int id, bool status)
        {
            bool updStatus = false;
            string message = string.Empty;

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.Parameters.AddWithValue("@status", status);
                // com.Parameters.AddWithValue("@blockname", model.blockName);
                // com.Parameters.AddWithValue("@flag", model.flag);
                com.CommandText = StoredProcedures.sp_UpdateBlockDetails;
                SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };
                com.Parameters.Add(messageParam);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                message = messageParam.Value.ToString();
                if (!string.IsNullOrEmpty(message))
                {
                    updStatus = false;  
                }
                else
                {
                    updStatus = true; 
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                con.Close();
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
        public bool UpdateBlockDetails(BlockModel blockmodel)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@blockname",  blockmodel.BlockName);
                com.Parameters.AddWithValue("@blockId",  blockmodel.Id);
                com.Parameters.AddWithValue("@ModifiedBy", blockmodel.ModifiedBy);
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
			finally
			{
				con.Close();
			}
			return status;
        }
    }
}
