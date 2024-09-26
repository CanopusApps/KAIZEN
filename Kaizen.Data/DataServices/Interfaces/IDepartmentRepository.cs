using Kaizen.Models.AdminModel;
using System.Data;

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
