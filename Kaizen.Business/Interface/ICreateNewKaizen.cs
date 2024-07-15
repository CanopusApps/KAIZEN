using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface ICreateNewKaizen
    {
        public NewKaizenModel GetKaizenOriginatedby(NewKaizenModel model);

        public List<TeamMemberDetails> getTeamdetails(TeamMemberDetails model);
        public bool CreateNewKaizen(NewKaizenModel model);

        public List<DeploymentDetails> getScopeDetails(DeploymentDetails model);

    }
}
