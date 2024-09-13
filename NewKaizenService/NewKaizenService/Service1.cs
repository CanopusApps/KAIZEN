using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Timers;
using System.Runtime.Remoting.Messaging;

namespace NewKaizenService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer1 = null;
        double Interval = double.Parse(ConfigurationManager.AppSettings["TriggerDurationInMinutes"]);
        public Service1()
        {
            InitializeComponent();
            this.timer1 = new System.Timers.Timer(Interval*60*1000);
            this.timer1.AutoReset = true;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_check);
            this.timer1.Start();
        }      
        protected override void OnStart(string[] args)
        {
            Library.writeErrorLog("Started:- " + DateTime.Now);
        }
        private void timer1_check(object sender, ElapsedEventArgs e)
        {
            Library.writeErrorLog("Running...." + DateTime.Now);
            try
            {
                Library.writeErrorLog("Executed  DB data...." + DateTime.Now);
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    DataTable dt = new DataTable();
                    SqlCommand com = new SqlCommand("Sp_Fetch_Kaizens_For_Approval", conn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            var Email = dr["ApproverEmail"].ToString();
                            //var Email = "nitish.kumar@canopusgbs.com";
                            var ApprovalName = dr["ApproverName"].ToString();
                            var DocNo = dr["DocNo"].ToString();
                            using (MailMessage mail = new MailMessage())
                            {
                                mail.From = new MailAddress(ConfigurationManager.AppSettings["From"]);
                                mail.To.Add(Email);
                                mail.Subject = ConfigurationManager.AppSettings["Subject"];
                                mail.IsBodyHtml = true;
                                mail.Body = "Dear " + ApprovalName + ",<br />Your Approval is pending for the below Kaizens.Please approve the Details. <br />" + DocNo + ".  <br /><br /><br /><br /><br /> Thanks & Regards,<br /> Kaizen Team ";
                                using (SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["Smtp"], Convert.ToInt32(ConfigurationManager.AppSettings["Port"])))
                                {
                                    smtp.UseDefaultCredentials = false;
                                    smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["From"], ConfigurationManager.AppSettings["Password"]);
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Library.writeErrorLog("Started:- " + ex.Message + DateTime.Now);
            }
           }
        protected override void OnStop()
        {
            Library.writeErrorLog("Service Stoped:- " + DateTime.Now);
            timer1.Enabled = false;
        }
    }
}
