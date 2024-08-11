using DocumentFormat.OpenXml.EMMA;
using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
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

        
        public bool SubmitKaizenDri(NewKaizenModel model)
        {
          return _createNewKaizenRepository.SubmitKaizenDriData(model);
        }
        public bool UpdateNewKaizen(NewKaizenModel model)
        {
            return _createNewKaizenRepository.UpdateNewKaizenData(model);
        }
        
        public bool UpdateSubmittedKaizen(NewKaizenModel model)
        {
            return _createNewKaizenRepository.UpdateSubmittedKaizenData(model);
        }

        public bool updateKaizensatus(ApprovalRequest approvalRequest,string empid)
        {
            return _createNewKaizenRepository.updateKaizensatusData(approvalRequest, empid);
        }
        public List<NewKaizenModel> GetKaizenDetailsById(string KaizenId)
        {
            DataSet KalizenList = new DataSet();
            List<NewKaizenModel> KaizenData = new List<NewKaizenModel>();
            KalizenList = _createNewKaizenRepository.GetKaizenDetailsById(KaizenId);
            //string Approvalstatus = ApprovalStatusEnum.IEApproved.ToString();


            if (KalizenList.Tables.Count > 0)
            {
                foreach (DataRow dr in KalizenList.Tables[0].Rows)
                {
                    KaizenData.Add(new NewKaizenModel
                    {
                        DRIApprovedDate = dr["DRIApprovedDate"] != DBNull.Value ? ((DateTime)dr["DRIApprovedDate"]).ToString("dd-MM-yyyy") : string.Empty,
                        FinanceApprovedDate = dr["FinanceApprovedDate"] != DBNull.Value ? ((DateTime)dr["FinanceApprovedDate"]).ToString("dd-MM-yyyy") : string.Empty,
                        IEApprovedDate = dr["IEApprovedDate"] != DBNull.Value ? ((DateTime)dr["IEApprovedDate"]).ToString("dd-MM-yyyy") : string.Empty,
                        Rejectionreason = dr["Rejectionreason"].ToString(),
                        ApprovalStatus = Convert.ToInt32(dr["ApprovalStatus"]),
                        Approvalstatusdesc = dr["StatusDescription"].ToString(),
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
                        ApprovedByIE = dr["Email"].ToString(),
                        RootCause = dr["RootCause"].ToString(),
                        PresentCondition = dr["PresentCondition"].ToString(),
                        ImprovementsCompleted = dr["ImprovementsCompleted"].ToString(),
                        RootCauseDetails = dr["RootCauseDetails"].ToString(),
                        Benifits = dr["Benifits"].ToString(),
                        InOtherMc = dr["InOtherMC"].ToString(),
                        WithIntheDept = dr["WithIntheDept"].ToString(),
                        InOtherDept = dr["InOtherDept"].ToString(),
                        OtherPoints = dr["OtherPoints"].ToString(),
                        Id = dr["ID"].ToString(),

                        HorozantalDeployment = Convert.ToBoolean(dr["HorozantalDeployment"].ToString()),
                        OriginatedDate = dr["OrigonatedDate"] != DBNull.Value ? ((DateTime)dr["OrigonatedDate"]).ToString("dd-MM-yyyy") : string.Empty,
                        OrigionatedDept = dr["OrigionatedDept"].ToString(),
                        OriginatedBy= dr["OriginatedBy"].ToString(),
                        Dept = dr["Dept"].ToString()
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
                        FunctionName = dr["FunctionName"].ToString(),
                        EmpGuID = dr["EmpGuID"].ToString(),
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
        public List<Attachmentsimg> GetImageListById(string KaizenId)
        {
            DataSet ImageList = new DataSet();
            List<Attachmentsimg> Image = new List<Attachmentsimg>();
            ImageList = _createNewKaizenRepository.GetKaizenDetailsById(KaizenId);

            if (ImageList.Tables.Count > 0)
            {
                foreach (DataRow dr in ImageList.Tables[4].Rows)
                {
                    string filePath = dr["FileName"].ToString();
                    string base64String = ConvertFileToBase64(filePath);

                    Image.Add(new Attachmentsimg
                    {
                        FileName = base64String,
                        AttachmentType = dr["AttachmentType"].ToString(),
                        filePath= dr["FileName"].ToString(),
                        AttachmentId = dr["ID"].ToString()
                    });
                }
            }
            return Image;
        }
        private string ConvertFileToBase64(string filePath)
        {
            if (File.Exists(filePath))
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                return Convert.ToBase64String(fileBytes);
            }
            return null;
        }
        public List<Approvers> GetApproversByID(string KaizenId)
        {
            DataSet ApproversList = new DataSet();
            List<Approvers> ApproversData = new List<Approvers>();
            ApproversList = _createNewKaizenRepository.GetKaizenDetailsById(KaizenId);

            if (ApproversList.Tables.Count > 0)
            {
                foreach (DataRow dr in ApproversList.Tables[3].Rows)
                {
                    ApproversData.Add(new Approvers
                    {
                        KaizenId = dr["kaizenId"].ToString(),
                      ImageAproveName= dr["ImageAproveName"].ToString(),
                        DriName = dr["DriName"].ToString(),
                        FinnaceName = dr["FinnaceName"].ToString(),
                        IEname = dr["IEname"].ToString(),
                        DriEmail = dr["DriEmail"].ToString(),
                        FinanceEmail = dr["FinanceEmail"].ToString(),
                        IeEmail = dr["IeEmail"].ToString(),
                        DriDomain = dr["DriDomain"].ToString(),
                        IEDomain = dr["IEDomain"].ToString(),
                        FinDomain = dr["FinDomain"].ToString(),
                        DriDept = dr["DriDept"].ToString(),
                        FinDept= dr["FinDept"].ToString(),
                        IEDept = dr["IEDept"].ToString()
                    });
                }
            }
            return ApproversData;
        }

        public List<TeamMemberDetails> GetTeamDetailsUpdateById(string KaizenId)
        {
            DataSet TeamList = new DataSet();
            List<TeamMemberDetails> TeamData = new List<TeamMemberDetails>();
            TeamList = _createNewKaizenRepository.GetTeamDetailsUpdateById(KaizenId);

            if (TeamList.Tables.Count > 0)
            {
                foreach (DataRow dr in TeamList.Tables[0].Rows)
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

        public DataTable GetAttachmentsByIdfordelete(string KaizenId, string AttachmentId)
        {
            return _createNewKaizenRepository.GetImageListByIdfordelete(KaizenId, AttachmentId);
        }

        public void RemoveAttachment(Attachmentsimg attachment, string KaizenId)
        {
            // Delete from file system
            if (File.Exists(attachment.FileName))
            {
                File.Delete(attachment.FileName);
            }
            _createNewKaizenRepository.RemoveAttachment(attachment, KaizenId);
        }


    }

}
