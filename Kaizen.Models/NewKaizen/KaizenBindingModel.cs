using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.NewKaizen;

namespace Kaizen.Models.NewKaizen
{
    public class KaizenBindingModel
    {
        public List<NewKaizenModel> KaizenList { get; set; }
        public List<TeamMemberDetails> TeamList { get; set; }
        public List<DeploymentDetails> ScopeList { get; set; }
    }
}
