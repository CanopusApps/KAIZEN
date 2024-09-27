using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Kaizen.Models.NewKaizen;

namespace Kaizen.Data.DataServices
{
    public class CreateNewKaizenRepository : ICreateNewKaizenRepository
    {
        public static string SqlConnectionString { get; set; }
        private static SqlConnection con = null;
        private static SqlCommand com = null;
        SqlDataAdapter da = null;
        public CreateNewKaizenRepository()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection(DbFiles.Data).GetSection(DbFiles.ConnectionString).Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(DbFiles.appsetting, optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public DataTable GetKaizenOriginatedbyData(NewKaizenModel model)
        {
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@empId", model.EmpId);
                com.CommandText = StoredProcedures.SpGetKaizenOriginetedby;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public bool CreateNewKaizenData(NewKaizenModel model)
        {
            bool status = false;
            try
            {
                model.KaizenType = ConstantValue.KaizenType;
                model.ApprovalStatus = (int)ApprovalStatusEnum.Saved;
                DataTable memberDataTable = new DataTable();
                memberDataTable.Columns.Add("KaizenId", typeof(Guid));
                memberDataTable.Columns.Add("Createdby", typeof(Guid));
                memberDataTable.Columns.Add("EmpId", typeof(Guid));
                memberDataTable.Columns.Add("TeamMemberName", typeof(string));
                memberDataTable.Columns.Add("FunctionName", typeof(string));
                if (model.MemberList != null) { 
                    foreach (TeamMemberDetails memberList in model.MemberList)
                    {
                        memberDataTable.Rows.Add(memberList.KaizenId, memberList.CreatedBy, memberList.EmpId, memberList.TeamMemberName, memberList.FunctionName);

                    }
                }

                DataTable deploymentDataTable = new DataTable();
                deploymentDataTable.Columns.Add("KaizenId", typeof(Guid));
                deploymentDataTable.Columns.Add("Createdby", typeof(Guid));
                deploymentDataTable.Columns.Add("MC", typeof(string));
                deploymentDataTable.Columns.Add("TargetDate", typeof(DateTime));
                deploymentDataTable.Columns.Add("Responsibility", typeof(string));
                deploymentDataTable.Columns.Add("ScopeStatus", typeof(string));
                if (model.DeploymentList != null)
                {
                    foreach (DeploymentDetails deploymentDetails in model.DeploymentList)
                    {
                        deploymentDataTable.Rows.Add(deploymentDetails.KaizenId, deploymentDetails.CreatedBy, deploymentDetails.MC, deploymentDetails.TargetDate,
                            deploymentDetails.Responsibility, deploymentDetails.ScopeStatus);
                    }
                }

                DataTable attachmentDataTable = new DataTable();
                attachmentDataTable.Columns.Add("KaizenId", typeof(Guid));
                attachmentDataTable.Columns.Add("FileName", typeof(string));
                attachmentDataTable.Columns.Add("Createdby", typeof(Guid));
                
                
                if (model.AttachmentsList != null)
                {
                    foreach (Attachmentsimg attachmentsimg in model.AttachmentsList)
                    {
                        attachmentDataTable.Rows.Add(attachmentsimg.kaizenId, attachmentsimg.FileName, attachmentsimg.CreatedBy);
                    }
                }
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenTeam", memberDataTable);
                com.Parameters.AddWithValue("@KaizenScopeDetails", deploymentDataTable);
                com.Parameters.AddWithValue("@AttachmentDetails", attachmentDataTable);
                com.Parameters.AddWithValue("@ID", model.Id);
                com.Parameters.AddWithValue("@KaizenType", model.KaizenType);
                com.Parameters.AddWithValue("@Activity", model.Activity);
                com.Parameters.AddWithValue("@ActivityDesc", model.ActivityDesc);
                com.Parameters.AddWithValue("@BenefitArea", model.BenefitArea);
                com.Parameters.AddWithValue("@DocNo", model.DocNo);
                com.Parameters.AddWithValue("@VersionNoDate", model.VersionNoDate);
                com.Parameters.AddWithValue("@CostCentre", model.CostCentre);
                com.Parameters.AddWithValue("@KaizenRefNo", model.KaizenRefNo);
                com.Parameters.AddWithValue("@Block", model.Block);
                com.Parameters.AddWithValue("@BlockDetails", model.BlockDetails);
                com.Parameters.AddWithValue("@KaizenTheme", model.KaizenTheme);
                com.Parameters.AddWithValue("@SuggestedKaizen", model.SuggestedKaizen);
                com.Parameters.AddWithValue("@ProblemStatement", model.ProblemStatement);
                com.Parameters.AddWithValue("@CounterMeasure", model.CounterMeasure);
                com.Parameters.AddWithValue("@Yield", model.Yield);
                com.Parameters.AddWithValue("@CycleTime", model.CycleTime);
                com.Parameters.AddWithValue("@Cost", model.Cost);
                com.Parameters.AddWithValue("@ManPower", model.ManPower);
                com.Parameters.AddWithValue("@Consumables", model.Consumables);
                com.Parameters.AddWithValue("@Others", model.Others);
                com.Parameters.AddWithValue("@TotalSavings", model.TotalSavings);
                com.Parameters.AddWithValue("@ApprovedByIE", model.ApprovedByIE);
                com.Parameters.AddWithValue("@FinanceApprovedBy", model.FinanceApprovedBy);
                com.Parameters.AddWithValue("@TeamMemberID", model.TeamMemberID);
                com.Parameters.AddWithValue("@RootCause", model.RootCause);
                com.Parameters.AddWithValue("@PresentCondition", model.PresentCondition);
                com.Parameters.AddWithValue("@ImprovementsCompleted", model.ImprovementsCompleted);
                com.Parameters.AddWithValue("@RootCauseDetails", model.RootCauseDetails);
                com.Parameters.AddWithValue("@HorozantalDeployment", model.HorozantalDeployment);
                com.Parameters.AddWithValue("@ScopeOfDeploymentID", model.ScopeOfDeploymentID);
                com.Parameters.AddWithValue("@InOtherMc", model.InOtherMc);
                com.Parameters.AddWithValue("@WithIntheDept", model.WithIntheDept);
                com.Parameters.AddWithValue("@InOtherDept", model.InOtherDept);
                com.Parameters.AddWithValue("@OtherPoints", model.OtherPoints);
                com.Parameters.AddWithValue("@Benifits", model.Benifits);
                com.Parameters.AddWithValue("@Shortlisted", model.Shortlisted);
                com.Parameters.AddWithValue("@ApprovalStatus", model.ApprovalStatus);
                com.Parameters.AddWithValue("@IEApprovedDate", model.IEApprovedDate);
                com.Parameters.AddWithValue("@IEApprovedBy", model.IEApprovedBy);
                com.Parameters.AddWithValue("@IEApprovedDept", model.IEApprovedDept);
                com.Parameters.AddWithValue("@DRIApprovedDate", model.DRIApprovedDate);
                com.Parameters.AddWithValue("@DRIApprovedBy", model.DRIApprovedBy);
                com.Parameters.AddWithValue("@FinanceApprovedDate", model.FinanceApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedDate", model.ImageApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedBy", model.ImageApprovedBy);
                com.Parameters.AddWithValue("@OriginatedBy", model.OriginatedBy);
                com.Parameters.AddWithValue("@OrigionatedDept", model.OrigionatedDept);
                com.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                com.Parameters.AddWithValue("@ModifiedDate", model.ModifiedDate);
                com.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                com.Parameters.AddWithValue("@Department", model.Department);
                com.Parameters.AddWithValue("@Domain", model.Domain);
                com.CommandText = StoredProcedures.SpKaizen_Insert;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
        }
        public bool SubmitKaizenDriData(NewKaizenModel model)
        {
            bool status = false;
            try
            {
                if (model.AttachmentsList != null)
                {
                    foreach (Attachmentsimg attachmentsimg in model.AttachmentsList)
                    {
                        if (attachmentsimg.FileName != null)
                        {
                            if (attachmentsimg.FileName.Contains("AttachmentBefore") ||
                                attachmentsimg.FileName.Contains("AttachmentAfter") ||
                             attachmentsimg.FileName.Contains("AdditionalAttachments"))
                            {
                                model.ApprovalStatus = (int)ApprovalStatusEnum.Submitted;
                            }
                            
                        }
                        
                    }
                  
                }
                if (model.ApprovalStatus != (int)ApprovalStatusEnum.Submitted)
                {
                    model.ApprovalStatus = (int)ApprovalStatusEnum.SubmittedWithoutImages;
                }
                model.KaizenType = ConstantValue.KaizenType;
              
                DataTable memberDataTable = new DataTable();
                memberDataTable.Columns.Add("KaizenId", typeof(Guid));
                memberDataTable.Columns.Add("Createdby", typeof(Guid));
                memberDataTable.Columns.Add("EmpId", typeof(Guid));
                memberDataTable.Columns.Add("TeamMemberName", typeof(string));
                memberDataTable.Columns.Add("FunctionName", typeof(string));
                if (model.MemberList != null)
                {
                    foreach (TeamMemberDetails memberList in model.MemberList)
                    {
                        memberDataTable.Rows.Add(memberList.KaizenId, memberList.CreatedBy, memberList.EmpId, memberList.TeamMemberName, memberList.FunctionName);

                    }
                }

                DataTable deploymentDataTable = new DataTable();
                deploymentDataTable.Columns.Add("KaizenId", typeof(Guid));
                deploymentDataTable.Columns.Add("Createdby", typeof(Guid));
                deploymentDataTable.Columns.Add("MC", typeof(string));
                deploymentDataTable.Columns.Add("TargetDate", typeof(DateTime));
                deploymentDataTable.Columns.Add("Responsibility", typeof(string));
                deploymentDataTable.Columns.Add("ScopeStatus", typeof(string));
                if (model.DeploymentList != null)
                {
                    foreach (DeploymentDetails deploymentDetails in model.DeploymentList)
                    {
                        deploymentDataTable.Rows.Add(deploymentDetails.KaizenId, deploymentDetails.CreatedBy, deploymentDetails.MC, deploymentDetails.TargetDate,
                            deploymentDetails.Responsibility, deploymentDetails.ScopeStatus);
                    }
                }

                DataTable attachmentDataTable = new DataTable();
                attachmentDataTable.Columns.Add("KaizenId", typeof(Guid));
                attachmentDataTable.Columns.Add("FileName", typeof(string));
                attachmentDataTable.Columns.Add("Createdby", typeof(Guid));


                if (model.AttachmentsList != null)
                {
                    foreach (Attachmentsimg attachmentsimg in model.AttachmentsList)
                    {
                        attachmentDataTable.Rows.Add(attachmentsimg.kaizenId, attachmentsimg.FileName, attachmentsimg.CreatedBy);
                    }
                }
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenTeam", memberDataTable);
                com.Parameters.AddWithValue("@KaizenScopeDetails", deploymentDataTable);
                com.Parameters.AddWithValue("@AttachmentDetails", attachmentDataTable);
                com.Parameters.AddWithValue("@ID", model.Id);
                com.Parameters.AddWithValue("@KaizenType", model.KaizenType);
                com.Parameters.AddWithValue("@Activity", model.Activity);
                com.Parameters.AddWithValue("@ActivityDesc", model.ActivityDesc);
                com.Parameters.AddWithValue("@BenefitArea", model.BenefitArea);
                com.Parameters.AddWithValue("@DocNo", model.DocNo);
                com.Parameters.AddWithValue("@VersionNoDate", model.VersionNoDate);
                com.Parameters.AddWithValue("@CostCentre", model.CostCentre);
                com.Parameters.AddWithValue("@KaizenRefNo", model.KaizenRefNo);
                com.Parameters.AddWithValue("@Block", model.Block);
                com.Parameters.AddWithValue("@BlockDetails", model.BlockDetails);
                com.Parameters.AddWithValue("@KaizenTheme", model.KaizenTheme);
                com.Parameters.AddWithValue("@SuggestedKaizen", model.SuggestedKaizen);
                com.Parameters.AddWithValue("@ProblemStatement", model.ProblemStatement);
                com.Parameters.AddWithValue("@CounterMeasure", model.CounterMeasure);
                com.Parameters.AddWithValue("@Yield", model.Yield);
                com.Parameters.AddWithValue("@CycleTime", model.CycleTime);
                com.Parameters.AddWithValue("@Cost", model.Cost);
                com.Parameters.AddWithValue("@ManPower", model.ManPower);
                com.Parameters.AddWithValue("@Consumables", model.Consumables);
                com.Parameters.AddWithValue("@Others", model.Others);
                com.Parameters.AddWithValue("@TotalSavings", model.TotalSavings);
                com.Parameters.AddWithValue("@ApprovedByIE", model.ApprovedByIE);
                com.Parameters.AddWithValue("@FinanceApprovedBy", model.FinanceApprovedBy);
                com.Parameters.AddWithValue("@TeamMemberID", model.TeamMemberID);
                com.Parameters.AddWithValue("@RootCause", model.RootCause);
                com.Parameters.AddWithValue("@PresentCondition", model.PresentCondition);
                com.Parameters.AddWithValue("@ImprovementsCompleted", model.ImprovementsCompleted);
                com.Parameters.AddWithValue("@RootCauseDetails", model.RootCauseDetails);
                com.Parameters.AddWithValue("@HorozantalDeployment", model.HorozantalDeployment);
                com.Parameters.AddWithValue("@ScopeOfDeploymentID", model.ScopeOfDeploymentID);
                com.Parameters.AddWithValue("@InOtherMc", model.InOtherMc);
                com.Parameters.AddWithValue("@WithIntheDept", model.WithIntheDept);
                com.Parameters.AddWithValue("@InOtherDept", model.InOtherDept);
                com.Parameters.AddWithValue("@OtherPoints", model.OtherPoints);
                com.Parameters.AddWithValue("@Benifits", model.Benifits);
                com.Parameters.AddWithValue("@Shortlisted", model.Shortlisted);
                com.Parameters.AddWithValue("@ApprovalStatus", model.ApprovalStatus);
                com.Parameters.AddWithValue("@IEApprovedDate", model.IEApprovedDate);
                com.Parameters.AddWithValue("@IEApprovedBy", model.IEApprovedBy);
                com.Parameters.AddWithValue("@IEApprovedDept", model.IEApprovedDept);
                com.Parameters.AddWithValue("@DRIApprovedDate", model.DRIApprovedDate);
                com.Parameters.AddWithValue("@DRIApprovedBy", model.DRIApprovedBy);
                com.Parameters.AddWithValue("@FinanceApprovedDate", model.FinanceApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedDate", model.ImageApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedBy", model.ImageApprovedBy);
                com.Parameters.AddWithValue("@OriginatedBy", model.OriginatedBy);
                com.Parameters.AddWithValue("@OrigionatedDept", model.OrigionatedDept);
                com.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                com.Parameters.AddWithValue("@ModifiedDate", model.ModifiedDate);
                com.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                com.Parameters.AddWithValue("@Department", model.Department);
                com.Parameters.AddWithValue("@Domain", model.Domain);
                com.CommandText = StoredProcedures.SpKaizen_Insert;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
        }
        public bool UpdateNewKaizenData(NewKaizenModel model)
        {
            bool status = false;
            try
            {
                model.KaizenType = ConstantValue.KaizenType;
                model.ApprovalStatus = (int)ApprovalStatusEnum.Saved;
                DataTable memberDataTable = new DataTable();
                memberDataTable.Columns.Add("KaizenId", typeof(Guid));
                memberDataTable.Columns.Add("Createdby", typeof(Guid));
                memberDataTable.Columns.Add("EmpId", typeof(Guid));
                memberDataTable.Columns.Add("TeamMemberName", typeof(string));
                memberDataTable.Columns.Add("FunctionName", typeof(string));
                if (model.MemberList != null)
                {
                    foreach (TeamMemberDetails memberList in model.MemberList)
                    {
                        memberDataTable.Rows.Add(memberList.KaizenId, memberList.CreatedBy, memberList.EmpId, memberList.TeamMemberName, memberList.FunctionName);

                    }
                }

                //DataTable deploymentDataTable = new DataTable();
                //deploymentDataTable.Columns.Add("KaizenId", typeof(Guid));
                //deploymentDataTable.Columns.Add("Createdby", typeof(Guid));
                //deploymentDataTable.Columns.Add("MC", typeof(string));
                //deploymentDataTable.Columns.Add("TargetDate", typeof(DateTime));
                //deploymentDataTable.Columns.Add("Responsibility", typeof(string));
                //deploymentDataTable.Columns.Add("ScopeStatus", typeof(string));
                //if (model.DeploymentList != null)
                //{
                //    foreach (DeploymentDetails deploymentDetails in model.DeploymentList)
                //    {
                //        deploymentDataTable.Rows.Add(deploymentDetails.KaizenId, deploymentDetails.CreatedBy, deploymentDetails.MC, deploymentDetails.TargetDate,
                //            deploymentDetails.Responsibility, deploymentDetails.ScopeStatus);
                //    }
                //}

                DataTable attachmentDataTable = new DataTable();
                attachmentDataTable.Columns.Add("KaizenId", typeof(Guid));
                attachmentDataTable.Columns.Add("FileName", typeof(string));
                attachmentDataTable.Columns.Add("Createdby", typeof(Guid));


                if (model.AttachmentsList != null)
                {
                    foreach (Attachmentsimg attachmentsimg in model.AttachmentsList)
                    {
                        attachmentDataTable.Rows.Add(attachmentsimg.kaizenId, attachmentsimg.FileName, attachmentsimg.CreatedBy);
                    }
                }
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenTeam", memberDataTable);
                //com.Parameters.AddWithValue("@KaizenScopeDetails", deploymentDataTable);
                com.Parameters.AddWithValue("@AttachmentDetails", attachmentDataTable);

                com.Parameters.AddWithValue("@ID", model.Id);
                com.Parameters.AddWithValue("@KaizenId", model.KaizenId);
                com.Parameters.AddWithValue("@KaizenType", model.KaizenType);
                com.Parameters.AddWithValue("@Activity", model.Activity);
                com.Parameters.AddWithValue("@ActivityDesc", model.ActivityDesc);
                com.Parameters.AddWithValue("@BenefitArea", model.BenefitArea);
                com.Parameters.AddWithValue("@DocNo", model.DocNo);
                com.Parameters.AddWithValue("@VersionNoDate", model.VersionNoDate);
                com.Parameters.AddWithValue("@CostCentre", model.CostCentre);
                com.Parameters.AddWithValue("@KaizenRefNo", model.KaizenRefNo);
                com.Parameters.AddWithValue("@Block", model.Block);
                com.Parameters.AddWithValue("@BlockDetails", model.BlockDetails);
                com.Parameters.AddWithValue("@KaizenTheme", model.KaizenTheme);
                com.Parameters.AddWithValue("@SuggestedKaizen", model.SuggestedKaizen);
                com.Parameters.AddWithValue("@ProblemStatement", model.ProblemStatement);
                com.Parameters.AddWithValue("@CounterMeasure", model.CounterMeasure);
                com.Parameters.AddWithValue("@Yield", model.Yield);
                com.Parameters.AddWithValue("@CycleTime", model.CycleTime);
                com.Parameters.AddWithValue("@Cost", model.Cost);
                com.Parameters.AddWithValue("@ManPower", model.ManPower);
                com.Parameters.AddWithValue("@Consumables", model.Consumables);
                com.Parameters.AddWithValue("@Others", model.Others);
                com.Parameters.AddWithValue("@TotalSavings", model.TotalSavings);
                com.Parameters.AddWithValue("@ApprovedByIE", model.ApprovedByIE);
                com.Parameters.AddWithValue("@FinanceApprovedBy", model.FinanceApprovedBy);
                com.Parameters.AddWithValue("@TeamMemberID", model.TeamMemberID);
                com.Parameters.AddWithValue("@RootCause", model.RootCause);
                com.Parameters.AddWithValue("@PresentCondition", model.PresentCondition);
                com.Parameters.AddWithValue("@ImprovementsCompleted", model.ImprovementsCompleted);
                com.Parameters.AddWithValue("@RootCauseDetails", model.RootCauseDetails);
                com.Parameters.AddWithValue("@HorozantalDeployment", model.HorozantalDeployment);
                com.Parameters.AddWithValue("@ScopeOfDeploymentID", model.ScopeOfDeploymentID);
                com.Parameters.AddWithValue("@InOtherMc", model.InOtherMc);
                com.Parameters.AddWithValue("@WithIntheDept", model.WithIntheDept);
                com.Parameters.AddWithValue("@InOtherDept", model.InOtherDept);
                com.Parameters.AddWithValue("@OtherPoints", model.OtherPoints);
                com.Parameters.AddWithValue("@Benifits", model.Benifits);
                com.Parameters.AddWithValue("@Shortlisted", model.Shortlisted);
                com.Parameters.AddWithValue("@ApprovalStatus", model.ApprovalStatus);
                com.Parameters.AddWithValue("@IEApprovedDate", model.IEApprovedDate);
                com.Parameters.AddWithValue("@IEApprovedBy", model.IEApprovedBy);
                com.Parameters.AddWithValue("@IEApprovedDept", model.IEApprovedDept);
                com.Parameters.AddWithValue("@DRIApprovedDate", model.DRIApprovedDate);
                com.Parameters.AddWithValue("@DRIApprovedBy", model.DRIApprovedBy);
                com.Parameters.AddWithValue("@FinanceApprovedDate", model.FinanceApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedDate", model.ImageApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedBy", model.ImageApprovedBy);
                com.Parameters.AddWithValue("@OriginatedBy", model.OriginatedBy);
                com.Parameters.AddWithValue("@OrigionatedDept", model.OrigionatedDept);
                com.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                com.Parameters.AddWithValue("@ModifiedDate", model.ModifiedDate);
                com.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                com.Parameters.AddWithValue("@Department", model.Department);
                com.Parameters.AddWithValue("@Domain", model.Domain);
                com.CommandText = StoredProcedures.SpKaizen_Update;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
        }
        public bool UpdateSubmittedKaizenData(NewKaizenModel model)
        {
            bool status = false;
            try
            {
                model.KaizenType = ConstantValue.KaizenType;
                //model.ApprovalStatus = (int)ApprovalStatusEnum.Submitted;
                if (model.UpdateAttachmentsList.Count >0)
                {
                    foreach (Attachmentsimg attachmentsimg in model.UpdateAttachmentsList)
                    {
                        if (attachmentsimg.filePath != null)
                        {
                            if (attachmentsimg.filePath.Contains("AttachmentBefore") ||
                                attachmentsimg.filePath.Contains("AttachmentAfter") ||
                             attachmentsimg.filePath.Contains("AdditionalAttachments"))
                            {
                                model.ApprovalStatus = (int)ApprovalStatusEnum.Submitted;
                            }
                            
                        }                        
                    }
                }
                if (model.AttachmentsList != null)
                {
                    foreach (Attachmentsimg attachmentsimg in model.AttachmentsList)
                    {
                        if (attachmentsimg.FileName != null)
                        {
                            if (attachmentsimg.FileName.Contains("AttachmentBefore") ||
                                attachmentsimg.FileName.Contains("AttachmentAfter") ||
                             attachmentsimg.FileName.Contains("AdditionalAttachments"))
                            {
                                model.ApprovalStatus = (int)ApprovalStatusEnum.Submitted;
                            }
                            
                        }
                        
                    }
                }
                if (model.ApprovalStatus != (int)ApprovalStatusEnum.Submitted)
                {
                    model.ApprovalStatus = (int)ApprovalStatusEnum.SubmittedWithoutImages;
                }
                DataTable memberDataTable = new DataTable();
                memberDataTable.Columns.Add("KaizenId", typeof(Guid));
                memberDataTable.Columns.Add("Createdby", typeof(Guid));
                memberDataTable.Columns.Add("EmpId", typeof(Guid));
                memberDataTable.Columns.Add("TeamMemberName", typeof(string));
                memberDataTable.Columns.Add("FunctionName", typeof(string));
                if (model.MemberList != null)
                {
                    foreach (TeamMemberDetails memberList in model.MemberList)
                    {
                        memberDataTable.Rows.Add(memberList.KaizenId, memberList.CreatedBy, memberList.EmpId, memberList.TeamMemberName, memberList.FunctionName);

                    }
                }
                DataTable attachmentDataTable = new DataTable();
                attachmentDataTable.Columns.Add("KaizenId", typeof(Guid));
                attachmentDataTable.Columns.Add("FileName", typeof(string));
                attachmentDataTable.Columns.Add("Createdby", typeof(Guid));


                if (model.AttachmentsList != null)
                {
                    foreach (Attachmentsimg attachmentsimg in model.AttachmentsList)
                    {
                        attachmentDataTable.Rows.Add(attachmentsimg.kaizenId, attachmentsimg.FileName, attachmentsimg.CreatedBy);
                    }
                }
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenTeam", memberDataTable);
                com.Parameters.AddWithValue("@AttachmentDetails", attachmentDataTable);

                com.Parameters.AddWithValue("@ID", model.Id);
                com.Parameters.AddWithValue("@KaizenId", model.KaizenId);
                com.Parameters.AddWithValue("@KaizenType", model.KaizenType);
                com.Parameters.AddWithValue("@Activity", model.Activity);
                com.Parameters.AddWithValue("@ActivityDesc", model.ActivityDesc);
                com.Parameters.AddWithValue("@BenefitArea", model.BenefitArea);
                com.Parameters.AddWithValue("@DocNo", model.DocNo);
                com.Parameters.AddWithValue("@VersionNoDate", model.VersionNoDate);
                com.Parameters.AddWithValue("@CostCentre", model.CostCentre);
                com.Parameters.AddWithValue("@KaizenRefNo", model.KaizenRefNo);
                com.Parameters.AddWithValue("@Block", model.Block);
                com.Parameters.AddWithValue("@BlockDetails", model.BlockDetails);
                com.Parameters.AddWithValue("@KaizenTheme", model.KaizenTheme);
                com.Parameters.AddWithValue("@SuggestedKaizen", model.SuggestedKaizen);
                com.Parameters.AddWithValue("@ProblemStatement", model.ProblemStatement);
                com.Parameters.AddWithValue("@CounterMeasure", model.CounterMeasure);
                com.Parameters.AddWithValue("@Yield", model.Yield);
                com.Parameters.AddWithValue("@CycleTime", model.CycleTime);
                com.Parameters.AddWithValue("@Cost", model.Cost);
                com.Parameters.AddWithValue("@ManPower", model.ManPower);
                com.Parameters.AddWithValue("@Consumables", model.Consumables);
                com.Parameters.AddWithValue("@Others", model.Others);
                com.Parameters.AddWithValue("@TotalSavings", model.TotalSavings);
                com.Parameters.AddWithValue("@ApprovedByIE", model.ApprovedByIE);
                com.Parameters.AddWithValue("@FinanceApprovedBy", model.FinanceApprovedBy);
                com.Parameters.AddWithValue("@TeamMemberID", model.TeamMemberID);
                com.Parameters.AddWithValue("@RootCause", model.RootCause);
                com.Parameters.AddWithValue("@PresentCondition", model.PresentCondition);
                com.Parameters.AddWithValue("@ImprovementsCompleted", model.ImprovementsCompleted);
                com.Parameters.AddWithValue("@RootCauseDetails", model.RootCauseDetails);
                com.Parameters.AddWithValue("@HorozantalDeployment", model.HorozantalDeployment);
                com.Parameters.AddWithValue("@ScopeOfDeploymentID", model.ScopeOfDeploymentID);
                com.Parameters.AddWithValue("@InOtherMc", model.InOtherMc);
                com.Parameters.AddWithValue("@WithIntheDept", model.WithIntheDept);
                com.Parameters.AddWithValue("@InOtherDept", model.InOtherDept);
                com.Parameters.AddWithValue("@OtherPoints", model.OtherPoints);
                com.Parameters.AddWithValue("@Benifits", model.Benifits);
                com.Parameters.AddWithValue("@Shortlisted", model.Shortlisted);
                com.Parameters.AddWithValue("@ApprovalStatus", model.ApprovalStatus);
                com.Parameters.AddWithValue("@IEApprovedDate", model.IEApprovedDate);
                com.Parameters.AddWithValue("@IEApprovedBy", model.IEApprovedBy);
                com.Parameters.AddWithValue("@IEApprovedDept", model.IEApprovedDept);
                com.Parameters.AddWithValue("@DRIApprovedDate", model.DRIApprovedDate);
                com.Parameters.AddWithValue("@DRIApprovedBy", model.DRIApprovedBy);
                com.Parameters.AddWithValue("@FinanceApprovedDate", model.FinanceApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedDate", model.ImageApprovedDate);
                com.Parameters.AddWithValue("@ImageApprovedBy", model.ImageApprovedBy);
                com.Parameters.AddWithValue("@OriginatedBy", model.OriginatedBy);
                com.Parameters.AddWithValue("@OrigionatedDept", model.OrigionatedDept);
                com.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                com.Parameters.AddWithValue("@ModifiedDate", model.ModifiedDate);
                com.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                com.Parameters.AddWithValue("@Department", model.Department);
                com.Parameters.AddWithValue("@Domain", model.Domain);
                com.CommandText = StoredProcedures.SpKaizen_Update;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
        }
        public DataSet GetKaizenDetailsById(string KaizenId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenId", KaizenId);
                com.CommandText = StoredProcedures.Sp_Fetch_KaizenDetails_ById;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataTable GetImageListByIdfordelete(string KaizenId, string Attachmentid)
        {
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenId", KaizenId);
                com.Parameters.AddWithValue("@AttachID", Attachmentid);
                com.CommandText = StoredProcedures.Sp_Fetch_KaizenAttachments_ById;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataSet GetTeamDetailsUpdateById(string KaizenId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenId", KaizenId);
                com.CommandText = StoredProcedures.Sp_Fetch_KaizenUpdateDetails_ById;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public bool updateKaizensatusData(ApprovalRequest approvalRequest,string empid)
        {
            bool status = false;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenId", approvalRequest.kaizenID);
                com.Parameters.AddWithValue("@Empid",empid);
                com.Parameters.AddWithValue("@ApprovalStatus", approvalRequest.approvalStatus);
                com.Parameters.AddWithValue("@Rejectionreason", approvalRequest.RejectionReason);
                com.CommandText = StoredProcedures.Sp_UpdateApprovalStatus;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return status=true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
			finally
			{
				con.Close();
			}
			return status;
            
        }
        public void RemoveAttachment(Attachmentsimg attachment, string KaizenId)
        {
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@kaizenID", KaizenId);
                com.Parameters.AddWithValue("@FileName", attachment.FileName);
                com.CommandText = StoredProcedures.Sp_DeleteAttachmentsByKaizenID;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
			finally
			{
				con.Close();
			}
			return;
        }
        public DataSet Usermanagerforedit(string managerupt)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_GetUserManagerupdate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@departid", managerupt);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public DataSet GetFinanceApproved(int EmpId) 
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_GetfinanceIebyID", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", EmpId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}
