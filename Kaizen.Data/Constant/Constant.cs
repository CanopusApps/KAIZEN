﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.Constant
{
    public class Constant
    {


    }
    public class DbFiles
    {
        public static string Data = "Data";
        public static string ConnectionString = "ConnectionString";
        public static string appsetting = "appsettings.json";
        public static string Title = "Title";


    }
    public class StoredProcedures
    {
        public static string Splogin = "Sp_Login";
        public static string Spregister = "Sp_Register";
        public static string Spemployee = "Sp_Employee";
        public static string SpregisterLog = "Sp_RegisterLog";
        public static string SpSelectState = "Sp_SelectState";
        public static string SpCreateBlock = "Sp_CreateBlock";
        public static string Sp_Fetch_Department = "Sp_Fetch_Department";
        public static string Sp_Fetch_Domain= "Sp_Fetch_Domain";
        public static string Sp_Fetch_cadre = "Sp_Fetch_cadre";
        public static string Sp_Fetch_UserType = "Sp_Fetch_UserType";
        public static string Sp_InsertUser = "Sp_InsertUser";
		public static string SpCreateDomain = "Sp_CreateDomain";

		public static string Fetch_User = "Fetch_User";
        public static string Sp_Delete_User = "Sp_Delete_User";
        




    }
}
