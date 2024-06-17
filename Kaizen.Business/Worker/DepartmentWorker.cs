using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class DepartmentWorker : IDepartment
    {
        public readonly IDepartmentRepository _repositoryDepartmentdata;

        public DepartmentWorker(IDepartmentRepository repositoryDepartmentdata)

        {

            this._repositoryDepartmentdata = repositoryDepartmentdata;

        }

        public bool InsertDepartment(int domainId, string domainName, string departmentName)
        {           
              return _repositoryDepartmentdata.InsertDepartment(domainName,domainId,departmentName);
        }

        public List<DepartmentModel> GetDepartments()
        {
            DataSet ds;
            List<DepartmentModel> deptModels = new List<DepartmentModel>();
            ds = _repositoryDepartmentdata.GetDepartments();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    deptModels.Add(new DepartmentModel
                    {
                        DeptId = Convert.ToInt32(dr["DeptId"]),
                        DepartmentName = dr["DepartmentName"].ToString(),
                        DomainId = Convert.ToInt32(dr["DomainId"].ToString()),
                        DomainName = dr["DomainName"].ToString(),
                        Status = Convert.ToBoolean(dr["Status"])
                    });
                }
            }
            return deptModels;

        }		

		public bool DeleteDepartment(int id)
		{
			return _repositoryDepartmentdata.DeleteDepartment(id);
		}

		public bool UpdateDepartmentStatus(bool status, int id)
		{
			return _repositoryDepartmentdata.UpdateDepartmentStatus(id, status);
		}
	}
}
