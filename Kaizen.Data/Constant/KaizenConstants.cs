using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.Constant
{
    public class KaizenConstants
    {

       public  static string LoggerPath = @"C:/LogFolder/";

    }
    public class DbFiles
    {
        public static string Data = "Data";
        public static string ConnectionString = "ConnectionString";
        public static string appsetting = "appsettings.json";
        public static string Title = "Title";


    }
    public class StoredProcedures
    {
        public static string splogin = "Sp_Login";
        public static string spregister = "Sp_Register";
        public static string spemployee = "Sp_Employee";
        public static string spregisterLog = "Sp_RegisterLog";
        public static string spSelectState = "Sp_SelectState";
        //public static string sp_CreateBlock = "Sp_CreateBlock";
        public static string sp_Fetch_Department = "Sp_Fetch_Department";
        public static string Sp_GetDomains= "Sp_Get_Domains";
        public static string sp_UpdateDomainStatus = "Sp_UpdateDomainStatus";
        public static string sp_Get_cadre = "Sp_Get_Cadre";
        public static string sp_Get_UserType = "Sp_Get_UserType";
        public static string Sp_InsertUser = "Sp_InsertUser";
		public static string sp_CreateDomain = "Sp_CreateDomain";
        public static string sp_DeleteDomain = "Sp_Delete_Domain";
        public static string sp_GetBlockDetails = "Sp_Get_BlockDetails";
        public static string sp_DeleteBlockDetails = "Sp_Delete_BlockDetails";
        public static string sp_UpdateBlockDetails = "Sp_UpdateBlockStatus";
        public static string sp_InsertBlockDetails = "Sp_AddBlockDetails";
		public static string sp_getUsers = "Sp_Get_Users";
		public static string Sp_GetDepartments = "Sp_Get_Departments";
		public static string sp_UpdateDepartmentStatus = "Sp_UpdateDepartmentStatus";
        public static string Sp_UpdateDepartment = "Sp_UpdateDepartment";
        public static string sp_DeleteDepartment = "Sp_Delete_Department";
		public static string sp_InsertDepartment = "Sp_InsertDepartment";
        public static string sp_Delete_User = "Sp_Delete_User";
        public static string sp_InsertDomain = "Sp_InsertDomain"; 
        public static string Sp_Get_Status = "Sp_Get_Status"; 
        public static string Sp_Upload_Users = "Sp_Upload_Users";
		public static string Sp_Update_Users = "Sp_UpdateUser";
        public static string sp_UpdateBlock = "Sp_UpdateBlock";
        public static string Sp_UpdateDomain = "Sp_UpdateDomain";
        public static string Sp_Get_Approval_Status = "Sp_Get_Approval_Status"; 
        public static string Sp_Get_Kaizen_Details = "Sp_Get_Kaizen_Details";
        public static string SpGetKaizenOriginetedby = "Sp_Get_KaizenOriginetedby";
        public static string SpKaizen_Insert = "Sp_Kaizen_Insert";
    }
}
