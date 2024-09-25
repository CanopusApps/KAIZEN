using Kaizen.Models.AdminModel;

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
