using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Com.Illuminati.Galileo.Foundation
{
    public class GalileoLogger
    {
        public enum Level
        {
            Trace,
            Debug,
            Info,
            Warn,
            Error,
            Fatal
        }
        
        public static readonly GalileoLogger Instance = new GalileoLogger();

        public delegate void LoggerProc(Level level, string log);

        public delegate void ReportProc(string log);

        public event LoggerProc Logger;

        public event ReportProc ReportEvent;

        public void Report(string category, params string[] log)
        {
            if (ReportEvent != null)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("category={0}", category);
                foreach (var item in log)
                {
                    sb.Append("^").Append(log);
                }
                ReportEvent(sb.ToString());
            }
        }

        public void Trace(string content)
        {
            Log(Level.Trace, content);
        }
        public void Debug(string content)
        {
            Log(Level.Debug, content);
        }

        public void Info(string content)
        {
            Log(Level.Info, content);
        }

        public void Warning(string content)
        {
            Log(Level.Warn, content);
        }

        public void Error(string content)
        {
            Log(Level.Error, content);
        }
 
        public void Fatal(string content)
        {
            Log(Level.Fatal, content);
        }

        private void Log(Level level, string content)
        {
            if (Logger != null)
            {
                Logger(level, content);
            }
            else
            {
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level.ToString()}] [{Process.GetCurrentProcess().Id}:{Thread.CurrentThread.ManagedThreadId}] - {content}");
            }
        }
    }
}
