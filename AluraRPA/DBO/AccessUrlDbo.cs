using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.DBO
{
    internal class AccessUrlDbo
    {
        public int acessUrlId { get; set; }
        public string? accessedUrl { get; set; }
        public int? accessTries { get; set; }
        public DateTime? firstAccess { get; set; }
        public DateTime? lastTry { get; set; }
        public int? validUrl { get; set; }

        public AccessUrlDbo(string accessedUrl)
        {
            this.acessUrlId = 0;
            this.accessedUrl= accessedUrl; 
            this.accessTries = 0;
            this.firstAccess = DateTime.Now;
            this.lastTry = DateTime.Now;
            this.validUrl = 1;
        }
    }
}
