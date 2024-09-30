using Kaizen.Models.WinnersList;
using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using System.Data;
using System.Globalization;

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
        public bool DeleteWinner(int id)
        {
            return _winnersListRepository.DeleteWinner(id);
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

                    string[] formats = { "MM/dd/yyyy", "MMM/dd/yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "MM-dd-yyyy", "dd-MM-yyyy", "dd MMM yyyy" };

                    DateTime parsedStartDate = ParseDate(dr["StartDate"].ToString(), formats);
                    DateTime parsedEndDate = ParseDate(dr["EndDate"].ToString(), formats);

                    winnModels.Add(new WinnersListModel
                    {
                        Id = Guid.Parse(dr["ID"].ToString()),
                        EmpID = Convert.ToInt32(dr["UserID"]),
                        EmpName = dr["WinnerName"].ToString(),
                        Category = dr["Category"].ToString(),
                        DomainName = dr["DomainName"].ToString(),
                        DepartmentName = dr["DepartmentName"].ToString(),
                        StartDate = parsedStartDate,
                        EndDate = parsedEndDate,
                        Status = dr["Status"].ToString(),
                        Winnerimgfilename = base64String,
                        winnerimagefilepath = filePath
                    });
                }
            }
            return winnModels;
        }

        private DateTime ParseDate(string dateString, string[] formats)
        {
            DateTime parsedDate;

            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }

            if (DateTime.TryParse(dateString, out parsedDate))
            {
                return parsedDate;
            }

            return DateTime.MinValue;
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
