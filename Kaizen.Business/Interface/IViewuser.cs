using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kaizen.Models.ViewUserModel;
using System.Threading.Tasks;
using System.Data;

namespace Kaizen.Business.Interface
{
    public interface IViewuser
    {
        public DataSet GetUserType(UserTypeModel model);
        public DataSet GetDomain(DomainModel model);
    }
}
