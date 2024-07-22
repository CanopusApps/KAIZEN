using DocumentFormat.OpenXml.EMMA;
using Kaizen.Models.WinnersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IWinnersList
    {   
        public bool AddWinner(WinnersListModel model);
        public bool DeleteWinner(int id, String sd, String ed);
        public bool UpdateWinner(WinnersListModel model);

        public string ToggleStatus(WinnersListModel model);
        List<WinnersListModel> GetWinners();
    }
}
