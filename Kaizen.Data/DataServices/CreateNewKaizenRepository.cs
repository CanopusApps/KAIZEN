using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Kaizen.Models.NewKaizen;

namespace Kaizen.Data.DataServices
{
    public class CreateNewKaizenRepository : ICreateNewKaizenRepository
    {
        public static string SqlConnectionString { get; set; }
        private static SqlConnection con = null;
        private static SqlCommand com = null;
        SqlDataAdapter da = null;
        public CreateNewKaizenRepository()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public DataTable GetKaizenOriginatedbyData(NewKaizenModel model)
        {
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@empId", model.EmpId);
                com.CommandText = StoredProcedures.SpGetKaizenOriginetedby;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
