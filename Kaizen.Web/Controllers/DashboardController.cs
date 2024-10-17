using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.EMMA;
using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Kaizen.Models.DashboardModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using NPOI.SS.Formula.Functions;

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
        // Admin Dashboard Tab1
        public IActionResult Dashboardtab1()

        {
            return View();
        }
        // Admin Dashboard Tab2
        public IActionResult Dashboardtab2()
        {
            DashboardModel DashboardModel = new DashboardModel();
            try
            {
                var activeBlocks = _blockWorker.GetBlock().Where(d => d.Status == true).ToList();
             

                DashboardModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
                DashboardModel.blockList = activeBlocks;
                DashboardModel.CadreList = _addUserWorker.GetCadre();
               
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return View(DashboardModel);

        }
        // Admin Dashboard Tab3
        public IActionResult Dashboardtab3()
        {
            
            return View();
        }
        // Admin Dashboard Tab5
        public IActionResult Dashboardtab5()
        {
            return View();
        }
        // Admin Dashboard Tab4
        public IActionResult Dashboardtab4()
        {
            return View();
        }

        // filter for in tab1( department)
        public IActionResult DomainkaizenFilter(string? StartDate, string? EndDate)
        {
            try
            {
                DashboardModel model = new DashboardModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                };
                model.DomainList = _dashboardworker.DomainbasedkaizenCount(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        //admin dashboard count filter for tab-2 (yearly and montly table both custom and monthly tables)
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
              
                var Kaizentotallist = _dashboardworker.GetKaizentotalCount(model);               
                model.MonthTotalKaizenList = _dashboardworker.GetKaizentotalCountmonth(model);
                model.CustomMonthTotalKaizenList = _dashboardworker.GetKaizentotalCountCustomMonth(model);                
                model.TotalKaizenList = Kaizentotallist;
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
           
            return Ok(model);
        }

        //admin dashboard count filter for tab-3 (Graphs Submitted Kaizen's,kaizens cummulative chart)
        //admin dashboard count filter for tab-5 (charts based on blocks,cadre,department)
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
                model.domainbasedgraph = _dashboardworker.kaizenCountbasedonDomain(model);
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
           
            return Ok(model);
        }
        // TAB 1 sub department filter based on department(Admin Login)
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
                deptList = _dashboardworker.DepartmentbasedkaizenCount(model).Where(model => model.DomainId == Convert.ToInt32(domainid) && model.Status == true).ToList();
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
               


            
            return deptList;
        }
        // Employee Dashboard login
        [Authorize(Roles = "EMP,MGR,IED,FIN")]
        public IActionResult EmployeeDashboard()
        {
           


            return View();
        }

        // Other Dashboard login(MGR,FIN,IED)
        [Authorize(Roles = "EMP,MGR,IED,FIN")]
        public IActionResult Dashboardothers()
        {
            string Empid = conAccessor.HttpContext.Session.GetString("EmpId");
            DashboardModel DashboardModel = new DashboardModel();

            try
            {
                DashboardModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
                DashboardModel.blockList = _blockWorker.GetBlock().Where(d => d.Status == true).ToList();
                DashboardModel.DomainmanagerList = _dashboardworker.ManagerDomainbasedkaizenCount(DashboardModel, Empid);
                DashboardModel.departmentmangerlist = _dashboardworker.managerDepartmentbasedkaizenCount(DashboardModel, Empid);
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
           


            return View(DashboardModel);
        }
        // Other Dashboard login (MGR,FIN,IED) filtering
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


        //Filter Dashboard for Employee
        [Authorize(Roles = "EMP,MGR,IED,FIN")]
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

        //admin dashboard count filter for tab-5 (charts based sub-department based on Department)
        public IActionResult getdepartmentgraphsbasedonDomain(string? StartDate, string? EndDate,string label,string value)
        {
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain=label,

            };
            try
            {
                model.departmentbasedgraph = _dashboardworker.kaizenCountbasedonDepartment(model);
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(model);
        }

    }
}
