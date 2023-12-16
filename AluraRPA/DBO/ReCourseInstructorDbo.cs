using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.DBO
{
    internal class ReCourseInstructorDbo
    {
        public int relationId { get; set; }
        public int courseId { get; set; }
        public int instructorId { get; set; }
        public DateTime registeredAt { get; set; }

        public ReCourseInstructorDbo(int courseId, int instructorId)
        {
            this.relationId = 0;
            this.courseId = courseId;
            this.instructorId = instructorId;
            this.registeredAt = DateTime.UtcNow;
        }
    }
}
