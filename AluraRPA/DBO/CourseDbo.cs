using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.DBO
{
    internal class CourseDbo
    {
        public int courseId { get; set; }
        public string? title { get; set; }
        public int? duration { get; set; }
        public string? courseDesc { get; set; }
        public DateTime? registeredAt { get; set; }

        public CourseDbo(string title)
        {
            this.courseId = 0;
            this.title = title;
            this.duration = 0;
            this.courseDesc = "";
            this.registeredAt = DateTime.Now;
        }
    }
}
