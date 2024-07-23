using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IProfileRepository
    {
        public DataTable UserProfileData(ProfileModel profileModel);
        public bool UpdateUserProfileData(ProfileModel profileModel);
    }
}
