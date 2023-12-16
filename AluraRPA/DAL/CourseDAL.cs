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
    internal class CourseDAL
    {
        public CourseDbo getCourse(CourseDbo course)
        {
            CourseDbo returnCourse = new CourseDbo(course.title);
            try
            {
                returnCourse = getCourseInfo(course);
                if(returnCourse.courseId == 0)
                {
                    returnCourse = saveCourseInfo(course);
                }
                return returnCourse;
            }
            catch
            {
                return returnCourse;
            }
        }


        private CourseDbo getCourseInfo(CourseDbo course)
        {
            CourseDbo returnCourse = new CourseDbo(course.title);

            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "SELECT TOP 1 [course_id],[title],[duration],[course_desc],[registered_at]  FROM [course] ";
                queryString += " WHERE [title] = '" + returnCourse.title;
                queryString += "' ";

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        returnCourse.courseId = Int32.Parse(string.Format("{0}", reader["course_id"]));
                        returnCourse.title = string.Format("{0}", reader["title"]);
                        returnCourse.duration = Int32.Parse(string.Format("{0}", reader["duration"]));
                        returnCourse.courseDesc = string.Format("{0}", reader["course_desc"]);
                        returnCourse.registeredAt = DateTime.Parse(string.Format("{0}", reader["registered_at"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                    return returnCourse;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return returnCourse;
        }


        private CourseDbo saveCourseInfo(CourseDbo course)
        {
            CourseDbo returnCourseDbo = new CourseDbo(course.title);
            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "INSERT INTO course ([title],[duration],[course_desc],[registered_at])";
                queryString += " VALUES ('" + course.title + "', "+course.duration+", '" + course.courseDesc + "',GETDATE())";
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


                returnCourseDbo = getCourseInfo(course);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return returnCourseDbo;
        }
    }
}
