using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;

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
