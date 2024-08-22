using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Enumeration;

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
        public static string Sp_Register = "Sp_Register";
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
		public static string Sp_Update_Users = "Sp_EditUser";
        public static string sp_UpdateBlock = "Sp_UpdateBlock";
        public static string Sp_UpdateDomain = "Sp_UpdateDomain";
        public static string Sp_Get_Approval_Status = "Sp_Get_Approval_Status"; 
        public static string Sp_Get_Kaizen_Details = "Sp_Get_Kaizen_Details";
        public static string SpGetKaizenOriginetedby = "Sp_Get_KaizenOriginetedby";
        public static string SpKaizen_Insert = "Sp_Kaizen_Insert";
        public static string SpKaizen_Update = "Sp_Kaizen_Update";
        public static string Sp_Fetch_TeamMember = "Sp_Fetch_TeamMember"; 
        public static string Sp_UserProfile = "Sp_UserProfile";
        public static string SpGetUserManager = "Sp_GetUserManager";
        public static string Sp_Fetch_KaizenDetails_ById = "Sp_Fetch_KaizenDetails_ById";
        public static string Sp_UpdateApprovalStatus = "UpdateApprovalStatus";
        public static string sp_GetEmployeeDashboardDetails = "sp_GetEmployeeDashboardDetails";
        public static string Sp_Get_KaizenformReport = "Sp_Get_KaizenformReport";
        public static string Sp_Get_BlockformReport = "Sp_Get_BlockformReport";
        public static string Sp_Get_DomainformReport = "Sp_Get_DomainformReport";
        public static string Sp_Get_DepartmentformReport = "Sp_Get_DepartmentformReport";
        public static string Sp_Get_UserformReport = "Sp_Get_UserformReport";
        public static string Sp_DashboardFilter = "Sp_DashboardFilter";
       public static string Sp_Get_DashboardDomains = "sp_Get_DashboardDomains"; 
          public static string Sp_Get_DashboardDepartments = "Sp_Get_DashboardDepartments"; 
        public static string Sp_Get_Dashboardgraphs = "Sp_Get_Dashboardgraphs";
        public static string sp_GetKaizenStatisticsByApprovalTypes = "sp_GetKaizenStatisticsByApprovalTypes";
        public static string Sp_Get_DashboardManagerDomainDepartment = "Sp_Get_DashboardManagerDomainDepartment";
        public static string Sp_Fetch_Scope_details = "Sp_Fetch_Scope_details";
        public static string Sp_Get_IEDeptDetails = "Sp_Get_IEDeptDetails";
        public static string SpAddWinner = "Sp_AddWinner";
        public static string SpGetWinnersList = "Sp_GetWinnersList";
        public static string SpDeleteWinner = "Sp_DeleteWinner";
        public static string SpUpdateWinner = "Sp_UpdateWinner";
        public static string SpUpdateWinnerStatus = "Sp_UpdateWinnerStatus";
        public static string Sp_Get_KaizenProfileDetails = "Sp_Get_KaizenProfileDetails";
        public static string Sp_Delete_Kaizens = "Sp_Delete_Kaizens";
        public static string SpUpdateTheme = "Sp_UpdateTheme";
        public static string Sp_LoginWinnerDetails = "Sp_LoginWinnerDetails";
        public static string SpGetTheme = "Sp_GetTheme";
        public static string Sp_Fetch_KaizenUpdateDetails_ById = "Sp_Fetch_KaizenUpdateDetails_ById";
        public static string Sp_Fetch_KaizenAttachments_ById = "Sp_Fetch_KaizenAttachments_ById";
        public static string Sp_DeleteAttachmentsByKaizenID = "Sp_DeleteAttachmentsByKaizenID";
        public static string SpFetchEmail = "Sp_FetchEmail";
        public static string SpUpdatePassword = "Sp_UpdatePassword";
        //public static string Sp_Get_kaizenTheme_Autocomplete = "Sp_Get_kaizenTheme_Autocomplete";
        public static string SP_USERLOG = "SP_USERLOG";
        public static string Sp_GetUserManagerupdate = "Sp_GetUserManagerupdate";
    }

    public class ConstantValue
    {
        public static string KaizenType = "k";
        public static int ApprovalStatus = 0;

    }


    public enum ApprovalStatusEnum
    {
        Saved,            // 0
        Submitted,        // 1
        ImageApproved,    // 2
        ImageRejected,    // 3
        DRIApproved,      // 4
        DRIRejected,      // 5
        IEApproved,       // 6
        IERejected,       // 7
        FinanceApproved,  // 8
        FinanceRejected,  // 9
        pending,//10
        DRIPending,//11
        IEPending,//12
        FinancePending,//13
        Deleted,//14
        SubmittedWithoutImages,//15
        KaizenApproved         // 16

    }


}
