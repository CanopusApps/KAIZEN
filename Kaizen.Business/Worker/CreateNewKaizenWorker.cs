using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class CreateNewKaizenWorker : ICreateNewKaizen
    {
        public readonly ICreateNewKaizenRepository _createNewKaizenRepository;


        public CreateNewKaizenWorker(ICreateNewKaizenRepository repositoryDomaindata)

        {

            this._createNewKaizenRepository = repositoryDomaindata;

        }
        public NewKaizenModel GetKaizenOriginatedby(NewKaizenModel model)
        {
            DataTable dt = _createNewKaizenRepository.GetKaizenOriginatedbyData(model);
            foreach (DataRow row in dt.Rows)
            {
                model.Empguid = string.IsNullOrEmpty($"{row["ID"]}") ? string.Empty : Convert.ToString($"{row["ID"]}");
                model.EmpId = string.IsNullOrEmpty($"{row["EmpID"]}") ? string.Empty : Convert.ToString($"{row["EmpID"]}");
                model.name = string.IsNullOrEmpty($"{row["UserName"]}") ? string.Empty : Convert.ToString($"{row["UserName"]}");
                model.Domain = string.IsNullOrEmpty($"{row["DomainName"]}") ? string.Empty : Convert.ToString($"{row["DomainName"]}");
                model.Department = string.IsNullOrEmpty($"{row["DepartmentName"]}") ? string.Empty : Convert.ToString($"{row["DepartmentName"]}");
                model.OriginatedDate = string.IsNullOrEmpty($"{row["CurrentDate"]}") ? string.Empty : Convert.ToString($"{row["CurrentDate"]}");
            }
            return model;
        }

        public bool CreateNewKaizen(NewKaizenModel model)
        {
            return _createNewKaizenRepository.CreateNewKaizenData(model);
        }
        public List<NewKaizenModel> GetKaizenDetailsById(string KaizenId)
        {
            DataSet KalizenList = new DataSet();
            List<NewKaizenModel> KaizenData = new List<NewKaizenModel>();
            KalizenList = _createNewKaizenRepository.GetKaizenDetailsById(KaizenId);

            if (KalizenList.Tables.Count > 0)
            {
                foreach (DataRow dr in KalizenList.Tables[0].Rows)
                {
                    KaizenData.Add(new NewKaizenModel
                    {
                        Activity = dr["Activity"].ToString(),
                        ActivityDesc = dr["ActivityDesc"].ToString(),
                        BenefitArea = dr["BenefitArea"].ToString(),
                        DocNo = dr["DocNo"].ToString(),
                        VersionNoDate = dr["VersionNoDate"].ToString(),
                        CostCentre = dr["CostCentre"].ToString(),
                        KaizenRefNo = dr["KaizenRefNo"].ToString(),
                        KaizenTheme = dr["KaizenTheme"].ToString(),
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
                        RootCause = dr["RootCause"].ToString(),
                        PresentCondition = dr["PresentCondition"].ToString(),
                        ImprovementsCompleted = dr["ImprovementsCompleted"].ToString(),
                        RootCauseDetails = dr["RootCauseDetails"].ToString(),
                        Benifits = dr["Benifits"].ToString(),
                        InOtherMc = dr["InOtherMC"].ToString(),
                        WithIntheDept = dr["WithIntheDept"].ToString(),
                        InOtherDept = dr["InOtherDept"].ToString(),
                        OtherPoints = dr["OtherPoints"].ToString(),
                        DRIApprovedDate = dr["DRIApprovedDate"] != DBNull.Value ? ((DateTime)dr["DRIApprovedDate"]).ToString("dd-MM-yyyy") : string.Empty,
                        HorozantalDeployment = Convert.ToBoolean(dr["HorozantalDeployment"].ToString()),
                        OriginatedDate = dr["OrigonatedDate"] != DBNull.Value ? ((DateTime)dr["OrigonatedDate"]).ToString("dd-MM-yyyy") : string.Empty,
                        OrigionatedDept = dr["OrigionatedDept"].ToString(),
                        OriginatedBy= dr["OriginatedBy"].ToString(),
                    });
                }
            }
            return KaizenData;
        }
        public List<TeamMemberDetails> GetTeamDetailsById(string KaizenId)
        {
            DataSet TeamList = new DataSet();
            List<TeamMemberDetails> TeamData = new List<TeamMemberDetails>();
            TeamList = _createNewKaizenRepository.GetKaizenDetailsById(KaizenId);

            if (TeamList.Tables.Count > 0)
            {
                foreach (DataRow dr in TeamList.Tables[1].Rows)
                {
                    TeamData.Add(new TeamMemberDetails
                    {
                        EmpId = dr["EmpID"].ToString(),
                        TeamMemberName = dr["TeamName"].ToString(),
                        FunctionName = dr["FunctionName"].ToString()
                    });
                }
            }
            return TeamData;
        }
        public List<DeploymentDetails> GetScopeDetailsById(string KaizenId)
        {
            DataSet ScopeList = new DataSet();
            List<DeploymentDetails> ScopeData = new List<DeploymentDetails>();
            ScopeList = _createNewKaizenRepository.GetKaizenDetailsById(KaizenId);

            if (ScopeList.Tables.Count > 0)
            {
                foreach (DataRow dr in ScopeList.Tables[2].Rows)
                {
                    ScopeData.Add(new DeploymentDetails
                    {
                        MC = dr["MC"].ToString(),
                        TargetFormatDate = ((DateTime)dr["TargetDate"]).ToString("dd-MM-yyyy"),
                        Responsibility = dr["Responsibility"].ToString(),
                        ScopeStatus = dr["ScopeStatus"].ToString(),
                    });
                }
            }
            return ScopeData;
        }
    }

}
