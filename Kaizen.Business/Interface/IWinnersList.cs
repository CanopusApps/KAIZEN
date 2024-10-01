using Kaizen.Models.WinnersList;

namespace Kaizen.Business.Interface
{
    public interface IWinnersList
    {   
        public bool AddWinner(WinnersListModel model);
        public bool DeleteWinner(int id);
        public bool UpdateWinner(WinnersListModel model);
        public string ToggleStatus(WinnersListModel model);
        List<WinnersListModel> GetWinners();
    }
}
