using Kaizen.Models.WinnersList;
using System;
using Kaizen.Models.AdminModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IForgotPasswordRepository
    {
        public string FetchEmail(string id);
        public bool UpdatePassword(LoginModel model);
    }
}
