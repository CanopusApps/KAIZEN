using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class CreateNewKaizenWorker : ICreateNewKaizen
    {
        public readonly ICreateNewKaizenRepository _createNewKaizenRepository;


        public CreateNewKaizenWorker(ICreateNewKaizenRepository repositoryDomaindata)

        {

            this._createNewKaizenRepository = repositoryDomaindata;

        }
        public NewKaizenModel GetKaizenOriginatedby(NewKaizenModel model)
        {
          DataTable  dt = _createNewKaizenRepository.GetKaizenOriginatedbyData(model);
            foreach (DataRow row in dt.Rows)
            {
                model.EmpId = string.IsNullOrEmpty($"{row["EmpID"]}") ? string.Empty : Convert.ToString($"{row["EmpID"]}");
                model.name = string.IsNullOrEmpty($"{row["UserName"]}") ? string.Empty : Convert.ToString($"{row["UserName"]}");
                model.Domain = string.IsNullOrEmpty($"{row["DomainName"]}") ? string.Empty : Convert.ToString($"{row["DomainName"]}");
                model.Department = string.IsNullOrEmpty($"{row["DepartmentName"]}") ? string.Empty : Convert.ToString($"{row["DepartmentName"]}");
                model.OriginatedDate = string.IsNullOrEmpty($"{row["CurrentDate"]}") ? string.Empty : Convert.ToString($"{row["CurrentDate"]}");
            }
            return model;
        }

        public bool CreateNewKaizen(NewKaizenModel model)
        {
            return _createNewKaizenRepository.CreateNewKaizenData(model);
        }

    }
}
