using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IDepartment
    {
        public bool InsertDepartment(int domainId,string DomainName, string DepartmentName);

        public List<DepartmentModel> GetDepartments();

        public bool DeleteDepartment(int id);

        public bool UpdateDepartmentStatus( bool status, int id);


    }
}
