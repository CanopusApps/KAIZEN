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
        public List<ApprovalStatusModel> GetApprovalStatus()
        {
            DataSet ds;
            List<ApprovalStatusModel> ApprovalStatus = new List<ApprovalStatusModel>();
            ds = _repositorySubmittedKaizenData.GetApprovalStatus();
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
        public List<KaizenListModel> GetKaizenList()
        {
            DataSet userType = new DataSet();
            List<KaizenListModel> KaizenGridData = new List<KaizenListModel>();
            userType = _repositorySubmittedKaizenData.GetKaizenList();

            if (userType.Tables.Count > 0)
            {
                foreach (DataRow dr in userType.Tables[0].Rows)
                {
                    KaizenGridData.Add(new KaizenListModel
                    {
                        KaizenTheme = dr["KaizenTheme"].ToString(),
                        TeamName = dr["TeamName"].ToString(),
                        Block = dr["Block"].ToString(),
                        HorozantalDeployment = dr["HorozantalDeployment"].ToString(),
                        IEApprovedDept = dr["IEApprovedDept"].ToString(),
                        FinanceApprovedBy = dr["FinanceApprovedBy"].ToString(),
                        Shortlisted = dr["Shortlisted"].ToString(),
                        ApprovalStatus = dr["ApprovalStatus"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString(),
                        CreatedDate = dr["CreatedDate"].ToString()
                    });
                }
            }
            return KaizenGridData;
        }
    }
}
