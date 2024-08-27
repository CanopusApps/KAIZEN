using Kaizen.Models.AdminModel;
using Kaizen.Models.ViewUserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IDepartmentRepository
	{
        public bool CreateDepartmentData(DepartmentModel departmentModel);
        public DataSet GetDepartments();
        public bool DeleteDepartment(int id);
        public DataSet GetDomainData();
        public bool UpdateDepartmentStatus(int id, bool status);

        public bool UpdateDepartmentDetails(DepartmentModel departmentmodel);
    }
}
