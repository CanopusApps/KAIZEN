using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IEditUser
    {
        public string EditUser(EditUserModel editUserModel);

        public List<CadreModel> GetCadre();

        public List<StatusModel> GetStatus();
    }
}
