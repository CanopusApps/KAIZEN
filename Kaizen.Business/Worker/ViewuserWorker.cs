using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Kaizen.Business.Worker
{
    public  class ViewuserWorker : IViewuser
    {
        public readonly IViewuserRepository _repositoryUserTypedata;
        public readonly IDomain _domain;

		public ViewuserWorker(IViewuserRepository repositoryUserdata)
        {
                this._repositoryUserTypedata = repositoryUserdata;
        }
        public List<UserGridModel> GetUser(UserGridModel model)
        {
			DataSet userType = new DataSet();
			List<UserGridModel> UserGridData = new List<UserGridModel>();
			userType = _repositoryUserTypedata.GetUser(model);

			if (userType.Tables.Count > 0)
			{
				foreach (DataRow dr in userType.Tables[0].Rows)
				{
					UserGridData.Add(new UserGridModel
					{
						EmpID = dr["EmpID"].ToString(),
						Name = dr["Name"].ToString(),
						Email = dr["Email"].ToString(),
						Gender = dr["Gender"].ToString(),
						Domain = dr["Domain"].ToString(),
						Department = dr["Department"].ToString(),
						UserType = dr["UserType"].ToString(),
						ImageApprover = Convert.ToInt16(dr["ImageApprover"]),
						Status = Convert.ToInt16(dr["Status"])
					});
				}
			}
			return UserGridData;
        }
        public bool DeleteUser(int id)
        {
            return _repositoryUserTypedata.DeleteUserData(id);
        }
        public List<StatusModel> GetStatus()
        {
            DataSet ds;
            List<StatusModel> Status = new List<StatusModel>();
            ds = _repositoryUserTypedata.GetStatus();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Status.Add(new StatusModel
                    {
                        StatusID = Convert.ToInt16(dr["StatusID"]),
                        StatusName = dr["StatusName"].ToString()
                    });
                }
            }
            return Status;
        }
        public void Senddatatable(DataTable dataTable, string Status, string UserType, string Password)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var employee = new UploadUserModel
                {
                    EmpID = row["Emp Id"].ToString(),
                    FirstName = row["First Name"].ToString(),
                    MiddleName = row["Middle Name"].ToString(),
                    LastName = row["Last Name"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Email = row["Email Id"].ToString(),
                    Domain = row["Domain"].ToString(),
                    Department = row["Department"].ToString(),
                    Cadre = row["Cadre"].ToString(),
                    PhoneNumber = row["Mobile No"].ToString(),
                    Status = Status,
                    UserType = UserType,
                    Password = Password
                };
                _repositoryUserTypedata.SaveUploadedFile(employee);
            }
            
        }
        public DataTable ReadExcelIntoDataTable(string filePath)
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [Sheet1$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
