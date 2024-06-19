using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Http;

namespace Kaizen.Business.Interface
{
    public interface IViewuser
    {
        public List<UserGridModel> GetUser(UserGridModel model);
        public bool DeleteUser(int id);
        public List<StatusModel> GetStatus();

        public string SendFile(IFormFile file, string Status, string UserType, string Password);
        public void Senddatatable(DataTable datatable, string Status, string UserType, string Password);
    }
}
