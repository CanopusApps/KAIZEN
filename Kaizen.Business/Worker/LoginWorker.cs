﻿using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
   
    public class LoginWorker : ILogin
    {
        public readonly ILoginRepository _logindata;

        public LoginWorker(ILoginRepository _logindata)
        {
            this._logindata = _logindata;
        }
        public DataTable Loginuser(LoginModel loginmodel)

        {
           DataTable dataTable = new DataTable();
            dataTable= _logindata.loginuser(loginmodel);
            return dataTable;

          
        }

        public List<ManagerModel> Usermanager(string empid)
        {
            DataSet ds;
            ds= _logindata.usermanager(empid);
            List<ManagerModel> ManagerList = new List<ManagerModel>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ManagerList.Add(new ManagerModel
                    {
                        MgrId = Convert.ToInt32(dr["Mgrid"]),
                        ManagerName = dr["ManagerName"].ToString(),
                        ManagerEmail = dr["ManagerEmail"].ToString()
                    });
                }
            }
            
            return ManagerList;
        }
    }
}
