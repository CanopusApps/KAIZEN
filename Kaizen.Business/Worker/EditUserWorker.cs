using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class EditUserWorker : IEditUser
    {
        public readonly IEditUserRepository editUserData;

        public EditUserWorker(IEditUserRepository editUserData)
        {
            this.editUserData = editUserData;
        }
        public string EditUser(EditUserModel editUserModel)
        {
            string msg = editUserData.EditUserData(editUserModel);
            return msg;
        }
    }
}
