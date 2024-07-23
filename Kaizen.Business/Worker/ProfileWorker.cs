using Kaizen.Business.Interface;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;

namespace Kaizen.Business.Worker
{
    public class ProfileWorker : IProfile
    {
        public readonly IProfileRepository _profileRepository;
        ProfileModel model = new ProfileModel();
        public ProfileWorker(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public ProfileModel UserProfile(string employeeid)
        {
            model.EmpID = employeeid;
            DataTable dt = _profileRepository.UserProfileData(model);
            foreach (DataRow row in dt.Rows)
            {
                model.EmpID = Convert.ToString($"{row["EmpID"]}");
                model.FirstName = Convert.ToString($"{row["FirstName"]}");
                model.MiddleName = string.IsNullOrEmpty($"{row["MiddleName"]}") ? string.Empty : Convert.ToString($"{row["MiddleName"]}");
                model.LastName = Convert.ToString($"{row["LastName"]}");
                model.Gender = Convert.ToString($"{row["Gender"]}");
                model.Domain = Convert.ToString($"{row["Domain"]}");
                model.Department = Convert.ToString($"{row["Department"]}");
                model.Email = Convert.ToString($"{row["Email"]}");
            }
            return model;
        }
        public bool UpdateUserProfile(ProfileModel model)
        {
            return _profileRepository.UpdateUserProfileData(model);
        }
    }
}
