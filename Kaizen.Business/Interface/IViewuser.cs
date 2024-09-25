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
        public string Senddatatable(DataTable datatable, string Status, string UserType, string Password);
        public List<UserGridModel> GetIEDepart();
        public List<UserGridModel> GetFinance();
        public string ValidateEmployee(UploadUserModel employee);
        List<UserGridModel> GetUsersByDomainId(int  domainId);
        List<UserGridModel> GetUsersByDeptId(int domainId, int departmentId);
        List<UserGridModel> GetUsersByBlockId(int blockId);
        public List<UserGridModel> GetManagers(UserGridModel model);
    }
}
