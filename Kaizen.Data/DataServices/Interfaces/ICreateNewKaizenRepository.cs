using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface ICreateNewKaizenRepository
    {
      public DataTable GetKaizenOriginatedbyData(NewKaizenModel model);
      public bool CreateNewKaizenData(NewKaizenModel model);
      public bool SubmitKaizenDriData(NewKaizenModel model);
        public bool UpdateNewKaizenData(NewKaizenModel model);
        public bool UpdateSubmittedKaizenData(NewKaizenModel model);
        public bool updateKaizensatusData(ApprovalRequest approvalRequest);
      public DataSet GetKaizenDetailsById(string KaizenId);
    }
}
