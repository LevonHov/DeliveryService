using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Service.Models
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; } 
        public string Message { get; set; }  
        public string Severity { get; set; }  

        public LogEntry(string message, string severity)
        {
            Timestamp = DateTime.Now;
            Message = message;
            Severity = severity;
        }
    }

}
