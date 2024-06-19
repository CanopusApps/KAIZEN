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

namespace Kaizen.Business.Worker
{
    public  class ViewuserWorker : IViewuser
    {
        public readonly IViewuserRepository _repositoryUserTypedata;
        public readonly IDomain _domain;

		public ViewuserWorker(IViewuserRepository repositoryUserdata)
        {
                this._repositoryUserTypedata = repositoryUserdata;
        }
        public List<UserGridModel> GetUser(UserGridModel model)
        {
			DataSet userType = new DataSet();
			List<UserGridModel> UserGridData = new List<UserGridModel>();
			userType = _repositoryUserTypedata.GetUser(model);

			if (userType.Tables.Count > 0)
			{
				foreach (DataRow dr in userType.Tables[0].Rows)
				{
					UserGridData.Add(new UserGridModel
					{
						EmpID = dr["EmpID"].ToString(),
						Name = dr["Name"].ToString(),
						Email = dr["Email"].ToString(),
						Gender = dr["Gender"].ToString(),
						Domain = dr["Domain"].ToString(),
						Department = dr["Department"].ToString(),
						UserType = dr["UserType"].ToString(),
						ImageApprover = Convert.ToInt16(dr["ImageApprover"]),
						Status = Convert.ToInt16(dr["Status"])
					});
				}
			}
			return UserGridData;
        }
        public bool DeleteUser(int id)
        {
            return _repositoryUserTypedata.DeleteUserData(id);
        }
        public List<StatusModel> GetStatus()
        {
            DataSet ds;
            List<StatusModel> Status = new List<StatusModel>();
            ds = _repositoryUserTypedata.GetStatus();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Status.Add(new StatusModel
                    {
                        StatusID = Convert.ToInt16(dr["StatusID"]),
                        StatusName = dr["StatusName"].ToString()
                    });
                }
            }
            return Status;
        }
        public void SaveUploadedFile(UploadUserModel Employee)
        {
            _repositoryUserTypedata.SaveUploadedFile(Employee);
        }
    }
}
