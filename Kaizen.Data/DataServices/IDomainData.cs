using Kaizen.Models.ViewUserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IDomainData
    {
        public string CreateDomainData(string DomainName);

        public DataSet GetDomainData(DomainModel model);

        public string DeleteDomainData(DomainModel model, int id);

        public string DropDomainData(DomainModel model, int id);

        public string ActiveDomainData(DomainModel model, int id);

    }
}
