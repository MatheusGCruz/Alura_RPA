using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.DBO
{
    internal class InstructorDbo
    {
        public int instructorId { get; set; }
        public string instructorName { get; set; }
        public DateTime registeredAt { get; set; }

        public InstructorDbo(string newInstructorName) { 
            this.registeredAt = DateTime.Now;
            this.instructorId = 0;
            this.instructorName = newInstructorName;
        }
    }
}
