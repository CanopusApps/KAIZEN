using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Worker
{
    public class ForgotPasswordWorker : IForgotPassword
    {
        private readonly IForgotPasswordRepository _forgotPasswordRepository;
        public ForgotPasswordWorker(IForgotPasswordRepository forgotPasswordRepository)
        {
            _forgotPasswordRepository = forgotPasswordRepository;
        }
        public string FetchEmail(string id)
        {
            return _forgotPasswordRepository.FetchEmail(id);
        }
        public bool UpdatePassword(LoginModel model)
        {
            return _forgotPasswordRepository.UpdatePassword(model);
        }
    }
}
