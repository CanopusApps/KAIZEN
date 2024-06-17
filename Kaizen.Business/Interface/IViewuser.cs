using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IViewuser
    {
        //public List<UserTypeModel> GetUserType();
        //public List<DomainModel> GetDomain();

        //public DataSet GetDepartment(string DomainName);
        public List<UserGridModel> GetUser(UserGridModel model);
        public bool DeleteUser(int id);
    }
}
