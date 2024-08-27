using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class LoginWinnerListModel
    {
        public List<LoginImageModel> CompletewinnerList { get; set; }
        public List<LoginImageModel> GoldList { get; set; }
        public List<LoginImageModel> SilverList { get; set; }
        public List<LoginImageModel> BronzeList { get; set; }
    }
}
