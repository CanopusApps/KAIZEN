using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface ISubmittedKaizen
    {
        public List<ApprovalStatusModel> GetApprovalStatus(string UserType);
        public List<KaizenListModel> GetKaizenList(KaizenListModel model);
        public List<KaizenListModel> GetKaizenListOnclickdashboard(KaizenListModel model);
        public bool DeleteKaizen(int KaizenId,string UserId);
    }
}
