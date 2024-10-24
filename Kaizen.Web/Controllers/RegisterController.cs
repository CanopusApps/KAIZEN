﻿using DocumentFormat.OpenXml.Bibliography;
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
    private List<DomainModel> domains;
    private readonly IRegister _registerworker;
    private readonly IDepartment _departmentWorker;
    private readonly IDomain _domainWorker;
    private readonly IBlock _blockWorker;
    private readonly IAddUser _addUserWorker;


    public RegisterController(IBlock worker,IRegister _registerworker, IHttpContextAccessor conAccessor, IDomain _domainWorker, IDepartment _departmentWorker, IAddUser addUserWorker)
    {
        _blockWorker = worker;
        this._registerworker = _registerworker;
        this._departmentWorker = _departmentWorker;
        this._domainWorker = _domainWorker;
        this.conAccessor = conAccessor;
        _addUserWorker = addUserWorker;
    }


    // GET: Register/Index
    public IActionResult Index()
    {
        RegisterModel viewModel = new RegisterModel();
        try
        {
            var activeDomains = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
            var activeBlocks = _blockWorker.GetBlock().Where(d => d.Status == true).ToList();
            viewModel.Domains = activeDomains;// Initialize Domains property with fetched data
               viewModel.Blocks = activeBlocks;
            viewModel.Cadre = _addUserWorker.GetCadre();
        }
        catch (Exception ex)
        {
            LogEvents.LogToFile(DbFiles.Title, ex.ToString());
        }
        return View(viewModel);

    }



    /// <summary>
    /// Registers a new user by validating the provided data and calling the Registeruser method.
    /// Returns a JSON response indicating success or failure with relevant messages.
    /// </summary>
    /// <param name="user">The user data for registration.</param>
    /// <returns>JSON response with success or error message.</returns>

    [HttpPost]
    public JsonResult RegisterUser(RegisterModel user)
{
    try
    {
        // Remove unnecessary model state entries
        ModelState.Remove(nameof(user.Domains));
        ModelState.Remove(nameof(user.Departments));
            ModelState.Remove(nameof(user.Blocks));
            ModelState.Remove(nameof(user.Cadre));
            ModelState.Remove("MiddleName");            

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

    /// <summary>
    /// Fetches departments based on the provided DomainID and returns them as a JSON response.
    /// </summary>
    /// <param name="DomainID">The ID of the domain to filter departments by.</param>
    /// <returns>JSON response with the list of departments or an error message if an exception occurs.</returns>
   
    [HttpGet]
    public JsonResult FetchDepartment(string DomainID)
    {
        try
        {
            var departments = _departmentWorker.GetDepartments()
                                               .Where(m => m.DomainId == Convert.ToInt32(DomainID) && m.Status == true)
                                               .ToList();
            return Json(departments);
        }
        catch (Exception ex)
        {
            LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            return Json(new { success = false, message = "An error occurred while fetching departments. Please try again later." });
        }
    }

}