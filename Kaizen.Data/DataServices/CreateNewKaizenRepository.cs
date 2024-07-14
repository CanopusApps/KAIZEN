using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Kaizen.Models.NewKaizen;
using Kaizen.Models.AdminModel;
using Newtonsoft.Json;

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
                model.ApprovalStatus = ConstantValue.ApprovalStatus;
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
                //string memberjson = Newtonsoft.Json.JsonConvert.SerializeObject(model.MemberList);
                //            DataTable memberDataTable = JsonConvert.DeserializeObject<DataTable>(memberjson);

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
				//string deploymentjson = Newtonsoft.Json.JsonConvert.SerializeObject(model.DeploymentList);
				//            DataTable deploymentDataTable = JsonConvert.DeserializeObject<DataTable>(deploymentjson);
				com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@KaizenTeam", memberDataTable);
                com.Parameters.AddWithValue("@KaizenScopeDetails", deploymentDataTable);
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
                com.Parameters.AddWithValue("@AttachmentBefore", model.AttachmentBefore);
                com.Parameters.AddWithValue("@AttachmentAfter", model.AttachmentAfter);
                com.Parameters.AddWithValue("@AttachmentOthers", model.AttachmentOthers);
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
                com.Parameters.AddWithValue("@RootProblemAttachment", model.RootProblemAttachment);
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
                com.Parameters.AddWithValue("@OrigonatedDate", model.OriginatedDate);
                com.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                com.Parameters.AddWithValue("@ModifiedDate", model.ModifiedDate);
                com.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                com.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
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
            return status;
        }

        public DataSet GetTeamDetails(TeamMemberDetails model)
        {
            DataSet ds = new DataSet();
            try
            {
                    com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@KaizenId", model.KaizenId);
                    com.CommandText = StoredProcedures.Sp_Fetch_TeamMember;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(ds);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
