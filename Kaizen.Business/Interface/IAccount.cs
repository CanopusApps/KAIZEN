using Kaizen.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Business.Interface;

namespace Kaizen.Business.Interface
{
    public interface IAccount
    {
       DataTable LoginCheck(Login ad);
    }
}
