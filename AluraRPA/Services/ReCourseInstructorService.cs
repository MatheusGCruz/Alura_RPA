using AluraRPA.DAL;
using AluraRPA.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Services
{
    internal class ReCourseInstructorService
    {
        ReCourseInstructorDAL reCourseInstructorDAL = new ReCourseInstructorDAL();

        public ReCourseInstructorDbo getRelationInfo(ReCourseInstructorDbo reCourseInstructor)
        {
            ReCourseInstructorDbo returnReCourseInstructor = reCourseInstructorDAL.getRelationCourseInstructor(reCourseInstructor);

            return returnReCourseInstructor;
        }

    }
}
