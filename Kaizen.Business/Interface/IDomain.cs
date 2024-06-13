using Kaizen.Models.ViewUserModel;
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
        public string CreateDomain(string DomainName);

        public DataSet GetDomain(DomainModel model);

        public string DeleteDomain(DomainModel model, int id);

        public string InActiveDomain(DomainModel model, int id);

        public string ActiveDomain(DomainModel model, int id);


    }
}
