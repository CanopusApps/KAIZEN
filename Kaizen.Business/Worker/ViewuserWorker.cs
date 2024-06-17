using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

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

  //      public List<UserTypeModel> GetUserType()
  //      {
		//	DataTable dt;
		//	List<UserTypeModel> userType = new List<UserTypeModel>();
		//	dt = _repositoryUserTypedata.GetUserType();
		//	if (dt.Rows.Count > 0)
		//	{
		//		foreach (DataRow dr in dt.Rows)
		//		{
		//			userType.Add(new UserTypeModel
		//			{
		//				UserTypeId = Convert.ToInt16(dr["UserTypeId"]),
		//				UserDesc = dr["UserDesc"].ToString()
		//			});
		//		}
		//	}
		//	return userType;
		//}
		//public List<DomainModel> GetDomain()
		//{
		//	DataTable dt;
		//	List<DomainModel> domainModels = new List<DomainModel>();
		//	dt = _repositoryDomaindata.GetDomaindetails();
		//	if (dt.Rows.Count > 0)
		//	{
		//		foreach (DataRow dr in dt.Rows)
		//		{
		//			domainModels.Add(new DomainModel
		//			{
		//				id = Convert.ToInt32(dr["DomainId"]),
		//				domainName = dr["DomainName"].ToString(),
		//				status = Convert.ToBoolean(dr["Status"])
		//			});
		//		}
		//	}
		//	return domainModels;

		//}
		//public DataSet GetDepartment(string DomainName)
  //      {
  //          DataSet ds = new DataSet();
  //          ds = _repositoryUserTypedata.GetDepartment(DomainName);
  //          return ds;
  //      }
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
    }
}
