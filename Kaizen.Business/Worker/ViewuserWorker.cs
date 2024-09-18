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
using Microsoft.AspNetCore.Http;
using Kaizen.Data.Constant;
using System.Text.RegularExpressions;
using System.Transactions;
using ClosedXML.Excel;

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
        //This function is used to Fetch Users List as Per Passing Paramter .
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
						Status = Convert.ToInt16(dr["Status"]),
                        PhoneNo = dr["MobileNumber"].ToString(),
                        Password = dr["Password"].ToString(),
                        Cadre = dr["CadreDesc"].ToString(),
                        FirstName= dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BlockDesc = dr["Blockdesc"].ToString(),
                        TotalKaizenPosted= dr["TotalKaizenPosted"].ToString(),
                        role = dr["Role"].ToString(),
                        Id=dr["Id"].ToString(),
                    });
				}
			}
			return UserGridData;
        }
        //This function is used to Delete Users as Per UserId Passing from Controller .
        public bool DeleteUser(int id)
        {
            return _repositoryUserTypedata.DeleteUserData(id);
        }
        //This function is used to Fetch Status List.
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
        //This function is used to upload bulkUser 
        public string SendFile(IFormFile file, string Status, string UserType, string Password)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    // Read the Excel file into a DataTable using ClosedXML
                    DataTable dataTable = ReadExcelIntoDataTable(fileBytes);

                    if (dataTable == null || dataTable.Rows.Count == 0)
                    {
                        return "The uploaded Excel file is empty or invalid.";
                    }

                    // Check for empty rows
                    bool hasEmptyRow = dataTable.AsEnumerable().Any(row => row.ItemArray.All(field => string.IsNullOrWhiteSpace(field?.ToString())));

                    if (hasEmptyRow)
                    {
                        return "The Excel file contains empty rows. Please check your data and try again.";
                    }

                    // Process the dataTable
                    string resultMessage = Senddatatable(dataTable, Status, UserType, Password);

                    if (string.IsNullOrEmpty(resultMessage))
                    {
                        return "File uploaded and data processed successfully.";
                    }
                    else
                    {
                        return $"There are errors:\n{resultMessage}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Internal server error: {ex.Message}";
            }
        }
        //This Function is used Read and Convert Excel file into Datatble . 
        private DataTable ReadExcelIntoDataTable(byte[] fileBytes)
        {
            using (var stream = new MemoryStream(fileBytes))
            using (var workbook = new XLWorkbook(stream))
            {
                var worksheet = workbook.Worksheet(1); // Reads the first worksheet
                var dataTable = new DataTable();

                // Add columns to the DataTable based on the first row of the worksheet
                foreach (IXLCell firstRowCell in worksheet.Row(1).Cells())
                {
                    dataTable.Columns.Add(firstRowCell.Value.ToString());
                }

                // Start from the second row to add rows to the DataTable
                foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                {
                    var newRow = dataTable.NewRow();
                    int i = 0;
                    foreach (IXLCell cell in row.Cells())
                    {
                        newRow[i] = cell.Value.ToString();
                        i++;
                    }

                    dataTable.Rows.Add(newRow);
                }

                return dataTable;
            }
        }
        //This function is used to fetch UsersList after Validation .
        public string Senddatatable(DataTable dataTable, string Status, string UserType, string Password)
        {
            var errorMessages = new List<string>();
            var validRecords = new List<UploadUserModel>();

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
                    Block= row["Block"].ToString(),
                    Domain = row["Domain"].ToString(),
                    Department = row["Department"].ToString(),
                    Cadre = row["Cadre"].ToString(),
                    PhoneNumber = row["Mobile No"].ToString(),
                    Status = Status,
                    UserType = UserType,
                    Password = Password
                };

                string validationError = ValidateEmployee(employee);
                if (string.IsNullOrEmpty(validationError))
                {
                    validRecords.Add(employee);
                }
                else
                {
                    errorMessages.Add($"Error processing employee {employee.EmpID}: {validationError}");
                }
            }

            if (errorMessages.Any())
            {
                return string.Join(Environment.NewLine, errorMessages);
            }

            using (var transaction = new TransactionScope())
            {
                try
                {
                    foreach (var validEmployee in validRecords)
                    {
                        string errorMessage = _repositoryUserTypedata.SaveUploadedFile(validEmployee);

                        if (!string.IsNullOrEmpty(errorMessage) && errorMessage != "Operation completed successfully.")
                        {
                            errorMessages.Add($"Error processing employee {validEmployee.EmpID}: {errorMessage}");
                            transaction.Dispose();
                            return string.Join(Environment.NewLine, errorMessages);
                        }
                    }
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    errorMessages.Add($"An unexpected error occurred: {ex.Message}");
                    transaction.Dispose();
                }
            }

            return string.Join(Environment.NewLine, errorMessages);
        }
        //Tis function is used to Validate Bulk uplod Users list .
        public string ValidateEmployee(UploadUserModel employee)
        {
            if (string.IsNullOrEmpty(employee.EmpID) || !int.TryParse(employee.EmpID, out int empId) || empId <= 0)
                return "EmpId cannot be empty or invalid.";

            if (string.IsNullOrEmpty(employee.FirstName))
                return "First Name cannot be empty.";

            if (string.IsNullOrEmpty(employee.LastName))
                return "Last Name cannot be empty.";

            if (string.IsNullOrEmpty(employee.Gender))
                return "Gender cannot be empty.";

            if (string.IsNullOrEmpty(employee.Gender) || !new[] { 'F', 'M' }.Contains(employee.Gender[0]))
                return "Gender must be either F or M.";

            if (string.IsNullOrEmpty(employee.Email))
                return "Email cannot be empty.";

            if (string.IsNullOrEmpty(employee.Email) || !Regex.IsMatch(employee.Email, @"^(.+)@.{2,}\..{2,}$"))
                return "Email is not in a valid format.";

            if (string.IsNullOrEmpty(employee.PhoneNumber))
                return "PhoneNumber cannot be empty.";

            if (string.IsNullOrEmpty(employee.PhoneNumber) || employee.PhoneNumber.Length != 10 || !employee.PhoneNumber.All(char.IsDigit))
                return "Mobile Number must be exactly 10 digits.";

            if (string.IsNullOrEmpty(employee.Block))
                return "Block cannot be empty.";

            if (string.IsNullOrEmpty(employee.Domain))
                return "Domain cannot be empty.";

            if (string.IsNullOrEmpty(employee.Department))
                return "Department cannot be empty.";

            if (string.IsNullOrEmpty(employee.Cadre))
                return "Cadre cannot be empty.";

            if (string.IsNullOrEmpty(employee.Status) || !new[] { "Active", "Inactive", "Block" }.Contains(employee.Status))
                return "Status must be one of the following: Active, Inactive, Block.";

            if (string.IsNullOrEmpty(employee.UserType))
                return "User Type cannot be empty.";

            return null;
        }



        public List<UserGridModel> GetIEDepart()
        {
            DataSet ds;
            List<UserGridModel> userviewModels = new List<UserGridModel>();
            ds = _repositoryUserTypedata.GetIEDepartData();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    userviewModels.Add(new UserGridModel
                    {
                        EmpID = dr["EmpID"].ToString(),
                        UserType = dr["Email"].ToString(),
                        Status = Convert.ToInt32(dr["Status"])
                    });
                }
            }
            return userviewModels;
        }
        public List<UserGridModel> GetFinance()
        {
            DataSet ds;
            List<UserGridModel> userviewModels = new List<UserGridModel>();
            ds = _repositoryUserTypedata.GetFinanceData();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    userviewModels.Add(new UserGridModel
                    {
                        EmpID = dr["EmpID"].ToString(),
                        UserType = dr["Email"].ToString(),
                        Status = Convert.ToInt32(dr["Status"])
                    });
                }
            }
            return userviewModels;
        }

        //This function is used to fetch UserList as per Passing Domain id from Controller.
        public List<UserGridModel> GetUsersByDomainId(int  domainId)
        {
            DataSet userData = new DataSet();
            List<UserGridModel> userGridData = new List<UserGridModel>();

            // Assuming _repositoryUserTypedata is set up to handle database calls
            userData = _repositoryUserTypedata.GetUsersByDomainId(domainId);

            if (userData.Tables.Count > 0)
            {
                foreach (DataRow dr in userData.Tables[0].Rows)
                {
                    userGridData.Add(new UserGridModel
                    {
                        EmpID = dr["EmpID"].ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Domain = dr["Domain"].ToString(),
                        Department = dr["Department"].ToString(),
                        UserType = dr["UserType"].ToString(),
                        ImageApprover = Convert.ToInt16(dr["ImageApprover"]),
                        Status = Convert.ToInt16(dr["Status"]),
                        PhoneNo = dr["PhoneNo"].ToString(),
                        Password = dr["Password"].ToString(),
                        Cadre = dr["CadreDesc"].ToString(),
                        BlockDesc = dr["Blockdesc"].ToString(),
                        TotalKaizenPosted = dr["TotalKaizenPosted"].ToString(),
                        role = dr["Role"].ToString(),
                        Id = dr["Id"].ToString(),
                    });
                }
            }

            return userGridData;
        }
        //This function is used to fetch UserList as per Passing Department id from Controller.
        public List<UserGridModel> GetUsersByDeptId(int domainId, int departmentId)
        {
            DataSet userData = new DataSet();
            List<UserGridModel> userGridData = new List<UserGridModel>();

            // Assuming _repositoryUserTypedata is set up to handle database calls
            userData = _repositoryUserTypedata.GetUsersByDeptId(domainId, departmentId);

            if (userData.Tables.Count > 0)
            {
                foreach (DataRow dr in userData.Tables[0].Rows)
                {
                    userGridData.Add(new UserGridModel
                    {
                        EmpID = dr["EmpID"].ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Domain = dr["Domain"].ToString(),
                        Department = dr["Department"].ToString(),
                        UserType = dr["UserType"].ToString(),
                        ImageApprover = Convert.ToInt16(dr["ImageApprover"]),
                        Status = Convert.ToInt16(dr["Status"]),
                        PhoneNo = dr["PhoneNo"].ToString(),
                        Password = dr["Password"].ToString(),
                        Cadre = dr["CadreDesc"].ToString(),
                        BlockDesc = dr["Blockdesc"].ToString(),
                        TotalKaizenPosted = dr["TotalKaizenPosted"].ToString(),
                        role = dr["Role"].ToString(),
                        Id = dr["Id"].ToString(),
                    });
                }
            }

            return userGridData;
        }

        //This function is used to fetch UserList as per Passing blockid from Controller.
        public List<UserGridModel> GetUsersByBlockId(int blockId)
        {
            DataSet userData = new DataSet();
            List<UserGridModel> userGridData = new List<UserGridModel>();

            // Assuming _repositoryUserTypedata is set up to handle database calls
            userData = _repositoryUserTypedata.GetUsersByBlockId(blockId);

            if (userData.Tables.Count > 0)
            {
                foreach (DataRow dr in userData.Tables[0].Rows)
                {
                    userGridData.Add(new UserGridModel
                    {
                        EmpID = dr["EmpID"].ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Domain = dr["Domain"].ToString(),  // Optional, depends on your data structure
                        Department = dr["Department"].ToString(),
                        UserType = dr["UserType"].ToString(),
                        ImageApprover = Convert.ToInt16(dr["ImageApprover"]),
                        Status = Convert.ToInt16(dr["Status"]),
                        PhoneNo = dr["PhoneNo"].ToString(),
                        Password = dr["Password"].ToString(),
                        Cadre = dr["CadreDesc"].ToString(),
                        BlockDesc = dr["BlockDesc"].ToString(),
                        TotalKaizenPosted = dr["TotalKaizenPosted"].ToString(),
                        role = dr["Role"].ToString(),
                        Id = dr["Id"].ToString(),
                    });
                }
            }

            return userGridData;
        }
        //This function is used to fetch Manager list as Passing Paramters .
        public List<UserGridModel> GetManagers(UserGridModel model)
        {
            DataSet userType = new DataSet();
            List<UserGridModel> UserGridData = new List<UserGridModel>();

            // Call the stored procedure or SQL command that already filters for Manager, IE, Finance
            userType = _repositoryUserTypedata.GetManagers(model);

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
                        Cadre = dr["Cadre"].ToString(),
                        
                    });
                }
            }

            return UserGridData;
        }
    }




}
