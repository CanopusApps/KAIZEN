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

        public ProfileWorker(IProfileRepository _profileRepository)
        {
            this._profileRepository = _profileRepository;
        }


        //public DataTable UserProfile(ProfileModel profileModel)
        //{
        //   DataTable dataTable = new DataTable();
        //    return dataTable;
        //}

        public ProfileModel UserProfile(string employeeid)
        {
            model.EmpID = employeeid;
            

            DataTable dt = _profileRepository.UserProfileData(model);

            foreach (DataRow row in dt.Rows)
            {
                model.FirstName = string.IsNullOrEmpty($"row{"FirstName"}") ? string.Empty : Convert.ToString($"row{"FirstName"}");
                model.MiddleName = string.IsNullOrEmpty($"row{"MidlleName"}") ? string.Empty : Convert.ToString($"row{"MiddleName"}");
                model.LastName = string.IsNullOrEmpty($"row {"LastName"}") ? string.Empty : Convert.ToString($"row {"LastName"}");
                model.Gender = string.IsNullOrEmpty($"row {"Gender"}") ? string.Empty : Convert.ToString($"row {"Gender"}");
                //model.EmpID = string.IsNullOrEmpty($"row {"EmpID"}") ? string.Empty : Convert.ToString($"row {"EmpID"}");
                model.Domain = string.IsNullOrEmpty($"row {"Domain"}") ? string.Empty : Convert.ToString($"row {"Domain"}");
                model.Department = string.IsNullOrEmpty($"row {"Department"}") ? string.Empty : Convert.ToString($"row {"Department"}");
                model.Email = string.IsNullOrEmpty($"row{"Email"}") ? string.Empty : Convert.ToString($"row {"Email"}");
            }
            return model;
        }

        
        //public ProfileModel UpdateUserProfile(ProfileModel model)
        //{
        //    return model;
        //}
        
        public bool UpdateUserProfile(ProfileModel model)
        {
            return false;
        }
    }
}
