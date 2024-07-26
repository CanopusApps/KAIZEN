using DocumentFormat.OpenXml.Drawing;
using Kaizen.Models.AdminModel;
using Kaizen.Models.Theme;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IThemeChanger
    {
        public bool AddTheme(ThemeModel model);

        List<ThemeModel> RetrieveTheme();
    }
}
