using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.ViewUserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class DomainWorker : IDomain
    {
        public readonly IDomainData _repositoryDomaindata;

        public DomainWorker(IDomainData repositoryDomaindata)

        {

            this._repositoryDomaindata = repositoryDomaindata;

        }

        public string CreateDomain(string DomainName)

        {

            DataTable dt = new DataTable();

            string message = _repositoryDomaindata.CreateDomainData(DomainName);

            return message;

        }

        public DataSet GetDomain(DomainModel model)

        {

            DataSet ds = new DataSet();

            ds = _repositoryDomaindata.GetDomainData(model);

            return ds;

        }

        public string DeleteDomain(DomainModel model, int id)

        {

            DataTable dt = new DataTable();

            string message = _repositoryDomaindata.DeleteDomainData(model, id);

            return message;

        }

        public string InActiveDomain(DomainModel model, int id)

        {

            DataTable dt = new DataTable();

            string message = _repositoryDomaindata.DropDomainData(model, id);

            return message;

        }

        public string ActiveDomain(DomainModel model, int id)

        {

            DataTable dt = new DataTable();

            string message = _repositoryDomaindata.ActiveDomainData(model, id);

            return message;

        }



    }
}
