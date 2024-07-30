using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.DashboardModel;
using Kaizen.Models.NewKaizen;
using System;
using System.Collections.Generic;
using System.Data;
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
                        TotalApproved = dr["TotalApproved"] != DBNull.Value ? Convert.ToInt32(dr["TotalApproved"]) : 0



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
                        TotalApproved = dr["TotalApproved"] != DBNull.Value ? Convert.ToInt32(dr["TotalApproved"]) : 0



                    });
                }

            }
            return Kaizentotalcount;
        }
    }
}
