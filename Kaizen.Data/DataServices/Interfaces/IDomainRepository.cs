﻿using Kaizen.Models.AdminModel;
using System.Data;

namespace Kaizen.Data.DataServices
{
    public interface IDomainRepository
    {
        public bool InsertDomain(DomainModel domainmodel);
        public DataSet GetDomaindetails();
        public bool DeleteDomain(int id);
        //public string DropDomainData(DomainModel model, int id);
        public bool UpdateDomainStatus(int id, bool status);
        public bool UpdateDomainDetails(DomainModel domainmodel);
    }
}
