using Kaizen.Models.WinnersList;
using System.Data;

namespace Kaizen.Data.DataServices
{
    public interface IWinnersListRepository
    {
        public bool AddWinner(WinnersListModel model);
        public bool DeleteWinner(int id);
        public bool UpdateWinner(WinnersListModel model);
        public string ToggleStatus(WinnersListModel model);
        public DataSet GetWinners();
    }
}
