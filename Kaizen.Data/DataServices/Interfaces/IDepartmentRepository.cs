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
        public bool InsertDepartment(string DomainName, int DomainId, string DepartmentName);

        public DataSet GetDepartments();
		//public DataSet GetDepartment(string DomainName);
		public bool DeleteDepartment(int id);

        //public string DropDomainData(DomainModel model, int id);

        public bool UpdateDepartmentStatus(int id, bool status);

      


	}
}
