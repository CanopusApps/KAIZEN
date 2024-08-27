using DocumentFormat.OpenXml.Bibliography;
using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.DashboardModel;
using Kaizen.Models.NewKaizen;
//using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class DashboardWorker : IDashboard

    {
        public readonly IDashboardRepository Repository;
        public DashboardWorker(IDashboardRepository Repository) {
          this.Repository = Repository;
        }

        public List<DepartmentModel> DepartmentbasedkaizenCount(DashboardModel model)
        {
            DataSet ds;
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            ds= Repository.GetDepartmentKaizenCount(model);
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        departmentModels.Add(new DepartmentModel
                        {
                            DeptId = Convert.ToInt32(dr["DeptId"]),
                            DepartmentName = dr["DepartmentName"].ToString(),
                            DomainId = Convert.ToInt32(dr["DomainId"].ToString()),
                            DomainName = dr["DomainName"].ToString(),
                            Status = Convert.ToBoolean(dr["Status"]),
                            User_count = Convert.ToInt32(dr["user_count"]),
                            kaizen_count = Convert.ToInt32(dr["kaizen_count"]),
                            KaizenSubmitedCountdept = Convert.ToInt32(dr["KaizenSubmittedUserdept"])

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departmentModels;
        }

        public List<DomainModel> DomainbasedkaizenCount(DashboardModel model)
        {
            DataSet ds;
            List<DomainModel> domainKaizencount = new List<DomainModel>();
            ds = Repository.GetDomainKaizenCount(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    domainKaizencount.Add(new DomainModel
                    {
                        Id = Convert.ToInt32(dr["DomainId"]),
                        DomainName = dr["DomainName"].ToString(),
                        Status = Convert.ToBoolean(dr["Status"]),
                        User_count = Convert.ToInt32(dr["user_count"]),
                        KaizenSubmitted = Convert.ToInt32(dr["kaizen_count"]),
                        AllKaizenSubmitted = Convert.ToInt32(dr["AllKaizen_count"]),
                        KaizenSubmittedUser = Convert.ToInt32(dr["kaizensubmittedUser"])
                    });
                }
            }
            return domainKaizencount;
        }

        public List<EmployeeDashboardModel> GetEmployeedashboardcount(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<EmployeeDashboardModel> Kaizencount = new List<EmployeeDashboardModel>();
            Kaizencountdata = Repository.GetEmployeeDashboardCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[0].Rows)
                {
                    Kaizencount.Add(new EmployeeDashboardModel
                    {

                        EmpId = dr["EmpId"] != DBNull.Value ? dr["EmpId"].ToString() : string.Empty,
                        FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty,
                        KaizenCount = dr["KaizenCount"] != DBNull.Value ? Convert.ToInt32(dr["KaizenCount"]) : 0,
                        TotalApproved = dr["TotalApproved"] != DBNull.Value ? Convert.ToInt32(dr["TotalApproved"]) : 0,
                        TotalRejected = dr["TotalRejected"] != DBNull.Value ? Convert.ToInt32(dr["TotalRejected"]) : 0,
                        TotalPending = dr["TotalPending"] != DBNull.Value ? Convert.ToInt32(dr["TotalPending"]) : 0,
                        ImageApproved = dr["ImageApproved"] != DBNull.Value ? Convert.ToInt32(dr["ImageApproved"]) : 0,
                        ImageRejected = dr["ImageRejected"] != DBNull.Value ? Convert.ToInt32(dr["ImageRejected"]) : 0,
                        ImagePending = dr["ImagePending"] != DBNull.Value ? Convert.ToInt32(dr["ImagePending"]) : 0,
                        ManagerApproved = dr["ManagerApproved"] != DBNull.Value ? Convert.ToInt32(dr["ManagerApproved"]) : 0,
                        ManagerRejected = dr["ManagerRejected"] != DBNull.Value ? Convert.ToInt32(dr["ManagerRejected"]) : 0,
                        ManagerPending = dr["ManagerPending"] != DBNull.Value ? Convert.ToInt32(dr["ManagerPending"]) : 0,
                        IEApproved = dr["IEApproved"] != DBNull.Value ? Convert.ToInt32(dr["IEApproved"]) : 0,
                        IERejected = dr["IERejected"] != DBNull.Value ? Convert.ToInt32(dr["IERejected"]) : 0,
                        IEPending = dr["IEPending"] != DBNull.Value ? Convert.ToInt32(dr["IEPending"]) : 0,
                        FinanceApproved = dr["FinanceApproved"] != DBNull.Value ? Convert.ToInt32(dr["FinanceApproved"]) : 0,
                        FinanceRejected = dr["FinanceRejected"] != DBNull.Value ? Convert.ToInt32(dr["FinanceRejected"]) : 0,
                        FinancePending = dr["FinancePending"] != DBNull.Value ? Convert.ToInt32(dr["FinancePending"]) : 0

                    });
                }

            }

            return Kaizencount;
        }

        public List<CountKaizenStatus> GetKaizenCount(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List <CountKaizenStatus> Kaizencount= new List <CountKaizenStatus>();
            Kaizencountdata = Repository.GetKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[1].Rows)
                {
                    Kaizencount.Add(new CountKaizenStatus
                    {
                        ApprovalCount = dr["ApprovalCount"] != DBNull.Value ? Convert.ToInt32(dr["ApprovalCount"]) : 0,
                        ApprovalStatus = dr["ApprovalStatus"] != DBNull.Value ? Convert.ToInt32(dr["ApprovalStatus"]) : 0,
                        ApprovalStatusdesc = dr["ApprovalStatusdesc"] != DBNull.Value ? dr["ApprovalStatusdesc"].ToString() : string.Empty

                    });
                }

            }
            
            return Kaizencount;
        }

        public List<CountKaizenStatus> GetKaizenCountmonth(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<CountKaizenStatus> Kaizencount = new List<CountKaizenStatus>();
            Kaizencountdata = Repository.GetKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[3].Rows)
                {
                    Kaizencount.Add(new CountKaizenStatus
                    {
                        monthbased = dr["MonthYear"] != DBNull.Value ? dr["MonthYear"].ToString() : "0",

                    ApprovalCount = dr["ApprovalCount"] != DBNull.Value ? Convert.ToInt32(dr["ApprovalCount"]) : 0,
                        ApprovalStatus = dr["ApprovalStatus"] != DBNull.Value ? Convert.ToInt32(dr["ApprovalStatus"]) : 0,
                        ApprovalStatusdesc = dr["ApprovalStatusdesc"] != DBNull.Value ? dr["ApprovalStatusdesc"].ToString() : string.Empty

                    });
                }

            }

            return Kaizencount;
        }

        public List<TotalKaizennos> GetKaizentotalCount(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<TotalKaizennos> Kaizentotalcount = new List<TotalKaizennos>();
            Kaizencountdata = Repository.GetKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[0].Rows)
                {
                    Kaizentotalcount.Add(new TotalKaizennos
                    {
                       
                        TotalKaizens = dr["TotalKaizens"] != DBNull.Value ? Convert.ToInt32(dr["TotalKaizens"]) : 0,
                        DRITotal = dr["DRITotal"] != DBNull.Value ? Convert.ToInt32(dr["DRITotal"]) : 0,
                        FinanceTotal = dr["FinanceTotal"] != DBNull.Value ? Convert.ToInt32(dr["FinanceTotal"]) : 0,
                        IETotal = dr["IETotal"] != DBNull.Value ? Convert.ToInt32(dr["IETotal"]) : 0,
                        Imagetotal = dr["Imagetotal"] != DBNull.Value ? Convert.ToInt32(dr["Imagetotal"]) : 0,
                        TotalPending = dr["TotalPending"] != DBNull.Value ? Convert.ToInt32(dr["TotalPending"]) : 0,
                        TotalRejected = dr["TotalRejected"] != DBNull.Value ? Convert.ToInt32(dr["TotalRejected"]) : 0,
                        TotalApproved = dr["TotalApproved"] != DBNull.Value ? Convert.ToInt32(dr["TotalApproved"]) : 0,
                         CardImageApproved = dr["cardImageApproved"] != DBNull.Value ? Convert.ToInt32(dr["cardImageApproved"]) : 0,
                        CardManagerApproved = dr["CardManagerApproved"] != DBNull.Value ? Convert.ToInt32(dr["CardManagerApproved"]) : 0,
                        CardIEApproved = dr["CardIEApproved"] != DBNull.Value ? Convert.ToInt32(dr["CardIEApproved"]) : 0,
                        CardManagerPending = dr["carddripending"] != DBNull.Value ? Convert.ToInt32(dr["carddripending"]) : 0


                    });
                }

            }
            return Kaizentotalcount;
        }

        public List<TotalKaizennos> GetKaizentotalCountCustomMonth(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<TotalKaizennos> Kaizentotalcount = new List<TotalKaizennos>();
            Kaizencountdata = Repository.GetKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[4].Rows)
                {
                    Kaizentotalcount.Add(new TotalKaizennos
                    {
                        monthbasedTotal = dr["CustomMonthRange"] != DBNull.Value ? dr["CustomMonthRange"].ToString() : "0",
                        TotalKaizens = dr["TotalKaizens"] != DBNull.Value ? Convert.ToInt32(dr["TotalKaizens"]) : 0,
                    });
                }

            }
            return Kaizentotalcount;
        }

        public List<TotalKaizennos> GetKaizentotalCountmonth(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<TotalKaizennos> Kaizentotalcount = new List<TotalKaizennos>();
            Kaizencountdata = Repository.GetKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[2].Rows)
                {
                    Kaizentotalcount.Add(new TotalKaizennos
                    {
                        monthbasedTotal = dr["MonthYear"] != DBNull.Value ? dr["MonthYear"].ToString() : "0",
                    TotalKaizens = dr["TotalKaizens"] != DBNull.Value ? Convert.ToInt32(dr["TotalKaizens"]) : 0,
                        DRITotal = dr["DRITotal"] != DBNull.Value ? Convert.ToInt32(dr["DRITotal"]) : 0,
                        FinanceTotal = dr["FinanceTotal"] != DBNull.Value ? Convert.ToInt32(dr["FinanceTotal"]) : 0,
                        IETotal = dr["IETotal"] != DBNull.Value ? Convert.ToInt32(dr["IETotal"]) : 0,
                        Imagetotal = dr["Imagetotal"] != DBNull.Value ? Convert.ToInt32(dr["Imagetotal"]) : 0,
                        TotalPending = dr["TotalPending"] != DBNull.Value ? Convert.ToInt32(dr["TotalPending"]) : 0,
                        TotalRejected = dr["TotalRejected"] != DBNull.Value ? Convert.ToInt32(dr["TotalRejected"]) : 0,
                        TotalApproved = dr["TotalApproved"] != DBNull.Value ? Convert.ToInt32(dr["TotalApproved"]) : 0,
                        CardImageApproved = dr["cardImageApproved"] != DBNull.Value ? Convert.ToInt32(dr["cardImageApproved"]) : 0,
                        CardManagerApproved = dr["CardManagerApproved"] != DBNull.Value ? Convert.ToInt32(dr["CardManagerApproved"]) : 0,
                        CardIEApproved = dr["CardIEApproved"] != DBNull.Value ? Convert.ToInt32(dr["CardIEApproved"]) : 0,
                        CardManagerPending = dr["carddripending"] != DBNull.Value ? Convert.ToInt32(dr["carddripending"]) : 0




                    });
                }

            }
            return Kaizentotalcount;
        }

        public List<EmployeeDashboardModel> GetmonthbasedEmployeedashboardcount(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<EmployeeDashboardModel> Kaizencount = new List<EmployeeDashboardModel>();
            Kaizencountdata = Repository.GetEmployeeDashboardCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[1].Rows)
                {
                    Kaizencount.Add(new EmployeeDashboardModel
                    {

                        EmpId = dr["EmpId"] != DBNull.Value ? dr["EmpId"].ToString() : string.Empty,
                         MonthYear = dr["MonthYear"] != DBNull.Value ? dr["MonthYear"].ToString() : "0",
                        FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty,
                        KaizenCount = dr["KaizenCount"] != DBNull.Value ? Convert.ToInt32(dr["KaizenCount"]) : 0,
                        TotalApproved = dr["TotalApproved"] != DBNull.Value ? Convert.ToInt32(dr["TotalApproved"]) : 0,
                        TotalRejected = dr["TotalRejected"] != DBNull.Value ? Convert.ToInt32(dr["TotalRejected"]) : 0,
                        TotalPending = dr["TotalPending"] != DBNull.Value ? Convert.ToInt32(dr["TotalPending"]) : 0
                      

                    });
                }

            }

            return Kaizencount;
        }

        public List<graphKaizentotalModel> kaizenCountbasedonBlocks(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<graphKaizentotalModel> Kaizentotalcount = new List<graphKaizentotalModel>();
            Kaizencountdata = Repository.GetGraphKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[2].Rows)
                {
                    Kaizentotalcount.Add(new graphKaizentotalModel
                    {

                        Blockid= Convert.ToInt32(dr["BlockId"]),
                        Blockname= dr["BlockName"].ToString(),
                        TotalSubmittedKaizen = Convert.ToInt32(dr["AllKaizen_count"])


                    });
                }

            }
            return Kaizentotalcount;
        } 

        public List<graphKaizentotalModel> kaizenCountbasedonCadre(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<graphKaizentotalModel> Kaizentotalcount = new List<graphKaizentotalModel>();
            Kaizencountdata = Repository.GetGraphKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[3].Rows)
                {
                    Kaizentotalcount.Add(new graphKaizentotalModel
                    {

                        Cadreid = Convert.ToInt32(dr["CadreId"]),
                        Cadrename = dr["CadreDesc"].ToString(),
                        TotalSubmittedKaizen = Convert.ToInt32(dr["AllKaizen_count"])

                    });
                }

            }
            return Kaizentotalcount;
        }

        public List<graphKaizentotalModel> kaizenCountbasedonDepartment(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<graphKaizentotalModel> Kaizentotalcount = new List<graphKaizentotalModel>();
            Kaizencountdata = Repository.GetDepartmentGraphKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[0].Rows)
                {
                    Kaizentotalcount.Add(new graphKaizentotalModel
                    {

                        Departmentid = Convert.ToInt32(dr["DeptId"]),
                        Departmentname = dr["DepartmentName"].ToString(),
                        TotalSubmittedKaizen = Convert.ToInt32(dr["AllKaizen_count"]),
                        Domainname = dr["DomainName"].ToString()




                    }) ;
                }

            }
            return Kaizentotalcount;
        }

        public List<graphKaizentotalModel> kaizenCountbasedonDomain(DashboardModel model)
        {
            DataSet Kaizencountdata = new DataSet();
            List<graphKaizentotalModel> Kaizentotalcount = new List<graphKaizentotalModel>();
            Kaizencountdata = Repository.GetGraphKaizenCount(model);
            if (Kaizencountdata.Tables.Count > 0)
            {
                foreach (DataRow dr in Kaizencountdata.Tables[1].Rows)
                {
                    Kaizentotalcount.Add(new graphKaizentotalModel
                    {

                        Domainid = Convert.ToInt32(dr["DomainId"]),
                        Domainname = dr["DomainName"].ToString(),
                        TotalSubmittedKaizen = Convert.ToInt32(dr["AllKaizen_count"])


                    });
                }

            }
            return Kaizentotalcount;
        }






        public List<DepartmentModel> managerDepartmentbasedkaizenCount(DashboardModel model, string Empid)
        {
            DataSet ds;
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            ds = Repository.Getmanagetdomaindepartment(model,Empid);
            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        departmentModels.Add(new DepartmentModel
                        {
                            DeptId = Convert.ToInt32(dr["DeptId"]),
                            DepartmentName = dr["DepartmentName"].ToString(),
                            User_count = Convert.ToInt32(dr["user_count"]),
                            kaizen_count = Convert.ToInt32(dr["kaizen_count"]),
                            KaizenSubmitedCountdept = Convert.ToInt32(dr["KaizenSubmittedUserCount"])

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departmentModels;
        }

        public List<DomainModel> ManagerDomainbasedkaizenCount(DashboardModel model, string Empid)
        {
            DataSet ds;
            List<DomainModel> domainKaizencount = new List<DomainModel>();
            ds = Repository.Getmanagetdomaindepartment(model,Empid);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    domainKaizencount.Add(new DomainModel
                    {
                        Id = Convert.ToInt32(dr["DomainId"]),
                        DomainName = dr["DomainName"].ToString(),
                        User_count = Convert.ToInt32(dr["user_count"]),
                        KaizenSubmitted = Convert.ToInt32(dr["kaizen_count"]),
                        KaizenSubmittedUser = Convert.ToInt32(dr["kaizensubmittedUserCount"])
                    });
                }
            }
            return domainKaizencount;
        }










        public List<OtherDashboardmodel> Otherdashboard(DashboardModel model)
        {
            DataSet kaizenCountData = new DataSet();
            List<OtherDashboardmodel> otherDashboardModels = new List<OtherDashboardmodel>();

            kaizenCountData = Repository.GetOtherKaizenCount(model);
            if (kaizenCountData.Tables.Count > 0)
            {
                foreach (DataRow dr in kaizenCountData.Tables[0].Rows)
                {
                    otherDashboardModels.Add(new OtherDashboardmodel
                    {

                        EmpId = dr["UserId"] != DBNull.Value ? dr["UserId"].ToString() : string.Empty,
                        Usertypeid = dr["UserTypeID"] != DBNull.Value ? Convert.ToInt32(dr["UserTypeID"]) : 0,
                        FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty,
                        LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : string.Empty,
                        Usertypedesc = dr["UserType"] != DBNull.Value ? dr["UserType"].ToString() : string.Empty,
                        ImageTotal = dr["ImageTotal"] != DBNull.Value ? Convert.ToInt32(dr["ImageTotal"]) : 0,
                        ManagerTotal = dr["ManagerTotal"] != DBNull.Value ? Convert.ToInt32(dr["ManagerTotal"]) : 0,
                        IETotal = dr["IETotal"] != DBNull.Value ? Convert.ToInt32(dr["IETotal"]) : 0,
                        FinanceTotal = dr["FinanceTotal"] != DBNull.Value ? Convert.ToInt32(dr["FinanceTotal"]) : 0,
                        ImageApproved = dr["ImageApproved"] != DBNull.Value ? Convert.ToInt32(dr["ImageApproved"]) : 0,
                        ImageRejected = dr["ImageRejected"] != DBNull.Value ? Convert.ToInt32(dr["ImageRejected"]) : 0,
                        ImagePending = dr["ImagePending"] != DBNull.Value ? Convert.ToInt32(dr["ImagePending"]) : 0,
                        ManagerApproved = dr["ManagerApproved"] != DBNull.Value ? Convert.ToInt32(dr["ManagerApproved"]) : 0,
                        ManagerRejected = dr["ManagerRejected"] != DBNull.Value ? Convert.ToInt32(dr["ManagerRejected"]) : 0,
                        ManagerPending = dr["ManagerPending"] != DBNull.Value ? Convert.ToInt32(dr["ManagerPending"]) : 0,
                        IEApproved = dr["IEApproved"] != DBNull.Value ? Convert.ToInt32(dr["IEApproved"]) : 0,
                        IERejected = dr["IERejected"] != DBNull.Value ? Convert.ToInt32(dr["IERejected"]) : 0,
                        IEPending = dr["IEPending"] != DBNull.Value ? Convert.ToInt32(dr["IEPending"]) : 0,
                        FinanceApproved = dr["FinanceApproved"] != DBNull.Value ? Convert.ToInt32(dr["FinanceApproved"]) : 0,
                        FinanceRejected = dr["FinanceRejected"] != DBNull.Value ? Convert.ToInt32(dr["FinanceRejected"]) : 0,
                        FinancePending = dr["FinancePending"] != DBNull.Value ? Convert.ToInt32(dr["FinancePending"]) : 0
                    });
                }
            }

            return otherDashboardModels;
        }


        public List<OtherDashboardmodel> OtherMonthbaseddashboard(DashboardModel model)
        {
            DataSet kaizenCountData = new DataSet();
            List<OtherDashboardmodel> otherDashboardModels = new List<OtherDashboardmodel>();

            kaizenCountData = Repository.GetOtherKaizenCount(model);
            if (kaizenCountData.Tables.Count > 0)
            {
                foreach (DataRow dr in kaizenCountData.Tables[1].Rows)
                {
                    otherDashboardModels.Add(new OtherDashboardmodel
                    {
                        MonthYear = dr["MonthYear"] != DBNull.Value ? dr["MonthYear"].ToString() : string.Empty,
                        EmpId = dr["UserId"] != DBNull.Value ?dr["UserId"].ToString() :  string.Empty,
                        Usertypeid = dr["UserTypeID"] != DBNull.Value ? Convert.ToInt32(dr["UserTypeID"]) : 0,
                        FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty,
                        LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : string.Empty,
                        Usertypedesc = dr["UserType"] != DBNull.Value ? dr["UserType"].ToString() : string.Empty,
                        ImageTotal = dr["ImageTotal"] != DBNull.Value ? Convert.ToInt32(dr["ImageTotal"]) : 0,
                        ManagerTotal = dr["ManagerTotal"] != DBNull.Value ? Convert.ToInt32(dr["ManagerTotal"]) : 0,
                        IETotal = dr["IETotal"] != DBNull.Value ? Convert.ToInt32(dr["IETotal"]) : 0,
                        FinanceTotal = dr["FinanceTotal"] != DBNull.Value ? Convert.ToInt32(dr["FinanceTotal"]) : 0,
                        ImageApproved = dr["ImageApproved"] != DBNull.Value ? Convert.ToInt32(dr["ImageApproved"]) : 0,
                        ImageRejected = dr["ImageRejected"] != DBNull.Value ? Convert.ToInt32(dr["ImageRejected"]) : 0,
                        ImagePending = dr["ImagePending"] != DBNull.Value ? Convert.ToInt32(dr["ImagePending"]) : 0,
                        ManagerApproved = dr["ManagerApproved"] != DBNull.Value ? Convert.ToInt32(dr["ManagerApproved"]) : 0,
                        ManagerRejected = dr["ManagerRejected"] != DBNull.Value ? Convert.ToInt32(dr["ManagerRejected"]) : 0,
                        ManagerPending = dr["ManagerPending"] != DBNull.Value ? Convert.ToInt32(dr["ManagerPending"]) : 0,
                        IEApproved = dr["IEApproved"] != DBNull.Value ? Convert.ToInt32(dr["IEApproved"]) : 0,
                        IERejected = dr["IERejected"] != DBNull.Value ? Convert.ToInt32(dr["IERejected"]) : 0,
                        IEPending = dr["IEPending"] != DBNull.Value ? Convert.ToInt32(dr["IEPending"]) : 0,
                        FinanceApproved = dr["FinanceApproved"] != DBNull.Value ? Convert.ToInt32(dr["FinanceApproved"]) : 0,
                        FinanceRejected = dr["FinanceRejected"] != DBNull.Value ? Convert.ToInt32(dr["FinanceRejected"]) : 0,
                        FinancePending = dr["FinancePending"] != DBNull.Value ? Convert.ToInt32(dr["FinancePending"]) : 0
                    });
                }
            }

            return otherDashboardModels;
        }
    }
}
