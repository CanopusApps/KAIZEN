using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.NewKaizen
{
	public class NewKaizenModel
	{
		
		public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string VersionDate { get; set; }
		public string KaizenId { get; set; }
		public string KaizenType { get; set; }
		public string Activity { get; set; }
		public string ActivityDesc { get; set; }
		public string BenefitArea { get; set; }
		public string DocNo { get; set; }
		public string VersionNoDate { get; set; }
		public string CostCentre { get; set; }
		public string KaizenRefNo { get; set; }
		public string Block { get; set; }
		public string BlockDetails { get; set; }
		public string KaizenTheme { get; set; }
		public string SuggestedKaizen { get; set; }
		public string ProblemStatement { get; set; }
		public string CounterMeasure { get; set; }
		public IFormFile AttachmentBefore { get; set; }
		public IFormFile AttachmentAfter { get; set; }
		//public IFormFile AttachmentOthers { get; set; }
		public string Yield { get; set; }
		public string CycleTime { get; set; }
		public int Cost { get; set; }
		public string ManPower { get; set; }
		public string Consumables { get; set; }
		public string Others { get; set; }
		public string TotalSavings { get; set; }
		public string ApprovedByIE { get; set; }
		public string FinanceApprovedBy { get; set; }
		public int TeamMemberID { get; set; }
		public string RootCause { get; set; }
		public string PresentCondition { get; set; }
		public string ImprovementsCompleted { get; set; }
		public IFormFile RootProblemAttachment { get; set; }
		public string RootCauseDetails { get; set; }
		public bool HorozantalDeployment { get; set; }
		public int ScopeOfDeploymentID { get; set; }
		public string InOtherMc { get; set; }
		public string WithIntheDept { get; set; }
		public string InOtherDept { get; set; }
		public string OtherPoints { get; set; }
		public string Benifits { get; set; }
		public string name { get; set; }
		public string Domain { get; set; }
		public string Department { get; set; }
		public string EmpId { get; set; }
        public string OriginatedDate { get; set; }
        public string  IEEmail { get; set; }
        public string AccountEmail { get; set; }
        public int Shortlisted { get; set; }
        public int ApprovalStatus { get; set; }
        public string IEApprovedDate { get; set; }
        public string IEApprovedBy { get; set; }
        
        public string IEApprovedDept { get; set; }
        public string DRIApprovedDate { get; set; }
        public string DRIApprovedBy { get; set; }
        public string FinanceApprovedDate { get; set; }
        public string ImageApprovedDate { get; set; }
        public string ImageApprovedBy { get; set; }
        public string OriginatedBy { get; set; }
        public string OrigionatedDept { get; set; }
        public string ModifiedBy { get; set; }
		public string ModifiedDate { get; set; } 
		public bool insertStatus { get; set; }
        public string Empguid { get; set; }
        public List<BlockModel> BlockList { get; set; }
		public List<TeamMemberDetails> MemberList { get; set; }
		public List<DeploymentDetails> DeploymentList{ get; set; }

        public List<NewKaizenModel> KaizenList { get; set; }
        public List<TeamMemberDetails> TeamList { get; set; }
        public List<DeploymentDetails> ScopeList { get; set; }
        public List<Approvers> Approverslist { get; set; }
        public List<IFormFile> AdditionalAttachments { get; set; }
		public AttachmentPaths AttachmentPaths { get; set; }
        public List<Attachmentsimg> AttachmentsList { get; set; }


        public string LogFilePath { get; set; }
        public NewKaizenModel()
        {
            AttachmentPaths = new AttachmentPaths();
        }
    }
    public class NewKaizenGetOriginated
	{
		public string KcId { get; set; }
        public string name { get; set; }
        public string Domain { get; set; }
        public string Department { get; set; }
    }
    
    public class TeamMemberDetails
	{
		//public string MemberID { get; set; } = "";
       public string CreatedBy { get; set; } = "";
       //public string CreatedDate { get; set; } = "";
        public string EmpId { get; set; } = "";
		public string TeamMemberName { get; set; } = "";
        public string FunctionName { get; set; } = "";

        public string KaizenId { get; set; } = "";

    }

    public class DeploymentDetails
    {
        public string KcId { get; set; } = "";
        public string CreatedBy { get; set; } = "";
		//public string CreatedDate { get; set; } = "";
        public string MC { get; set; } = "";
        public DateTime TargetDate { get; set; }
        public string Responsibility { get; set; } = "";
        public string ScopeStatus { get; set; } = "";
        public string KaizenId { get; set; } = "";

        public string TargetFormatDate { get; set; }

    }

    public class AttachmentPaths
    {
        public string AttachmentBeforePath { get; set; }
        public string AttachmentAfterPath { get; set; }
        public string RootProblemAttachmentPath { get; set; }
        public List<string> AdditionalFilePaths { get; set; }

        public AttachmentPaths()
        {
            AdditionalFilePaths = new List<string>();
        }
    }

    public class Attachment
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string FileContent { get; set; }
	}


	public class Attachmentsimg
	{
		public string kaizenId { get; set; } = "";
		public string FileName { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string CreatedDate { get; set; } = "";

        public string AttachmentType { get; set; } = "";
    }


    public class Approvers
    {
        public string ImageAproveName { get; set; }
        public string DriName { get; set; }
        public string FinnaceName { get; set; }
        public string IEname { get; set; }
        public string DriEmail { get; set; }
        public string FinanceEmail { get; set; }
        public string IeEmail { get; set; }
        public string KaizenId { get; set; }
        public string DriDomain { get; set; }
        public string FinDomain { get; set; }
        public string IEDomain { get; set; }
        public string DriDept { get; set; }

        public string FinDept { get; set; }
        public string IEDept { get; set; }
    }
    public class ApprovalRequest
    {
        public int approvalStatus { get; set; }

        public string kaizenID { get; set; }


    }

}
