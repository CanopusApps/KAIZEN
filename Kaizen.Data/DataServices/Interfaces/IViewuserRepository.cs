﻿using System.Data;
using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices
{
    public interface IViewuserRepository
    {
        //public DataTable GetUserType();
        //public DataSet GetDomain(DomainModel model);
        //public DataSet GetDepartment(string DomainName);
        public DataSet GetUser(UserGridModel model);
        public bool DeleteUserData(int id);
        public DataSet GetStatus();
        public string SaveUploadedFile(UploadUserModel Employee);
        public DataSet GetIEDepartData(); 
        public DataSet GetFinanceData();
        //users by domainid
        public DataSet GetUsersByDomainId(int  domainId);
        //users by deptid
        public DataSet GetUsersByDeptId(int domainId,int departmentId);
        //users by Blockid
        public DataSet GetUsersByBlockId(int blockId);
        public DataSet GetManagers(UserGridModel model);
    }
}
