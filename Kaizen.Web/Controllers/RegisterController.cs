using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;
using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Kaizen.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Collections.Generic;

public class RegisterController : Controller
{
    public IHttpContextAccessor conAccessor;
    private readonly IRegister _registerworker;
    private readonly IDepartment _departmentWorker;
    private readonly IDomain _domainWorker;


    public RegisterController(IRegister _registerworker, IHttpContextAccessor conAccessor, IDomain _domainWorker, IDepartment _departmentWorker)
    {
        this._registerworker = _registerworker;
        this._departmentWorker = _departmentWorker;
        this._domainWorker = _domainWorker;
        this.conAccessor = conAccessor;

    }


   [HttpGet]
    // GET: Register/Index
    public IActionResult Index()
    {
        var activeDomains = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();


        var viewModel = new RegisterModel
        {
            Domains = activeDomains // Initialize Domains property with fetched data
        };

        return View(viewModel);
    }


    [HttpPost]
public JsonResult RegisterUser(RegisterModel user)
{
    try
    {
        // Remove unnecessary model state entries
        ModelState.Remove(nameof(user.Domains));
        ModelState.Remove(nameof(user.Departments));

        if (ModelState.IsValid)
        {
            if (user.Did == 0 || user.DeptId == 0)
            {
                return Json(new { success = false, message = "Domain and Department must be selected." });
            }

            // Call the Registeruser method and get the result message
            string resultMessage = _registerworker.Registeruser(user);

            if (resultMessage == "Success")
            {
                return Json(new { success = true, message = resultMessage });
            }
            else
            {
                return Json(new { success = false, message = resultMessage });
            }
        }
        else
        {
            // Collect and return validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            return Json(new { success = false, message = "Invalid data provided.", errors });
        }
    }
    catch (Exception ex)
    {
        LogEvents.LogToFile(DbFiles.Title, ex.ToString());
        return Json(new { success = false, message = "An error occurred: " + ex.Message });
    }
}

    [HttpGet]
    public JsonResult FetchDepartment(string DomainID)
    {
        var departments = _departmentWorker.GetDepartments()
                                           .Where(m => m.DomainId == Convert.ToInt32(DomainID) && m.Status == true)
                                           .ToList();
        return Json(departments);
    }

}