using Kaizen.Models.WinnersList;
using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Business.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using DocumentFormat.OpenXml.EMMA;

namespace Kaizen.Business.Worker
{
    public class WinnersListWorker : IWinnersList
    {
      
        public readonly IWinnersListRepository _winnersListRepository;
        public WinnersListWorker(IWinnersListRepository winnersListRepository)
        {
            _winnersListRepository = winnersListRepository;
        }
        public bool AddWinner(WinnersListModel model)
        {
            return _winnersListRepository.AddWinner(model);
        } 
        
        public bool DeleteWinner(int id, String sd, String ed)
        {
            return _winnersListRepository.DeleteWinner(id, sd, ed);
        }
        public bool UpdateWinner(WinnersListModel model)
        {
            return _winnersListRepository.UpdateWinner(model);
        }

        public string ToggleStatus(WinnersListModel model)
        {
            return _winnersListRepository.ToggleStatus(model);
        }
  
        public List<WinnersListModel> GetWinners()
        {
            DataSet ds;
            List<WinnersListModel> winnModels = new List<WinnersListModel>();
            ds = _winnersListRepository.GetWinners();
             
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string filePath = dr["FileName"].ToString();
                    string base64String = ConvertFileToBase64(filePath);
                    winnModels.Add(new WinnersListModel
                    {
                        Id= Guid.Parse(dr["ID"].ToString()),
                        EmpID= Convert.ToInt32(dr["UserID"]),
                        EmpName= dr["WinnerName"].ToString(),
                        Category= dr["Category"].ToString(),
                        DomainName= dr["DomainName"].ToString(),
                        DepartmentName = dr["DepartmentName"].ToString(),
                        StartDate= Convert.ToDateTime(dr["StartDate"]),
                        EndDate = Convert.ToDateTime(dr["EndDate"]),
                        Status = dr["Status"].ToString(),
                        Winnerimgfilename= base64String,
                        winnerimagefilepath= filePath


                    });
                }
            }
            return winnModels;
        }

        private string ConvertFileToBase64(string filePath)
        {
            if (File.Exists(filePath))
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                return Convert.ToBase64String(fileBytes);
            }
            return null;
        }


    }

   


}
