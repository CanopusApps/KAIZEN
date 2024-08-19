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
using System.Security.Cryptography;

namespace Kaizen.Data.DataServices
{
    public class AddUserRepository : IAddUserRepository
    {
        public static string SqlConnectionString { get; set; }
        public AddUserRepository()
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


        //method to insert all the data into the data base
        public string InsertUserData(AddUserModel ur)
        {
            string msg = "";
            int res;
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(ur.Password));
                    StringBuilder hashPasswordBuilder = new StringBuilder();
                    foreach (byte b in hashValue)
                    {
                        hashPasswordBuilder.Append(b.ToString("x2"));
                    }
                    string hashedPassword = hashPasswordBuilder.ToString();

                    SqlCommand com = new SqlCommand(StoredProcedures.Sp_InsertUser, con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EmpId", ur.EmpId);
                    com.Parameters.AddWithValue("@Name", ur.FirstName);
                    com.Parameters.AddWithValue("@MiddleName", ur.MiddleName);
                    com.Parameters.AddWithValue("@LastName", ur.LastName);
                    com.Parameters.AddWithValue("@Email", ur.Email);
                    com.Parameters.AddWithValue("@Password", hashedPassword);
                    com.Parameters.AddWithValue("@Phno", ur.Phoneno);
                    com.Parameters.AddWithValue("@Gender", ur.Gender.Substring(0, 1));
                    com.Parameters.AddWithValue("@Cid", ur.Cid);
                    com.Parameters.AddWithValue("@Rid", ur.Rid);
                    com.Parameters.AddWithValue("@Createdby", ur.CreatedbyId);
                    com.Parameters.AddWithValue("@status", ur.statusname);
                    com.Parameters.AddWithValue("@Did", ur.Did);
                    com.Parameters.AddWithValue("@BlockId", ur.BlockId);
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
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    msg = ex.Message;
                    con.Close();
                }

            }

            finally
            {
                con.Close();
            }
            return msg;
        }
        // method to get Get department
        //public DataSet GetDepartment(string Did)
        //{
        //    //SqlCommand com = new SqlCommand("Select * from tbl_Domain", con);

        //    com = new SqlCommand();
        //    DataSet ds = new DataSet();
        //    com.Connection = con;

        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@DomainName", Did);
        //    com.CommandText = StoredProcedures.sp_Fetch_Department;

        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    da.Fill(ds);
        //    return ds;
        //}

        //------------------------------------------------------------------
        // to Get Cadre table data in a list
        //public List<DropDownEntity> GetCadreList()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand com = new SqlCommand(StoredProcedures.sp_Get_cadre, con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    da.Fill(dt);
        //    return DataTableToListWithExtraValue(dt);

        //}

        public DataSet GetCadreList()
        {
            DataSet ds = new DataSet();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.sp_Get_cadre;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        //-----------------------------//
        //Get UserType Table into List
        //public List<RoleDropDown> GetUserTypeList()
        //{

        //    DataTable dt = new DataTable();
        //    SqlCommand com = new SqlCommand(StoredProcedures.sp_Get_UserType, con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    da.Fill(dt);
        //    return DataTableToListWithExtraValue1(dt);
        //}

        public DataSet GetUserTypeList()
        {
            DataSet ds = new DataSet();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.sp_Get_UserType;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        //--------------------------------------------
        // to get Domain table data and convert it into a list

    }
}