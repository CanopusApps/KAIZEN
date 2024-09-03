using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
