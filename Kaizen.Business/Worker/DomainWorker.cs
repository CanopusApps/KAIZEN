using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
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
        public readonly IDomainRepository _repositoryDomaindata;

        public DomainWorker(IDomainRepository repositoryDomaindata)

        {

            this._repositoryDomaindata = repositoryDomaindata;

        }

        public bool CreateDomain(string DomainName, string CreatedBy)
        {           
              return _repositoryDomaindata.InsertDomain(DomainName, CreatedBy);
        }

        public List<DomainModel> GetDomain()
        {
            DataSet ds;
            List<DomainModel> domainModels = new List<DomainModel>();
            ds = _repositoryDomaindata.GetDomaindetails();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    domainModels.Add(new DomainModel
                    {
                        Id = Convert.ToInt32(dr["DomainId"]),
                        DomainName = dr["DomainName"].ToString(),
                        Status = Convert.ToBoolean(dr["Status"])
                    });
                }
            }
            return domainModels;

        }

        public bool DeleteDomain(int id)
        {
            return _repositoryDomaindata.DeleteDomain(id);

        }

        public bool UpdateDomainStatus(bool status, int id)
        {
            return _repositoryDomaindata.UpdateDomainStatus(id,status);

        }
        public bool UpdateDomainDetails(string domainName, int id, string ModifiedBy)
        {

            return _repositoryDomaindata.UpdateDomainDetails( domainName, id, ModifiedBy);

        }
    }
}
