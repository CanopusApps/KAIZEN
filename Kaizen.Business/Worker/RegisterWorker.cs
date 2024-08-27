using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{

    public class RegisterWorker : IRegister
    {
        public readonly IRegisterRepository _regdata;

        public RegisterWorker(IRegisterRepository _regdata)
        {
            this._regdata = _regdata;
        }
       
        public string Registeruser(RegisterModel registermodel)
        {
            string msg = _regdata.Registeruser(registermodel);
            return msg;
        }


    }
}
