using Kaizen.Models.Theme;
using System.Data;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IThemeRepository
    {
        public bool  AddTheme(ThemeModel model);
        public DataSet RetrieveTheme();

        DataSet GetActiveTheme(DateTime currentDate);

        public bool DeleteTheme(int id, bool forceDelete = false);
    }
}
