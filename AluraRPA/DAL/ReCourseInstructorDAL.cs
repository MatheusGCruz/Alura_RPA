using AluraRPA.DBO;
using AluraRPA.Support;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.DAL
{
    internal class ReCourseInstructorDAL
    {
        public ReCourseInstructorDbo getRelationCourseInstructor(ReCourseInstructorDbo reCourseInstructor)
        {
            ReCourseInstructorDbo returnCourseInstructor = new ReCourseInstructorDbo(reCourseInstructor.courseId, reCourseInstructor.instructorId);
            try
            {
                returnCourseInstructor = getRelationInfo(reCourseInstructor);
                if (returnCourseInstructor.relationId == 0)
                {
                    returnCourseInstructor = saveRelationInfo(reCourseInstructor);
                }
                return returnCourseInstructor;
            }
            catch
            {
                return returnCourseInstructor;
            }
        }


        private ReCourseInstructorDbo getRelationInfo(ReCourseInstructorDbo reCourseInstructor)
        {
            ReCourseInstructorDbo returnCourseInstructor = new ReCourseInstructorDbo(reCourseInstructor.courseId, reCourseInstructor.instructorId);

            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "SELECT TOP 1 [relation_id],[course_id],[instructor_id],[registered_at]  FROM [re_course_instructor] ";
                queryString += " WHERE [course_id] = " + returnCourseInstructor.courseId;
                queryString += " AND [instructor_id] = " + returnCourseInstructor.instructorId;

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        returnCourseInstructor.relationId = Int32.Parse(string.Format("{0}", reader["relation_id"]));
                        returnCourseInstructor.instructorId = Int32.Parse(string.Format("{0}", reader["instructor_id"]));
                        returnCourseInstructor.courseId = Int32.Parse(string.Format("{0}", reader["instructor_id"]));
                        returnCourseInstructor.registeredAt = DateTime.Parse(string.Format("{0}", reader["registered_at"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                    return returnCourseInstructor;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return returnCourseInstructor;
        }


        private ReCourseInstructorDbo saveRelationInfo(ReCourseInstructorDbo reCourseInstructor)
        {
            ReCourseInstructorDbo returnCourseInstructor = new ReCourseInstructorDbo(reCourseInstructor.courseId, reCourseInstructor.instructorId);
            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "INSERT INTO re_course_instructor ([course_id],[instructor_id],[registered_at])";
                queryString += " VALUES (" + returnCourseInstructor.courseId + "," + returnCourseInstructor.instructorId + ", GETDATE())";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                }


                returnCourseInstructor = getRelationInfo(reCourseInstructor);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return returnCourseInstructor;
        }
    }
}
