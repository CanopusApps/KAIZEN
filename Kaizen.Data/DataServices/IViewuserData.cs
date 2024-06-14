using System;
using System.Collections.Generic;
using System.Data;
using Kaizen.Models.ViewUserModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices
{
    public interface IViewuserData
    {
        public DataSet GetUserType(UserTypeModel model);
        public DataSet GetDomain(DomainModel model);
        public DataSet GetDepartment(string DomainName);

        public DataSet GetUser(UserGridModel model);
        public string DeleteUserData(UserGridModel model);
    }
}
