using Kaizen.Models.AdminModel;
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
        public string CreatedDate { get; set; }
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
		public string AttachmentBefore { get; set; }
		public string AttachmentAfter { get; set; }
		public string AttachmentOthers { get; set; }
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
		public string RootProblemAttachment { get; set; }
		public string RootCauseDetails { get; set; }
		public bool HorozantalDeployment { get; set; }
		public int ScopeOfDeploymentID { get; set; }
		public string InOtherMc { get; set; }
		public string WithIntheDept { get; set; }
		public string InOtherDept { get; set; }
		public string OtherPoints { get; set; }
		public string Benifits { get; set; }
		public string name {  get; set; }
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
        public List<BlockModel> BlockList { get; set; }
		public List<TeamMemberDetails> MemberList { get; set; }
		public List<DeploymentDetails> DeploymentList{ get; set; }
        
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
       //public string CreatedBy { get; set; } = "";
       public string CreatedDate { get; set; } = "";
        public string EmpId { get; set; } = "";
		public string TeamMemberName { get; set; } = "";
        public string FunctionName { get; set; } = "";
    }

    public class DeploymentDetails
    {
        public string KcId { get; set; } = "";
        public string CreatedBy { get; set; } = "";
		public string CreatedDate { get; set; } = "";
        public string MC { get; set; } = "";
        public string TargetDate { get; set; } = "";
        public string Responsibility { get; set; } = "";
        public string ScopeStatus { get; set; } = "";

    }

}
