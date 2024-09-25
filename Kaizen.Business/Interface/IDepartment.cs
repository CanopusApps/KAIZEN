using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IDepartment
    {
        public bool CreateDepartment(DepartmentModel departmentModel);
        public List<DepartmentModel> GetDepartments();
        public bool DeleteDepartment(int id);
        public bool UpdateDepartmentStatus(bool status, int id);
        public List<DomainModel> GetDomain();
        public bool UpdateDepartmentDetails(DepartmentModel departmentmodel);
    }
}
