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
                        ThemeId = Convert.ToInt32(dr["ThemeId"]),  // Assuming ThemeId is an integer
                        Theme = dr["Theme"].ToString(),
                        StartDate = dr["StartDate"] != DBNull.Value ? (DateTime?)dr["StartDate"] : null,
                        EndDate = dr["EndDate"] != DBNull.Value ? (DateTime?)dr["EndDate"] : null

                    });
                }
            }
            return RetrieveTheme;
        }

        public ThemeModel GetActiveTheme(DateTime currentDate)
        {
            DataSet ds;
            ThemeModel activeTheme = null;

            ds = _themeRepository.GetActiveTheme(currentDate);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];  

                activeTheme = new ThemeModel
                {
                    ThemeId = Convert.ToInt32(dr["ThemeId"]), 
                    Theme = dr["Theme"].ToString(),
                    StartDate = dr["StartDate"] != DBNull.Value ? (DateTime?)dr["StartDate"] : null,
                    EndDate = dr["EndDate"] != DBNull.Value ? (DateTime?)dr["EndDate"] : null
                };
            }

            return activeTheme;
        }

        public bool DeleteTheme(int id, bool forceDelete = false) 
        {
            return _themeRepository.DeleteTheme(id, forceDelete); 
        }
    }
}
