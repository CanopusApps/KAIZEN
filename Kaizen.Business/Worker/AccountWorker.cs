
using System.Data;
using Kaizen.Web.Models;
using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;


namespace Kaizen.Business.Worker
{
    public  class AccountWorker : IAccount
    {
        public readonly IAccountData  _repositoryAccountDAL;

        public AccountWorker(IAccountData repositoryAccountdal)
        {
            this._repositoryAccountDAL = repositoryAccountdal;
        }
        public DataTable LoginCheck(Login entitylog)
        {
            DataTable dt = new DataTable();
            dt = _repositoryAccountDAL.LoginCheckDAL(entitylog);

            return dt;
        }
    }
}
