using Kaizen.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IReportRepository
    {
        public DataTable GetKaizenformData(KaizenReportModel model);
    }
}
