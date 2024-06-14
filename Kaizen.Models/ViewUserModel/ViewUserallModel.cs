using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.ViewUserModel
{
    public class ViewUserallModel
    {
        public List<UserTypeModel> UserTypeList { get; set; }
        public List<DomainModel> DomainList { get; set; }
        public List<UserGridModel> UsergridList { get; set; }


    }
}
