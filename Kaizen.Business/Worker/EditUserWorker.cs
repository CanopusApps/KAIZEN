using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class EditUserWorker : IEditUser
    {
        public readonly IEditUserRepository editUserData;

        public EditUserWorker(IEditUserRepository editUserData)
        {
            this.editUserData = editUserData;
        }
        public string EditUser(EditUserModel editUserModel)
        {
            string msg = editUserData.EditUserData(editUserModel);
            return msg;
        }

        public List<CadreModel> GetCadre()
        {
            DataSet ds;
            ds = editUserData.GetCadreList();
            List<CadreModel> cadre = new List<CadreModel>();
            if(ds.Tables.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows) 
                {
                    cadre.Add(new CadreModel
                    {
                        Id = Convert.ToInt32(dr["CadreId"]),
                        CadreName = dr["CadreDesc"].ToString() //colname taken from db
                    }); 
                }
            }
            return cadre;
        }

        public List<StatusModel> GetStatus()
        {
            DataSet ds;
            ds = editUserData.GetStatusList();
            List<StatusModel> status = new List<StatusModel>();
            if (ds.Tables.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    status.Add(new StatusModel
                    {
                        StatusID = Convert.ToInt32(dr["StatusID"]),
                        StatusName = dr["StatusName"].ToString()
                    }) ;
                }
            }
            return status;           
        }
    }

}
