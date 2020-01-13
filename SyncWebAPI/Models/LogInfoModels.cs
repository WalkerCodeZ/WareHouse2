using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YsWebApi.Models
{
    public class LogInfoModels
    {
        public int EventID { get; set; }
        public int Priority { get; set; }

        public string Severity { get; set; }
        public string Information { get; set; }
        public string Title { get; set; }

        //public string Timestamp { get { return Timestamp; } set { Timestamp = DateTime.UtcNow.ToString(); }
        public string Timestamp { get; set; }
        public string MachineName { get; set; }
        public string AppDomainName { get; set; }
        public decimal ProcessID { get; set; }
        public string ProcessName { get; set; }
        public string ThreadName { get; set; }

        public string FormattedMessage { get; set; }
        public string Win32ThreadId { get; set; }
        public String Message { get; set; }
    }
}