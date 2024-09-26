using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.Theme;
using System.Data;

namespace Kaizen.Business.Worker    
{
    public class ThemeWorker : IThemeChanger
    {
        public readonly IThemeRepository _themeRepository;
        public ThemeWorker(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }
        public bool AddTheme(ThemeModel model)
        {
            return _themeRepository.AddTheme(model);
        }
        public List<ThemeModel> RetrieveTheme()
        {
            DataSet ds;
            List<ThemeModel> RetrieveTheme = new List<ThemeModel>();
            ds = _themeRepository.RetrieveTheme();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    RetrieveTheme.Add(new ThemeModel   
                    {
                        ModifiedBy = dr["ModifiedBy"].ToString(),
                        Theme = dr["Theme"].ToString()

                    });
                }
            }
            return RetrieveTheme;
        }
    }
}
