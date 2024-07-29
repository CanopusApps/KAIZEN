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
        private readonly IBlock _blockWorker;
        private readonly IAddUser _addUserWorker;
        private readonly IDashboard _dashboardworker;
        private readonly ISubmittedKaizen _submittedKaizenWorker;
        public DashboardController(IDomain domainWorker, IDepartment departmentWorker, IDashboard dashboardworker, ISubmittedKaizen submittedKaizenWorker, IBlock worker, IAddUser addUserWorker)
        {
            _blockWorker = worker;
            _addUserWorker = addUserWorker;
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
            DashboardModel.blockList = _blockWorker.GetBlock();
            DashboardModel.CadreList = _addUserWorker.GetCadre();
            return View(DashboardModel);
        }
        public IActionResult ViewFilterKaizen(string? StartDate, string? EndDate, string? Domain, string? Department, string? Block, string? cadre)
        {
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain = Domain,
                Department = Department,
                Block= Block,
                Cadre= cadre,

            };
            var KaizencountList = _dashboardworker.GetKaizenCount(model);
            var Kaizentotallist= _dashboardworker.GetKaizentotalCount(model);
            model.MonthCountKaizenList=_dashboardworker.GetKaizenCountmonth(model);
            model.MonthTotalKaizenList=_dashboardworker.GetKaizentotalCountmonth(model);
            model.CustomMonthTotalKaizenList= _dashboardworker.GetKaizentotalCountCustomMonth(model);
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
            DashboardModel.blockList = _blockWorker.GetBlock();
            DashboardModel.CadreList = _addUserWorker.GetCadre();
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
