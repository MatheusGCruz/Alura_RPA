using AluraRPA.DBO;
using AluraRPA.Support;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AluraRPA.DAL
{
    internal class AccessUrlDAL
    {
        public AccessUrlDbo getAccessUrl(AccessUrlDbo accessUrl)
        {
            AccessUrlDbo returnAccessUrl = new AccessUrlDbo(accessUrl.accessedUrl);

            try
            {
                returnAccessUrl = getAccessUrlObject(accessUrl);
                if(returnAccessUrl.acessUrlId > 0)
                {
                    return returnAccessUrl;
                }
                else
                {

                    return saveAccessUrl(accessUrl);
                }

            }
            catch
            {
                return returnAccessUrl;
            }
        }

        private AccessUrlDbo getAccessUrlObject(AccessUrlDbo accessUrl)
        {
            AccessUrlDbo returnAccessUrl = new AccessUrlDbo(accessUrl.accessedUrl);

            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "SELECT TOP 1 acess_url_id, accessed_url, access_tries, first_access, last_try, valid_url  FROM access_url ";
                queryString += " WHERE accessed_url = '" + accessUrl.accessedUrl;
                queryString += "' ";

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        returnAccessUrl.acessUrlId = Int32.Parse(string.Format("{0}", reader["acess_url_id"]));
                        returnAccessUrl.accessedUrl = string.Format("{0}", reader["accessed_url"]);
                        returnAccessUrl.accessTries = Int32.Parse(string.Format("{0}", reader["access_tries"]));
                        returnAccessUrl.firstAccess = DateTime.Parse(string.Format("{0}", reader["first_access"]));
                        returnAccessUrl.lastTry = DateTime.Parse(string.Format("{0}", reader["last_try"]));
                        returnAccessUrl.validUrl = Int32.Parse(string.Format("{0}", reader["valid_url"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                    return returnAccessUrl;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return returnAccessUrl;
        }


        private AccessUrlDbo saveAccessUrl(AccessUrlDbo accessUrl)
        {
            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                string queryString = "INSERT INTO access_url (accessed_url,access_tries,first_access,last_try,valid_url)";
                queryString += " VALUES ('" + accessUrl.accessedUrl + "', 1, GETDATE(), GETDATE(), "+accessUrl.validUrl+")";
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

                accessUrl = getAccessUrlObject(accessUrl);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return accessUrl;
        }

        public bool updateAccessUrl(AccessUrlDbo accessUrl)
        {
            int isValidUrl = (int)accessUrl.validUrl;
            accessUrl = getAccessUrlObject(accessUrl);
            try
            {
                SqlConnection connection = new SqlConnection(commomConnections.getSqlConnection());

                int newTrysQuantity = (int)accessUrl.accessTries;
                newTrysQuantity++;

                string queryString = "UPDATE access_url ";
                queryString += "SET access_tries = " + newTrysQuantity;
                queryString += " , last_try = GETDATE() ";
                queryString += " , valid_url =  " + isValidUrl;
                queryString += " WHERE acess_url_id = " + accessUrl.acessUrlId;

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

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return false;
        }

    }
}
