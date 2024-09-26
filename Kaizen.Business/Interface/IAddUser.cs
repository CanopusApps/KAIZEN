using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IAddUser
    {
        public string AddUser(AddUserModel addUserModel);
        public List<UserTypeModel> GetUserType();
		public List<CadreModel> GetCadre();
        public bool Checkuser(string value);
    }
}
