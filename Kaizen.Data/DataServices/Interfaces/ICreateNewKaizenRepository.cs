﻿using Kaizen.Models.NewKaizen;
using System.Data;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface ICreateNewKaizenRepository
    {
        public DataTable GetKaizenOriginatedbyData(NewKaizenModel model);
        public bool CreateNewKaizenData(NewKaizenModel model);
        public bool SubmitKaizenDriData(NewKaizenModel model);
        public bool UpdateNewKaizenData(NewKaizenModel model);
        public bool UpdateSubmittedKaizenData(NewKaizenModel model);
        public bool updateKaizensatusData(ApprovalRequest approvalRequest, string empid);
        public DataSet GetKaizenDetailsById(string KaizenId);
        public DataSet GetTeamDetailsUpdateById(string KaizenId);
        public DataTable GetImageListByIdfordelete(string KaizenId ,string AttachmentId);
        public void RemoveAttachment(Attachmentsimg attachment, string KaizenId);
        public DataSet Usermanagerforedit(string managerupt);
        public DataSet GetFinanceApproved(int EmpId);
    }
}
