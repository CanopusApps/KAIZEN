using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kaizen.Models.ViewUserModel;
using System.Threading.Tasks;
using System.Data;
using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IViewuser
    {
        public DataSet GetUserType(UserTypeModel model);
        public DataSet GetDomain(DomainModel model);

        public DataSet GetDepartment(string DomainName);
        public DataSet GetUser(UserGridModel model);
        public string DeleteUser(UserGridModel model);
    }
}
