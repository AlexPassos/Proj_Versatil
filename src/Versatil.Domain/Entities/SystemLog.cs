using System;

namespace Versatil.Domain.Entities
{
    public class SystemLog : Entity
    {
        public SystemLog()
        {
            DateTime = DateTime.Now;
        }

        public long LogId { get; set; }
        public DateTime DateTime { get; set; }
        public string User { get; set; }
        public string IP { get; set; }
        public string Browser { get; set; }
        public string Hostname { get; set; }
        public string AreaAccessed { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public int? StatusCode { get; set; }
        public string Cookies { get; set; }
        public string Form { get; set; }
        public string ServerVariables { get; set; }
        public string QueryString { get; set; }
        public string Data { get; set; }
    }
}
