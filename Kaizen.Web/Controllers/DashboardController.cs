using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Models.AdminModel;
using Kaizen.Models.DashboardModel;
using Microsoft.AspNetCore.Mvc;

namespace Kaizen.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDomain _domainWorker;
        private readonly IDepartment _departmentWorker;
        private readonly IDashboard _dashboardworker;
        private readonly ISubmittedKaizen _submittedKaizenWorker;
        public DashboardController(IDomain domainWorker, IDepartment departmentWorker, IDashboard dashboardworker, ISubmittedKaizen submittedKaizenWorker)
        {
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
            _dashboardworker = dashboardworker;
            _submittedKaizenWorker = submittedKaizenWorker;
        }
        
        public IActionResult Dashboardtab1()
        {
            DashboardModel DashboardModel = new DashboardModel();
            DashboardModel.DomainList = _domainWorker.GetDomain();
            return View(DashboardModel);
        }
        public IActionResult Dashboardtab2()
        {
            DashboardModel DashboardModel = new DashboardModel();
            DashboardModel.DomainList = _domainWorker.GetDomain();
            return View(DashboardModel);
        }
        public IActionResult ViewFilterKaizen(string? StartDate, string? EndDate, string? Domain, string? Department)
        {
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain = Domain,
                Department = Department
               
            };
            var KaizencountList = _dashboardworker.GetKaizenCount(model);
            var Kaizentotallist= _dashboardworker.GetKaizentotalCount(model);
            model.CountKaizenList = KaizencountList;
            model.TotalKaizenList = Kaizentotallist;
            return Ok(model);
        }
        public IActionResult Dashboardtab3()
        {
            return View();
        }
        public IActionResult Dashboardtab4()
        {
            DashboardModel DashboardModel = new DashboardModel();
            DashboardModel.DomainList = _domainWorker.GetDomain();
            return View(DashboardModel);
        }
        //public List<DepartmentModel> FetchDepartment(string domainid)
        //{
        //    List<DepartmentModel> deptList = new List<DepartmentModel>();
        //    if (!string.IsNullOrEmpty(domainid))
        //    {
        //        deptList = _departmentWorker.GetDepartments().Where(d => d.DomainId == Convert.ToInt32(domainid)).ToList();

        //    }
        //    return deptList;
        //}


    }
}
