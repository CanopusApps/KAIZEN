using Kaizen.Models.ReportModel;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Kaizen.Business.Interface
{
    public interface IReport
    {
        public DataTable GetKaizenform(KaizenReportModel model);

        public DataTable GetBlockReport(KaizenReportModel model);

        public DataTable GetDomainReport(KaizenReportModel model);

        public DataTable GetDepartmentReport(KaizenReportModel model);

        public DataTable GetUsersReport(KaizenReportModel model);

        public byte[] ExportDataTableToExcel(DataTable dataTable);
        public byte[] ExportListToExcelDashboard<T>(List<T> list);
        public int GetCount(object data);
    }
}
