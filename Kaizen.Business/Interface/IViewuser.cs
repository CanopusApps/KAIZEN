using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Kaizen.Models.AdminModel;

namespace Kaizen.Business.Interface
{
    public interface IViewuser
    {
        public List<UserGridModel> GetUser(UserGridModel model);
        public bool DeleteUser(int id);
        public List<StatusModel> GetStatus();
        public void SaveUploadedFile(UploadUserModel Employee);


    }
}
