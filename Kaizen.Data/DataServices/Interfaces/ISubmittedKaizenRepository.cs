using System.Data;
using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices
{
    public interface ISubmittedKaizenRepository
    {
        public DataSet GetApprovalStatus(string UserType);
        public DataSet GetKaizenList(KaizenListModel model);
        public DataSet GetKaizenListOnclickDashboard(KaizenListModel model);
        public bool DeleteKaizenData(int KaizenId,string UserId);
    }
}
