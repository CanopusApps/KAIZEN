using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
          DataTable  dt = _createNewKaizenRepository.GetKaizenOriginatedbyData(model);
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
        public List<TeamMemberDetails> getTeamdetails(TeamMemberDetails model)
        {
            DataSet ds;
            List<TeamMemberDetails> TeamDetails = new List<TeamMemberDetails>();
            ds = _createNewKaizenRepository.GetTeamDetails(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TeamDetails.Add(new TeamMemberDetails
                    {
                        EmpId = dr["EmpID"].ToString(),
                        TeamMemberName = dr["TeamName"].ToString(),
                        FunctionName= dr["FunctionName"].ToString()
                    });
                }
            }
            return TeamDetails;
        }
        public List<DeploymentDetails> getScopeDetails(DeploymentDetails model)
        {
            DataSet ds;
            List<DeploymentDetails> ScopeDetails = new List<DeploymentDetails>();
            ds = _createNewKaizenRepository.getscopedetailsdata(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ScopeDetails.Add(new DeploymentDetails
                    {
                        MC = dr["MC"].ToString(),
                        TargetDate = Convert.ToDateTime(dr["TargetDate"].ToString()),
                        Responsibility = dr["Responsibility"].ToString(),
                        ScopeStatus = dr["ScopeStatus"].ToString(),
                    });
                }
            }
            return ScopeDetails;
        }
    }
}
