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
    internal class InstructorDAL
    {
        public InstructorDbo getInstructor(InstructorDbo instructor)
        {
            InstructorDbo returnInstructor = new InstructorDbo(instructor.instructorName);
            try
            {
                returnInstructor = getInstructorInfo(instructor);
                if (returnInstructor.instructorId == 0)
                {
                    returnInstructor = saveCourseInfo(instructor);
                }
                return returnInstructor;
            }
            catch
            {
                return returnInstructor;
            }
        }


        private InstructorDbo getInstructorInfo(InstructorDbo instructor)
        {
            InstructorDbo returnInstructor = new InstructorDbo(instructor.instructorName);

            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "SELECT TOP 1 [instructor_id],[instructor_name],[registered_at]  FROM [instructor] ";
                queryString += " WHERE [instructor_name] = '" + returnInstructor.instructorName;
                queryString += "' ";

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        returnInstructor.instructorId = Int32.Parse(string.Format("{0}", reader["instructor_id"]));
                        returnInstructor.instructorName = string.Format("{0}", reader["instructor_name"]);
                        returnInstructor.registeredAt = DateTime.Parse(string.Format("{0}", reader["registered_at"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                    return returnInstructor;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return returnInstructor;
        }


        private InstructorDbo saveCourseInfo(InstructorDbo instructor)
        {
            InstructorDbo returnCourseDbo = new InstructorDbo(instructor.instructorName);
            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "INSERT INTO instructor ([instructor_name],[registered_at])";
                queryString += " VALUES ('" + instructor.instructorName + "', GETDATE())";
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


                returnCourseDbo = getInstructorInfo(instructor);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return returnCourseDbo;
        }
    }
}
