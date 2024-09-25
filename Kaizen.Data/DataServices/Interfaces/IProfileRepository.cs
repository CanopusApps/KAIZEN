using Kaizen.Models.AdminModel;
using System.Data;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IProfileRepository
    {
        public DataTable UserProfileData(ProfileModel profileModel);
        public bool UpdateUserProfileData(ProfileModel profileModel);
    }
}
