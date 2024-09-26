using Kaizen.Models.AdminModel;
using System.Data;

namespace Kaizen.Data.DataServices
{
    public interface ILoginRepository
    {
        public DataTable loginuser(LoginModel loginmodel);
        public DataSet usermanager(string EmpId);
        public DataSet FetchCountlist();
        public bool USERLOGIN(string EmpId);
        public bool USERLOGOUT(string EmpId);
        public DataSet GetWinnerImages();
        public DataSet usermanager1(string managerupt);
    }
}
