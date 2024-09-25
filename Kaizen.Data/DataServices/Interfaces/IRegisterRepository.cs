using Kaizen.Models.AdminModel;

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
