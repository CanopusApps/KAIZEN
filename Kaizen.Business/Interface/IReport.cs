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

        public byte[] ExportDataTableToExcel(DataTable dataTable);
        
    }
}
