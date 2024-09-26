
using Kaizen.Models.AdminModel;

namespace Kaizen.Models.ViewUserModel
{
    public class ViewUserallModel
    {
        public List<UserTypeModel> UserTypeList { get; set; }
        public List<DomainModel> DomainList { get; set; }
        public List<BlockModel> BlockList { get; set; }
        public List<UserGridModel> UsergridList { get; set; }
        public List<StatusModel> StatusList { get; set; }
    }
}
