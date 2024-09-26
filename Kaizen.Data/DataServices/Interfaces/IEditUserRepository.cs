using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IEditUserRepository
    {
        public string EditUserData(EditUserModel editUserModel);
    }
}
