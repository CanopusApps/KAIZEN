using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IForgotPassword
    {
        public string FetchEmail(string id);
        public bool UpdatePassword(LoginModel model);
    }
}
