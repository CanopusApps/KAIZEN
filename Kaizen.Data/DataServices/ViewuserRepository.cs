using Kaizen.Data.Constant;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;
using System.Data.OleDb;

namespace Kaizen.Data.DataServices
{
    public class ViewuserRepository : IViewuserRepository
    {
        public static string SqlConnectionString { get; set; }

        public ViewuserRepository()
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
        //This function is used to fetch User List from DB by Using Store Procedure sp_getUsers .
        public DataSet GetUser(UserGridModel model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(model.Name) ? " " : model.Name);
                com.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(model.Email) ? " " : model.Email);
                com.Parameters.AddWithValue("@EmpID", string.IsNullOrEmpty(model.EmpID) ? " " : model.EmpID);
                com.Parameters.AddWithValue("@UserDesc", model.UserType == "All" ? "" : (string.IsNullOrEmpty(model.UserType) ? " " : model.UserType));
                com.Parameters.AddWithValue("@DomainDesc", model.Domain == "All" ? "" : (string.IsNullOrEmpty(model.Domain) ? " " : model.Domain));
                com.Parameters.AddWithValue("@DepartmentName", model.Department == "All" ? "" : (string.IsNullOrEmpty(model.Department) ? " " : model.Department));

                com.CommandText = StoredProcedures.sp_getUsers;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //This function is used to delete Users from DB by Using Store Procedure sp_Delete_User .
        public bool DeleteUserData(int id)
        {
            bool deleteStatus = false;

            try
            {
                com = new SqlCommand();
                SqlDataAdapter da = null;
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.CommandText = StoredProcedures.sp_Delete_User;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                deleteStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

			finally
			{
				con.Close();
			}
			return deleteStatus;
        }
        //This function is used to fetch Status from DB by Using Store Procedure Sp_Get_Status .
        public DataSet GetStatus()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_Get_Status;

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //public DataTable ReadExcelIntoDataTable(string filePath)
        //{
        //    string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
        //    using (OleDbConnection connection = new OleDbConnection(connectionString))
        //    {
        //        connection.Open();
        //        string sql = "SELECT * FROM [Sheet1$]";
        //        using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection))
        //        {
        //            DataTable dataTable = new DataTable();
        //            adapter.Fill(dataTable);
        //            return dataTable;
        //        }
        //    }
        //}
        //This function is used to Save Bulkupload User into Db Using Sp Sp_Upload_Users .
        public string SaveUploadedFile(UploadUserModel Employee)
        {
            string errorMessage = string.Empty;

            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = StoredProcedures.Sp_Upload_Users;

                    com.Parameters.Add(new SqlParameter("@EmpId", Employee.EmpID));
                    com.Parameters.Add(new SqlParameter("@FirstName", Employee.FirstName));
                    com.Parameters.Add(new SqlParameter("@LastName", Employee.LastName));
                    com.Parameters.Add(new SqlParameter("@Gender", Employee.Gender));
                    com.Parameters.Add(new SqlParameter("@Email", Employee.Email));
                    com.Parameters.Add(new SqlParameter("@Block", Employee.Block));
                    com.Parameters.Add(new SqlParameter("@Domain", Employee.Domain));
                    com.Parameters.Add(new SqlParameter("@Department", Employee.Department));
                    com.Parameters.Add(new SqlParameter("@Cadre", Employee.Cadre));
                    com.Parameters.Add(new SqlParameter("@MobileNo", Employee.PhoneNumber));
                    com.Parameters.Add(new SqlParameter("@Status", Employee.Status));
                    com.Parameters.Add(new SqlParameter("@UserType", Employee.UserType));
                    com.Parameters.Add(new SqlParameter("@Password", Employee.Password));

                    SqlParameter errorMessageParam = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    com.Parameters.Add(errorMessageParam);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                    errorMessage = errorMessageParam.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred: " + ex.Message;
            }
			finally
			{
				con.Close();
			}

			return errorMessage;
        }

        public DataSet GetIEDepartData()
        {
            DataSet ds = new DataSet();

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_Get_IEDeptDetails;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }
        public DataSet GetFinanceData() 
        {
            DataSet ds = new DataSet();

            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = StoredProcedures.Sp_Get_FinanceDetails;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //This Function is used to fetch User List from DB as per Domain Id by using Sp sp_GetUsersByDomainId . 
        public DataSet GetUsersByDomainId(int domainId)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = StoredProcedures.sp_GetUsersByDomainId;

                    // Pass the domainId to filter users
                    com.Parameters.AddWithValue("@DomainId", domainId);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching users by domain ID.", ex);
            }
            return ds;
        }

        //This Function is used to fetch User List from DB as per Department Id by using Sp sp_GetUsersByDeptId .
        public DataSet GetUsersByDeptId(int domainId, int deptId)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = StoredProcedures.sp_GetUsersByDeptId; // Update with your actual stored procedure name

                    // Pass the domainId and deptId to filter users
                    com.Parameters.AddWithValue("@DomainId", domainId);
                    com.Parameters.AddWithValue("@DeptId", deptId);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching users by department ID.", ex);
            }
            return ds;
        }

        //This Function is used to fetch User List from DB as per Block Id by using Sp sp_GetUsersByBlockId .
        public DataSet GetUsersByBlockId(int blockId)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con; // Assuming `con` is your SqlConnection object
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = StoredProcedures.sp_GetUsersByBlockId; // Replace with your actual stored procedure name

                    // Pass the blockId to filter users
                    com.Parameters.AddWithValue("@BlockId", blockId);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching users by block ID.", ex);
            }
            return ds;
        }
        //This function is used to fetch Manager List from DB using Sp sp_GetManagers
        public DataSet GetManagers(UserGridModel model)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;

                    // Setting up parameters for the stored procedure
                    com.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(model.Name) ? (object)DBNull.Value : model.Name);
                    com.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(model.Email) ? (object)DBNull.Value : model.Email);
                    com.Parameters.AddWithValue("@EmpID", string.IsNullOrEmpty(model.EmpID) ? (object)DBNull.Value : model.EmpID);
                    com.Parameters.AddWithValue("@UserDesc", string.IsNullOrEmpty(model.UserType) ? (object)DBNull.Value : model.UserType);
                    com.Parameters.AddWithValue("@Domain", string.IsNullOrEmpty(model.Domain) ? (object)DBNull.Value : model.Domain);
                    com.Parameters.AddWithValue("@Department", string.IsNullOrEmpty(model.Department) ? (object)DBNull.Value : model.Department);
                    com.Parameters.AddWithValue("@Gender", string.IsNullOrEmpty(model.Gender) ? (object)DBNull.Value : model.Gender);
                    com.Parameters.AddWithValue("@Cadre", string.IsNullOrEmpty(model.Cadre) ? (object)DBNull.Value : model.Cadre);

                    com.CommandText = StoredProcedures.sp_GetManagers; 

                    using (SqlDataAdapter da = new SqlDataAdapter(com))
                    {
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle as needed
                throw ex;
            }
            return ds;
        }
    }
}
