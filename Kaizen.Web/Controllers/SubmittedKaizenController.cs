using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml.Linq;
using Kaizen.Web;
using System.Reflection.Metadata;
using Kaizen.Models.ViewUserModel;
using Kaizen.Models.AdminModel;
using Kaizen.Business.Worker;
using static System.Reflection.Metadata.BlobBuilder;

namespace Kaizen.Web.Controllers
{
    public class SubmittedKaizenController : Controller
    {
        private readonly IDomain _domainWorker;
        private readonly IDepartment   _departmentWorker;
		private readonly IWebHostEnvironment _environment;
        public SubmittedKaizenController(IDomain domainWorker,IDepartment departmentWorker)
        {
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
        }

        public IActionResult ViewKaizen()
        {
            return View();
        }
    }
}
