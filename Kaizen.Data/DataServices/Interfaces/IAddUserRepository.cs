using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IAddUserRepository
    {
       
        public string InsertUserData(AddUserModel addUserModel);

        public DataSet GetCadreList();
        public DataSet GetUserTypeList();

        


	}
}
