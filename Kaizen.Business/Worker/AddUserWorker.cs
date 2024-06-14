using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class AddUserWorker : IAddUser
    {
        public readonly IAddUserData addUserData;
        public AddUserWorker(IAddUserData addUserData) { 
          this.addUserData = addUserData;
        }
        public string AddUser(AddUserModel addUserModel)
        {
            string msg = addUserData.InsertUserData(addUserModel);
            return msg;
                
        }
    }
}
