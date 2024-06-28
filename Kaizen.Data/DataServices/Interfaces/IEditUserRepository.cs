using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IEditUserRepository
    {
        public string EditUserData(EditUserModel editUserModel);

        public DataSet GetCadreList();

        public DataSet GetStatusList();
    }
}
