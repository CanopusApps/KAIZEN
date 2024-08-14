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
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace NewKaizenService
{
    public partial class Service1 : ServiceBase
    {
        public Timer ScheduleTimer;

        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Thread startThread = new Thread(new ThreadStart(ScheduleService));
            startThread.Start();
        }
        public void ScheduleService()
        {
            try
            {
                ScheduleTimer = new Timer(new TimerCallback(SendMail));
                DateTime ScheduleTime = DateTime.MinValue;
                ScheduleTime = DateTime.Parse("15:08 PM");// Need to change trigger time
                if (DateTime.Now > ScheduleTime)
                    ScheduleTime = ScheduleTime.AddMinutes(5); // Need to change the schedule time
                TimeSpan timespan =ScheduleTime.Subtract(DateTime.Now);
                int dueMilliSecond = Convert.ToInt32(timespan.TotalMilliseconds);
                ScheduleTimer.Change(dueMilliSecond, Timeout.Infinite);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
            }
        }
        public void SendMail(object e)
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connection))
            {
                DataTable dt = new DataTable();
                SqlCommand com = new SqlCommand(ConfigurationManager.AppSettings["ApprovalProc"], conn);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            var Email = dr["ApproverEmail"].ToString();
                            var ApprovalName = dr["ApproverName"].ToString();
                            var KaizenID = dr["KaizenId"].ToString();
                            Email = "nitishkumar154@gmail.com";//Need to change with Dynamic Email ID.
                            using (MailMessage mail = new MailMessage())
                            {     
                                mail.From = new MailAddress(ConfigurationManager.AppSettings["From"]);
                                mail.To.Add(Email);
                                mail.Subject = ConfigurationManager.AppSettings["Subject"];
                                mail.IsBodyHtml = true;
                                mail.Body = "Dear " + ApprovalName + ",<br />Your Approval is pending for Kaizen ID "+ KaizenID + ", Please Approve the Details. <br /><br /><br /><br /><br /> Thanks & Regards,<br /> Kaizen Team ";
                                using (SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["Smtp"],Convert.ToInt32(ConfigurationManager.AppSettings["Port"])))
                                {
                                    smtp.UseDefaultCredentials = false;
                                    smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["From"], ConfigurationManager.AppSettings["Password"]);
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                }                               
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                    

                    }
                }

            }

           this.ScheduleService(); 
        }

        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt",true);
                sw.WriteLine(DateTime.Now.ToString()+": " + ex.Source.ToString().Trim()+"; " + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }
        public static void WriteErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }
        protected override void OnStop()
        {
            ScheduleTimer.Dispose();
        }
    }
}
