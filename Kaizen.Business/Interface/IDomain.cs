using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IDomain
    {
        public bool CreateDomain(string DomainName);

        public List<DomainModel> GetDomain();

        public bool DeleteDomain(int id);

        public bool UpdateDomainStatus( bool status, int id);


    }
}
