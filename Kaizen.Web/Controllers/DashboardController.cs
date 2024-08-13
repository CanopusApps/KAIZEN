using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.EMMA;
using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Kaizen.Models.DashboardModel;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;

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
        public IHttpContextAccessor conAccessor;
        public DashboardController(IDomain domainWorker, IDepartment departmentWorker, IDashboard dashboardworker, ISubmittedKaizen submittedKaizenWorker, IBlock worker, IAddUser addUserWorker, IHttpContextAccessor conAccessor)
        {
            this.conAccessor = conAccessor;
            _blockWorker = worker;
            _addUserWorker = addUserWorker;
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
            _dashboardworker = dashboardworker;
            _submittedKaizenWorker = submittedKaizenWorker;
        }
        
        public IActionResult Dashboardtab1()

        {
            return View();
        }
        public IActionResult Dashboardtab2()
        {
            DashboardModel DashboardModel = new DashboardModel();
            try
            {
                var activeBlocks = _blockWorker.GetBlock().Where(d => d.Status == true).ToList();

                DashboardModel.DomainList = _domainWorker.GetDomain();
                DashboardModel.blockList = activeBlocks;
                DashboardModel.CadreList = _addUserWorker.GetCadre();
               
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return View(DashboardModel);

        }
        public IActionResult Dashboardtab3()
        {
            
            return View();
        }
        public IActionResult Dashboardtab5()
        {
            return View();
        }
        public IActionResult Dashboardtab4()
        {
            return View();
        }
        public IActionResult DomainkaizenFilter(string? StartDate, string? EndDate)
        {
            
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
            };
            model.DomainList = _dashboardworker.DomainbasedkaizenCount(model);
            return Ok(model);
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
            try
            {
                var KaizencountList = _dashboardworker.GetKaizenCount(model);
                var Kaizentotallist = _dashboardworker.GetKaizentotalCount(model);
                model.MonthCountKaizenList = _dashboardworker.GetKaizenCountmonth(model);
                model.MonthTotalKaizenList = _dashboardworker.GetKaizentotalCountmonth(model);
                model.CustomMonthTotalKaizenList = _dashboardworker.GetKaizentotalCountCustomMonth(model);
                model.CountKaizenList = KaizencountList;
                model.TotalKaizenList = Kaizentotallist;
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
           
            return Ok(model);
        }

        public IActionResult Filtergraphscount(string? StartDate, string? EndDate)
        {

            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
            };
            try
            {
                model.MonthTotalKaizenList = _dashboardworker.GetKaizentotalCountmonth(model);
                model.blockbasedgraph = _dashboardworker.kaizenCountbasedonBlocks(model);
                model.Cadrebasedgraph = _dashboardworker.kaizenCountbasedonCadre(model);
                model.departmentbasedgraph = _dashboardworker.kaizenCountbasedonDepartment(model);
                model.domainbasedgraph = _dashboardworker.kaizenCountbasedonDomain(model);
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
           
            return Ok(model);
        }

        public List<DepartmentModel> FetchDepartment(string? StartDate, string? EndDate, string domainid)
        {
            List<DepartmentModel> deptList = new List<DepartmentModel>();
           
                DashboardModel model = new DashboardModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Domain = domainid,
                };
            try
            {
                deptList = _dashboardworker.DepartmentbasedkaizenCount(model).Where(model => model.DomainId == Convert.ToInt32(domainid)).ToList();
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
               


            
            return deptList;
        }
        public IActionResult EmployeeDashboard()
        {
           


            return View();
        }
        public IActionResult Dashboardothers()
        {
            string Empid = conAccessor.HttpContext.Session.GetString("EmpId");
            DashboardModel DashboardModel = new DashboardModel();

            try
            {
                DashboardModel.DomainList = _domainWorker.GetDomain();
                DashboardModel.blockList = _blockWorker.GetBlock();
                DashboardModel.DomainmanagerList = _dashboardworker.ManagerDomainbasedkaizenCount(DashboardModel, Empid);
                DashboardModel.departmentmangerlist = _dashboardworker.managerDepartmentbasedkaizenCount(DashboardModel, Empid);
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
           


            return View(DashboardModel);
        }
        public IActionResult FilterOtherDashboardcount(string? StartDate, string? EndDate, string? Domain, string? Department, string? Block)
        {
            string Empid = conAccessor.HttpContext.Session.GetString("EmpId");
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain = Domain,
                Department = Department,
                Block = Block
            };
            try
            {
                model.DomainmanagerList = _dashboardworker.ManagerDomainbasedkaizenCount(model, Empid);
                model.departmentmangerlist = _dashboardworker.managerDepartmentbasedkaizenCount(model, Empid);
                model.OtherdashboardList = _dashboardworker.Otherdashboard(model);
                model.MonthBasedOtherdashboardList = _dashboardworker.OtherMonthbaseddashboard(model);
            }
            catch (Exception ex)
            {


                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
         
            return Ok(model);
        }
        public IActionResult FilterEmployeeDashboardcount(string? StartDate, string? EndDate)
        {

            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
              
            };
            try
            {
                model.EmployeedashboardList = _dashboardworker.GetEmployeedashboardcount(model);
                model.MonthBasedEmployeedashboardList = _dashboardworker.GetmonthbasedEmployeedashboardcount(model);
            }
            catch (Exception ex)
            {


                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
           
            return Ok(model);
        }


    }
}
