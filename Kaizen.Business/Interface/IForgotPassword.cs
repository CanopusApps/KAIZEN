using DocumentFormat.OpenXml.EMMA;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IForgotPassword
    {
        public string FetchEmail(string id);
        public bool UpdatePassword(LoginModel model);
    }
}
