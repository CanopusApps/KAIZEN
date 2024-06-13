using Kaizen.Data.Constant;

using Kaizen.Models.AdminModel;
using Kaizen.Models.ViewUserModel;
using Microsoft.Extensions.Configuration;

using System.Data;

using System.Data.SqlClient;

using System.Linq;

using System.Reflection;

using System.Text;

using System.Threading.Tasks;

namespace Kaizen.Data.DataServices

{
    public class DomainData : IDomainData
    {
        public static string SqlConnectionString { get; set; }

        public DomainData()
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


        public string CreateDomainData(string DomainNmae)

        {

            DomainData model = new DomainData();

            string msg = "";

            int Sno = 0;

            int Active = 1;

            string flag = "insert";

            com = new SqlCommand();

            SqlDataAdapter da = null;

            DataTable dt = new DataTable();

            com.Connection = con;

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", Sno);

            com.Parameters.AddWithValue("@Domainname", DomainNmae);

            com.Parameters.AddWithValue("@status", Active);

            com.Parameters.AddWithValue("@flag", flag);

            com.CommandText = StoredProcedures.SpCreateDomain;

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            msg = "Domain Created Successfully !!";

            return msg;

        }

        // For View record

        public DataSet GetDomainData(DomainModel model)

        {

            model.flag = "get";

            com = new SqlCommand();

            DataSet ds = new DataSet();

            com.Connection = con;

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", model.id);

            com.Parameters.AddWithValue("@domainname", model.DomainName);

            com.Parameters.AddWithValue("@status", model.StatusID);

            com.Parameters.AddWithValue("@flag", model.flag);

            com.CommandText = StoredProcedures.SpCreateDomain;

            SqlDataAdapter da = new SqlDataAdapter(com);

            da.Fill(ds);

            return ds;

        }

        //delete

        public string DeleteDomainData(DomainModel model, int id)

        {

            string msg = "";

            com = new SqlCommand();

            SqlDataAdapter da = null;

            DataTable dt = new DataTable();

            com.Connection = con;

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", id);

            com.Parameters.AddWithValue("@Domainname", model.DomainName);

            com.Parameters.AddWithValue("@status", model.StatusID);

            com.Parameters.AddWithValue("@flag", model.flag);

            com.CommandText = StoredProcedures.SpCreateDomain;

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            msg = "Domain deleted successfully!";

            return msg;

        }


        public string DropDomainData(DomainModel model, int id)

        {

            string msg = "";

            int status = 0;

            com = new SqlCommand();

            SqlDataAdapter da = null;

            DataTable dt = new DataTable();

            com.Connection = con;

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", id);

            com.Parameters.AddWithValue("@Domainname", model.DomainName);

            com.Parameters.AddWithValue("@status", status);

            com.Parameters.AddWithValue("@flag", model.flag);

            com.CommandText = StoredProcedures.SpCreateDomain;

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            msg = "Domain status updated successfully !!";

            return msg;

        }

        public string ActiveDomainData(DomainModel model, int id)

        {

            string msg = "";

            int status = 1;

            com = new SqlCommand();

            SqlDataAdapter da = null;

            DataTable dt = new DataTable();

            com.Connection = con;

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", id);

            com.Parameters.AddWithValue("@Domainname", model.DomainName);

            com.Parameters.AddWithValue("@status", status);

            com.Parameters.AddWithValue("@flag", model.flag);

            com.CommandText = StoredProcedures.SpCreateDomain;

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            msg = "Domain status updated successfully !!";

            return msg;

        }


    }

}
