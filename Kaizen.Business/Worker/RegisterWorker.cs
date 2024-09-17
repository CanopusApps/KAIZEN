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


        /// <summary>
        /// Initializes a new instance of the RegisterWorker class with the specified registration repository.
        /// </summary>
        /// <param name="_regdata">The repository handling data operations for user registration.</param>
        public RegisterWorker(IRegisterRepository _regdata)
        {
            this._regdata = _regdata;
        }

        /// <summary>
        /// Registers a new user by passing the provided RegisterModel to the repository and returns the result message.
        /// </summary>
        /// <param name="registermodel">The model containing the user registration data.</param>
        /// <returns>A string message indicating the result of the registration process.</returns>
        public string Registeruser(RegisterModel registermodel)
        {
            string msg = _regdata.Registeruser(registermodel);
            return msg;
        }


    }
}
