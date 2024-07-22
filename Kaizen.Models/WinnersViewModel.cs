using Kaizen.Models.NewKaizen;
using Kaizen.Models.WinnersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models
{
    public class WinnersViewModel
    {
        public NewKaizenModel NewKaizen { get; set; }
        public WinnersListModel WinnersList { get; set; }
    }

}
