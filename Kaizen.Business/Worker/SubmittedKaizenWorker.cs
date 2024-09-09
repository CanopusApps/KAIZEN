using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Kaizen.Data.Constant;

namespace Kaizen.Business.Worker
{
    public  class SubmittedKaizenWorker : ISubmittedKaizen
    {
        public readonly ISubmittedKaizenRepository _repositorySubmittedKaizenData;
        public readonly IDomain _domain;

		public SubmittedKaizenWorker(ISubmittedKaizenRepository repositoryUserdata)
        {
                this._repositorySubmittedKaizenData = repositoryUserdata;
        }
        public List<ApprovalStatusModel> GetApprovalStatus(string UserType)
        {
            DataSet ds;
            List<ApprovalStatusModel> ApprovalStatus = new List<ApprovalStatusModel>();
            ds = _repositorySubmittedKaizenData.GetApprovalStatus(UserType);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ApprovalStatus.Add(new ApprovalStatusModel
                    {
                        StatusID = Convert.ToInt16(dr["StatusID"]),
                        StatusDescription = dr["StatusDescription"].ToString()
                    });
                }
            }
            return ApprovalStatus;
        }
        public List<KaizenListModel> GetKaizenList(KaizenListModel model)
        {
            DataSet userType = new DataSet();
            List<KaizenListModel> KaizenGridData = new List<KaizenListModel>();
            userType = _repositorySubmittedKaizenData.GetKaizenList(model);

            if (userType.Tables.Count > 0)
            {
                foreach (DataRow dr in userType.Tables[0].Rows)
                {
                    KaizenGridData.Add(new KaizenListModel
                    {
                        KaizenTheme = dr["KaizenTheme"].ToString(),
                        TeamName = dr["TeamName"].ToString(),
                        HorozantalDeployment = dr["HorozantalDeployment"].ToString(),
                        IEApprovedDept = dr["IEApprovedDept"].ToString(),
                        FinnanceDeptAppr = dr["FinnanceDeptAppr"].ToString(),
                        ApprovalStatus = dr["ApprovalStatus"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString(),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        KaizenId = dr["KaizenId"].ToString(),
                        KaizenType = dr["KaizenType"].ToString(),
                        Activity = dr["Activity"].ToString(),
                        ActivityDesc = dr["ActivityDesc"].ToString(),
                        BenefitArea = dr["BenefitArea"].ToString(),
                        DocNo = dr["DocNo"].ToString(),
                        VersionNoDate = dr["VersionNoDate"].ToString(),
                        CostCentre = dr["CostCentre"].ToString(),
                        KaizenRefNo = dr["KaizenRefNo"].ToString(),
                        Block = dr["Block"].ToString(),
                        BlockDetails = dr["BlockDetails"].ToString(),
                        SuggestedKaizen = dr["SuggestedKaizen"].ToString(),
                        ProblemStatement = dr["ProblemStatement"].ToString(),
                        CounterMeasure = dr["CounterMeasure"].ToString(),
                        Yield = dr["Yield"].ToString(),
                        CycleTime = dr["CycleTime"].ToString(),
                        Cost = Convert.ToInt32(dr["Cost"].ToString()),
                        ManPower = dr["ManPower"].ToString(),
                        Consumables = dr["Consumables"].ToString(),
                        Others = dr["Others"].ToString(),
                        TotalSavings = dr["TotalSavings"].ToString(),
                        TeamMemberID= Convert.ToInt32(dr["TeamMemberID"].ToString()),
                        RootCause = dr["RootCause"].ToString(),
                        PresentCondition = dr["PresentCondition"].ToString(),
                        ImprovementsCompleted = dr["ImprovementsCompleted"].ToString(),
                        RootProblemAttachment = dr["RootProblemAttachment"].ToString(),
                        RootCauseDetails = dr["RootCauseDetails"].ToString(),
                        ScopeOfDeploymentID =Convert.ToInt32(dr["ScopeOfDeploymentId"].ToString()),
                        InOtherMc = dr["InOtherMC"].ToString(),
                        WithIntheDept = dr["WithIntheDept"].ToString(),
                        InOtherDept = dr["InOtherDept"].ToString(),
                        OtherPoints = dr["OtherPoints"].ToString(),
                        Benifits = dr["Benifits"].ToString(),
                        OriginatedDate = dr["OrigonatedDate"].ToString(),
                        OrigionatedDept = dr["OrigionatedDept"].ToString(),
                        AStatus= int.Parse(dr["Status"].ToString()),
                        PostedBy= dr["PostedBy"].ToString(),
                        role= dr["Role"].ToString()
                    });
                }
            }
            return KaizenGridData;
        }
        public bool DeleteKaizen(int KaizenId, string UserId)
        {

            return _repositorySubmittedKaizenData.DeleteKaizenData(KaizenId, UserId);

        }

        public List<KaizenListModel> GetKaizenListOnclickdashboard(KaizenListModel model)
        {
            DataSet userType = new DataSet();
            List<KaizenListModel> KaizenGridData = new List<KaizenListModel>();
            userType = _repositorySubmittedKaizenData.GetKaizenListOnclickDashboard(model);

            if (userType.Tables.Count > 0)
            {
                foreach (DataRow dr in userType.Tables[0].Rows)
                {
                    KaizenGridData.Add(new KaizenListModel
                    {
                        KaizenTheme = dr["KaizenTheme"].ToString(),
                        TeamName = dr["TeamName"].ToString(),
                        HorozantalDeployment = dr["HorozantalDeployment"].ToString(),
                        IEApprovedDept = dr["IEApprovedDept"].ToString(),
                        FinnanceDeptAppr = dr["FinnanceDeptAppr"].ToString(),
                        ApprovalStatus = dr["ApprovalStatus"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString(),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        KaizenId = dr["KaizenId"].ToString(),
                        KaizenType = dr["KaizenType"].ToString(),
                        Activity = dr["Activity"].ToString(),
                        ActivityDesc = dr["ActivityDesc"].ToString(),
                        BenefitArea = dr["BenefitArea"].ToString(),
                        DocNo = dr["DocNo"].ToString(),
                        VersionNoDate = dr["VersionNoDate"].ToString(),
                        CostCentre = dr["CostCentre"].ToString(),
                        KaizenRefNo = dr["KaizenRefNo"].ToString(),
                        Block = dr["Block"].ToString(),
                        BlockDetails = dr["BlockDetails"].ToString(),
                        SuggestedKaizen = dr["SuggestedKaizen"].ToString(),
                        ProblemStatement = dr["ProblemStatement"].ToString(),
                        CounterMeasure = dr["CounterMeasure"].ToString(),
                        Yield = dr["Yield"].ToString(),
                        CycleTime = dr["CycleTime"].ToString(),
                        Cost = Convert.ToInt32(dr["Cost"].ToString()),
                        ManPower = dr["ManPower"].ToString(),
                        Consumables = dr["Consumables"].ToString(),
                        Others = dr["Others"].ToString(),
                        TotalSavings = dr["TotalSavings"].ToString(),
                        TeamMemberID = Convert.ToInt32(dr["TeamMemberID"].ToString()),
                        RootCause = dr["RootCause"].ToString(),
                        PresentCondition = dr["PresentCondition"].ToString(),
                        ImprovementsCompleted = dr["ImprovementsCompleted"].ToString(),
                        RootProblemAttachment = dr["RootProblemAttachment"].ToString(),
                        RootCauseDetails = dr["RootCauseDetails"].ToString(),
                        ScopeOfDeploymentID = Convert.ToInt32(dr["ScopeOfDeploymentId"].ToString()),
                        InOtherMc = dr["InOtherMC"].ToString(),
                        WithIntheDept = dr["WithIntheDept"].ToString(),
                        InOtherDept = dr["InOtherDept"].ToString(),
                        OtherPoints = dr["OtherPoints"].ToString(),
                        Benifits = dr["Benifits"].ToString(),
                        OriginatedDate = dr["OrigonatedDate"].ToString(),
                        OrigionatedDept = dr["OrigionatedDept"].ToString(),
                        AStatus = int.Parse(dr["Status"].ToString()),
                        PostedBy = dr["PostedBy"].ToString(),
                        role = dr["Role"].ToString()
                    });
                }
            }
            return KaizenGridData;
        }
    }
}
