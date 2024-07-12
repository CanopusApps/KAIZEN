﻿using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{   
    public interface IProfile
    { 
        //public ProfileModel UserProfile(ProfileModel profileModel);
        public ProfileModel UserProfile(string empID);

        //public ProfileModel UpdateUserProfile(ProfileModel profileModel);
        public bool UpdateUserProfile(ProfileModel profileModel);
    }
}
