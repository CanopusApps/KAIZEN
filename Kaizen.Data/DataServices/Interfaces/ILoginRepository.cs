using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
