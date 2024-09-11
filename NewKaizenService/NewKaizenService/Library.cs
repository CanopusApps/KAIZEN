using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewKaizenService
{
   public static class Library
    {
        public static void writeErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + "" + ex.Source.ToString().Trim() + "" + ex.Source.ToString().Trim());
                sw.Flush();
                sw.Close();

            }
            catch { }


        }
        public static void writeErrorLog(string  message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + "" + message);
                sw.Flush();
                sw.Close();

            }
            catch (Exception ex)
            { 
               
            }


        }
    }
}
