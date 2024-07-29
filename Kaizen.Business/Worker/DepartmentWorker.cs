using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
        public bool CreateDepartment(DepartmentModel departmentModel)
        {
            return _repositoryDepartmentdata.CreateDepartmentData(departmentModel);
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
                        Status = Convert.ToBoolean(dr["Status"]),
                        User_count = Convert.ToInt32(dr["user_count"]),
                        kaizen_count= Convert.ToInt32(dr["kaizen_count"]),
                        KaizenSubmitedCountdept = Convert.ToInt32(dr["KaizenSubmittedUserdept"])

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
        public List<DomainModel>GetDomain(DomainModel model)
        {
            List<DomainModel> list = new List<DomainModel>();
            DataSet ds = new DataSet();
            ds = _repositoryDepartmentdata.GetDomainData(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new DomainModel
                    {
                        Id = Convert.ToInt32(dr["DomainID"]),
                        DomainName = dr["DomainName"].ToString()
                    });
                }
            }
            return list;
        }
        public bool UpdateDepartmentDetails(DepartmentModel departmentmodel)
        {
            return _repositoryDepartmentdata.UpdateDepartmentDetails(departmentmodel);
        }
    }
}
