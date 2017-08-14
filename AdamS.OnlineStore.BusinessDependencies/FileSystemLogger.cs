using AdamS.OnlineStore.DomainModel;
using System;

namespace AdamS.OnlineStore.BusinessDependencies
{
    public class FileSystemLogger : ILogger
    {
        public string GetTempPath()
        {
            string path = System.Environment.GetEnvironmentVariable("TEMP");
            if (!path.EndsWith("\\", StringComparison.Ordinal)) path += "\\";
            return path;
        }

        private void WriteToLog(string msg)
        {
            var sw = System.IO.File.AppendText(
                GetTempPath() + "AdamS.OnlineStore.txt");
            try
            {
                string logLine = System.String.Format(
                    "{0:G}: {1}.", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }



        public void Error(string message)
        {
            WriteToLog("ERROR:  " + message);
        }

        public void Error(string format, params object[] args)
        {
            WriteToLog("ERROR:  " + string.Format(format,args));
        }

        public void Error(Exception ex, string message)
        {
            WriteToLog("ERROR:  " + message + Environment.NewLine + ex);
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            WriteToLog("ERROR:  " + string.Format(format, args) + Environment.NewLine + ex);
        }

        public void Info(string message)
        {
            WriteToLog("INFO:  " + message);
        }

        public void Info(string format, params object[] args)
        {
            WriteToLog("INFO:  " + string.Format(format, args));
        }

        public void Info(Exception ex, string message)
        {
            WriteToLog("INFO:  " + message + Environment.NewLine + ex);
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            WriteToLog("INFO:  " + string.Format(format, args) + Environment.NewLine + ex);
            
        }
    }
}