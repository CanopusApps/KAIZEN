﻿using Kaizen.Models.NewKaizen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface ICreateNewKaizenRepository
    {
      public DataTable GetKaizenOriginatedbyData(NewKaizenModel model);
    }
}
