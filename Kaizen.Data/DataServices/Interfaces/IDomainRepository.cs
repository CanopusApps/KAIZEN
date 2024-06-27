using Kaizen.Models.ViewUserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IDomainRepository
    {
        public bool InsertDomain(string domainName, string CreatedBy);

        public DataSet GetDomaindetails();

        public bool DeleteDomain(int id);

        //public string DropDomainData(DomainModel model, int id);

        public bool UpdateDomainStatus(int id, bool status);

        public bool UpdateDomainDetails(string domainName, int id, string ModifiedBy);

    }
}
