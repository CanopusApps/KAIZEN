using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    /// <summary>
    /// Interface for handling user registration operations.
    /// </summary>
    
    public interface IRegister
    {
        public string Registeruser(RegisterModel registermodel);

       
    }
}
