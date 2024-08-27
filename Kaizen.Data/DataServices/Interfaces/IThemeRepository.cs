  using System;
using System.Collections.Generic;
using Kaizen.Models.Theme;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IThemeRepository
    {
        public bool  AddTheme(ThemeModel model);
        public DataSet RetrieveTheme();
    }
}
