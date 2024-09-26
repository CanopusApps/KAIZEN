using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
using System.Data;


namespace Kaizen.Business.Worker
{
    public class AddUserWorker : IAddUser
    {
        private readonly IAddUserRepository _addUserData;
        public AddUserWorker(IAddUserRepository addUserData) 
		{ 
          this._addUserData = addUserData;
        }
        public string AddUser(AddUserModel addUserModel)
        {
            string msg = _addUserData.InsertUserData(addUserModel);
            return msg;                
        }
		public List<UserTypeModel> GetUserType()
		{
			DataSet ds;
			List<UserTypeModel> userType = new List<UserTypeModel>();
			ds = _addUserData.GetUserTypeList();
			if (ds.Tables.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					userType.Add(new UserTypeModel
					{
						UserTypeId = Convert.ToInt16(dr["UserTypeId"]),
						UserDesc = dr["UserDesc"].ToString()
					});
				}
			}
			return userType;
		}
		public List<CadreModel> GetCadre()
		{
			DataSet ds;
			List<CadreModel> cadre = new List<CadreModel>();
			ds = _addUserData.GetCadreList();
			if (ds.Tables.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					cadre.Add(new CadreModel
					{
						Id = Convert.ToInt16(dr["CadreId"]),
						CadreName = dr["CadreDesc"].ToString()
					});
				}
			}
			return cadre;
		}	
        public bool Checkuser(string value)
        {
            bool msg = _addUserData.CheckuserData(value);
            return msg;
        }
    }
}
