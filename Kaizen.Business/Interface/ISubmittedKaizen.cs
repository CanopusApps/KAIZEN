using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Http;

namespace Kaizen.Business.Interface
{
    public interface ISubmittedKaizen
    {
        public List<ApprovalStatusModel> GetApprovalStatus();
        public List<KaizenListModel> GetKaizenList(KaizenListModel model);
        public bool DeleteKaizen(int KaizenId,string UserId);
    }
}
