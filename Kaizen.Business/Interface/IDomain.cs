using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IDomain
    {
        public bool CreateDomain(DomainModel domainmodel);
        public List<DomainModel> GetDomain();
        public bool DeleteDomain(int id);
        public bool UpdateDomainStatus( bool status, int id);
        public bool UpdateDomainDetails(DomainModel domainmodel);
    }
}
