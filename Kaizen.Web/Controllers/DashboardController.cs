using Kaizen.Business.Interface;
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
        public DashboardController(IDomain domainWorker, IDepartment departmentWorker, IDashboard dashboardworker)
        {
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
            _dashboardworker = dashboardworker;
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
        public IActionResult Dashboardtab3()
        {
            return View();
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
