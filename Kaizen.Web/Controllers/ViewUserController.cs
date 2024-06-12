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

namespace Kaizen.Web.Controllers
{
    public class ViewUserController : Controller
    {
        private readonly IViewuser _user;
        private readonly IWebHostEnvironment _environment;

        public ViewUserController(IViewuser worker)
        {
            _user = worker;
        }

        //Created by Manas 
        public IActionResult ViewUser()
        {
            ViewUserModel viewModel = new ViewUserModel();
            try
            {
                viewModel.UserTypeList = UserTypeList();
                viewModel.DomainList = DomainList();
            }
            catch (Exception ex) {
                //LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); 
            }

            return View(viewModel);
        }
        public List<UserTypeModel> UserTypeList()
        {
            List<UserTypeModel> list = new List<UserTypeModel>();
            UserTypeModel model = new UserTypeModel();
            DataTable dt = new DataTable();
            model.flag = "get";
            DataSet ds = _user.GetUserType(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new UserTypeModel
                    {
                        UserTypeId = dr["UserTypeId"].ToString(),
                        UserDesc = dr["UserDesc"].ToString()
                    });
                }
            }
            return list;
        }
        public List<DomainModel> DomainList()
        {
            List<DomainModel> list = new List<DomainModel>();
            DomainModel model = new DomainModel();
            DataTable dt = new DataTable();
            model.flag = "get";
            DataSet ds = _user.GetDomain(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new DomainModel
                    {
                        DomainID = dr["DomainID"].ToString(),
                        DomainDesc = dr["DomainDesc"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
