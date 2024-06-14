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
    public class AddUserData:IAddUserData
    {
        public static string SqlConnectionString { get; set; }
        public AddUserData() {
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


        //method to insert all the data into the data base
        public string InsertUserData(AddUserModel  ur)
        {
            string msg = "";
            int res;
            try
            {
                SqlCommand com = new SqlCommand(StoredProcedures.Sp_InsertUser, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", ur.EmpId);
                com.Parameters.AddWithValue("@Name", ur.Name);
                com.Parameters.AddWithValue("@Email", ur.Email);
                com.Parameters.AddWithValue("@Password", ur.Password);
                com.Parameters.AddWithValue("@Phno", ur.Phoneno);
                com.Parameters.AddWithValue("@Gender", ur.Gender.Substring(0,1));
                com.Parameters.AddWithValue("@Cid", ur.Cid);
                com.Parameters.AddWithValue("@Rid", ur.Rid);
                com.Parameters.AddWithValue("@status", ur.statusname);
                com.Parameters.AddWithValue("@Did", ur.Did);
                com.Parameters.AddWithValue("@Deptid", ur.DeptId);

                SqlParameter obreg = new SqlParameter();
                obreg.ParameterName = "@result";
                obreg.SqlDbType = SqlDbType.Bit;
                obreg.Direction = ParameterDirection.Output;
                com.Parameters.Add(obreg);
                con.Open();
                com.ExecuteNonQuery();
                res = Convert.ToInt32(obreg.Value);
                con.Close();
                if (res == 0)
                {
                    msg = "ok";
                }
                else
                {
                    msg = "Duplicate Emp Id";
                }
                return msg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    msg = ex.Message;
                    con.Close(); }

            }
            return msg;
        }
        // method to get Get department
        public DataSet GetDepartment(string Did)
        {
            //SqlCommand com = new SqlCommand("Select * from tbl_Domain", con);

            com = new SqlCommand();
            DataSet ds = new DataSet();
            com.Connection = con;

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DomainName", Did);
            com.CommandText = StoredProcedures.Sp_Fetch_Department;

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }

        //------------------------------------------------------------------
        // to Get Cadre table data in a list
        public List<DropDownEntity> GetCadreList()
        {
            DataTable dt = new DataTable();
           
            SqlCommand com = new SqlCommand(StoredProcedures.Sp_Fetch_cadre, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return DataTableToListWithExtraValue(dt);

        }
        private List<DropDownEntity> DataTableToListWithExtraValue(DataTable table)
        {
            var list = new List<DropDownEntity>(table.Rows.Count);
            var ddl = new DropDownEntity()
            {
                DataValueField = -1,
                DataTextField = "Select"
            };
            list.Add(ddl);
            foreach (DataRow row in table.Rows)
            {
                var values = row.ItemArray;
                ddl = new DropDownEntity()
                {
                    DataValueField = Convert.ToInt32(values[0]),
                    DataTextField = values[1].ToString(),
                    DataAltValueField = (values.Length > 2 && values[2] != null) ? values[2].ToString() : ""
                };
                list.Add(ddl);
            }

            return list;
        }
        //-----------------------------//
        //Get UserType Table into List
        public List<RoleDropDown> GetUserTypeList()
        {
            
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand(StoredProcedures.Sp_Fetch_UserType, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return DataTableToListWithExtraValue1(dt);
        }
        private List<RoleDropDown> DataTableToListWithExtraValue1(DataTable table)
        {
            var list = new List<RoleDropDown>(table.Rows.Count);
            var ddl = new RoleDropDown()
            {
                DataValueField = -1,
                DataTextField = "Select"
            };
            list.Add(ddl);
            foreach (DataRow row in table.Rows)
            {
                var values = row.ItemArray;
                ddl = new RoleDropDown()
                {
                    DataValueField = Convert.ToInt32(values[0]),
                    DataTextField = values[1].ToString(),
                    DataAltValueField = (values.Length > 2 && values[2] != null) ? values[2].ToString() : ""
                };
                list.Add(ddl);
            }
            return list;
        }
        //--------------------------------------------
        // to get Domain table data and convert it into a list
        public List<DomainDropDown> GetDomainTypeList()
        {
            DataTable dt = new DataTable();
            //SqlCommand com = new SqlCommand("[dbo].[Sp_Fetch_Domain]", con);
            SqlCommand com = new SqlCommand(StoredProcedures.Sp_Fetch_Domain, con);
            com.CommandType = CommandType.StoredProcedure;
           
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return DataTableToListWithExtraValue2(dt);

        }
        private List<DomainDropDown> DataTableToListWithExtraValue2(DataTable table)
        {
            var list = new List<DomainDropDown>(table.Rows.Count);
            var ddl = new DomainDropDown()
            {
                DataValueField = -1,
                DataTextField = "Select"
            };
            list.Add(ddl);
            foreach (DataRow row in table.Rows)
            {
                var values = row.ItemArray;
                ddl = new DomainDropDown()
                {
                    DataValueField = Convert.ToInt32(values[0]),
                    DataTextField = values[1].ToString(),
                    DataAltValueField = (values.Length > 2 && values[2] != null) ? values[2].ToString() : ""
                };
                list.Add(ddl);
            }
            return list;
        }
    }
}