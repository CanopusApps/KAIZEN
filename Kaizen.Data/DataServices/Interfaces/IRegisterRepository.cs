﻿using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IRegisterRepository
    {
        public string Registeruser(RegisterModel registermodel);

        
    }
}
