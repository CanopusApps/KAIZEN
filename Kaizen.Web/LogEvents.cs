using System;
using System.Data;
using System.IO;
using Kaizen.Data.Constant;
namespace Kaizen.Web
{
    public static class LogEvents
    {
        public static void LogToFile(string Title, string LogMessages)
        {
           string pathExists = KaizenConstants.LoggerPath;
           if (!Directory.Exists(pathExists)){ Directory.CreateDirectory(KaizenConstants.LoggerPath);}
            StreamWriter swlog;
            string logpath = "";
            string Filename = DateTime.Now.ToString("ddMMyyyy") + ".txt";
            logpath = Path.Combine(pathExists, Filename);
            if (!File.Exists(logpath))
            {
                swlog = new StreamWriter(logpath);

            }
            else
            {
                swlog = File.AppendText(logpath);
            }
            swlog.WriteLine("Log Entry");
            swlog.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            swlog.WriteLine(" :");
            swlog.WriteLine("Message Title :{0}", Title);
            swlog.WriteLine("Message :{0}", LogMessages);
            swlog.WriteLine("------------------------------------------------------------------------");
            swlog.Close();
        }
    }
}
