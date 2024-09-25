using Kaizen.Models.AdminModel;
using System.Data;

namespace Kaizen.Business.Interface
{
    public interface ILogin
    {
        public DataTable Loginuser(LoginModel loginmodel);
        public List<ManagerModel> Usermanager(string Empid);
        public List<CountModel> FetchCount();
        public bool USERLOGIN(string EmpId);
        public bool USERLOGOUT(string EmpId);
        public List<ManagerModel> Usermanager1(string managerupt);
        public List<LoginImageModel> FetchImages();
    }
}
