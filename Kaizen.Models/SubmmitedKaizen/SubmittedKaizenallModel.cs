using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

namespace Kaizen.Models.ViewUserModel
{
    public class SubmittedKaizenallModel
    {
        public List<KaizenListModel> SubmittedKaizenList { get; set; }
        public List<DomainModel> DomainList { get; set; }
    }
}
