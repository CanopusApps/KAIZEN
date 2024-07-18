using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class ReportWorker : IReport
    {
        private readonly IReportRepository _reportRepository;
       
        public ReportWorker(IReportRepository repositoryReportdata)
        {
            this._reportRepository = repositoryReportdata;
        }

        public DataTable GetKaizenform(KaizenReportModel model)
        {
            return _reportRepository.GetKaizenformData(model);
        }
    }
}
