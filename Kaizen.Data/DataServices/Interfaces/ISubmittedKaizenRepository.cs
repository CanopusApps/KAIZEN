﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;

namespace Kaizen.Data.DataServices
{
    public interface ISubmittedKaizenRepository
    {
        public DataSet GetApprovalStatus();
        public DataSet GetKaizenList();
    }
}
