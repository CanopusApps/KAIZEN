﻿using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using Microsoft.AspNetCore.Http;
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
        public bool CreateNewKaizen(NewKaizenModel model);
        public List<NewKaizenModel> GetKaizenDetailsById(string KaizenId);
        public List<TeamMemberDetails> GetTeamDetailsById(string KaizenId);
        public List<DeploymentDetails> GetScopeDetailsById(string KaizenId);
        public List<Attachmentsimg> GetImageListById(string KaizenId);


        public List<Approvers> GetApproversByID(string KaizenId);

        public bool updateKaizensatus(ApprovalRequest approvalRequest);


    }
}
