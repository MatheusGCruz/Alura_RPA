using AluraRPA.DAL;
using AluraRPA.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Services
{
    internal class InstructorService
    {
        InstructorDAL instructorDAL = new InstructorDAL();

        public InstructorDbo getInstructorInfo(InstructorDbo instructor)
        {
            InstructorDbo returnInstructor = instructorDAL.getInstructor(instructor);

            return returnInstructor;
        }
    }
}
