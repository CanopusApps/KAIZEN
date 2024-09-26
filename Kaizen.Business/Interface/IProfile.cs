using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{   
    public interface IProfile
    { 
        public ProfileModel UserProfile(string empID);
        public bool UpdateUserProfile(ProfileModel profileModel);
    }
}
