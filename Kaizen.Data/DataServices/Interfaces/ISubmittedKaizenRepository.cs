using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices
{
    public interface ISubmittedKaizenRepository
    {
        public DataSet GetApprovalStatus(string UserType);
        public DataSet GetKaizenList(KaizenListModel model);

        public bool DeleteKaizenData(int KaizenId,string UserId);
        public DataSet GetKaizenThemeforAutucomplete();
    }
}
