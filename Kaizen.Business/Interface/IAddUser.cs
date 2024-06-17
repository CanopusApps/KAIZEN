using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IAddUser
    {
        public string AddUser(AddUserModel addUserModel);

        public List<UserTypeModel> GetUserType();
		public List<CadreModel> GetCadre();
	}
}
