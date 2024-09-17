using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    /// <summary>
    /// Interface for handling data operations related to user registration.
    /// </summary>
    public interface IRegisterRepository
    {
        public string Registeruser(RegisterModel registermodel);

        
    }
}
