using Kaizen.Models.Theme;

namespace Kaizen.Business.Interface
{
    public interface IThemeChanger
    {
        public bool AddTheme(ThemeModel model);
        List<ThemeModel> RetrieveTheme();

        ThemeModel GetActiveTheme(DateTime currentDate);

        public bool DeleteTheme(int id,bool forceDelete = false);

    }
}
