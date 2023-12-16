using AluraRPA.DAL;
using AluraRPA.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Services
{
    internal class CourseService
    {
        CourseDAL courseDAL = new CourseDAL();

        public CourseDbo getCourseInfo(CourseDbo courseDbo)
        {
            CourseDbo returnCourse = courseDAL.getCourse(courseDbo);

            return returnCourse;
        }
    }
}
