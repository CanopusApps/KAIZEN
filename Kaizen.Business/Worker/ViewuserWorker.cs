using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Data;
using Kaizen.Models.ViewUserModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public  class ViewuserWorker : IViewuser
    {
        public readonly IViewuserData _repositoryUserTypedata;      
             public ViewuserWorker(IViewuserData repositoryBlockdata)
              {
                this._repositoryUserTypedata = repositoryBlockdata;
              }

        public DataSet GetUserType(UserTypeModel model)
        {
            DataSet ds = new DataSet();
            ds = _repositoryUserTypedata.GetUserType(model);
            return ds;
        }
        public DataSet GetDomain(DomainModel model)
        {
            DataSet ds = new DataSet();
            ds = _repositoryUserTypedata.GetDomain(model);
            return ds;
        }
    }
}
