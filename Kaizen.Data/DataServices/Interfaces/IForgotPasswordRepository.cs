using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IForgotPasswordRepository
    {
        public string FetchEmail(string id);
        public bool UpdatePassword(LoginModel model);
    }
}
