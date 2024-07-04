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
                com = new SqlCommand();
                DataTable dt = new DataTable();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", model.Id);
                //com.Parameters.AddWithValue("@KaizenId", model.KaizenId);
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


    }
}
