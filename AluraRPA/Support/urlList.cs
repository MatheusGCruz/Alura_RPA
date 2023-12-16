using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Support
{
    public class urlList
    {
        // Simple URLs
        private static string google = "https://www.google.com";
        private static string alura = "https://www.alura.com.br/";

        // Composite URLs
        private static string aluraResults = "https://www.alura.com.br/busca?query=";

        public static string googleUrl()
        {
            return google;
        }

        public static string aluraUrl()
        {
            return alura;
        }

        public static string aluraResultsUrl(string searchItem)
        {
            string compositeUrl = aluraResults;
            compositeUrl += searchItem;
            return compositeUrl;
        }

        public static string courseUrl(string originalUrl)
        {
            if (originalUrl.StartsWith("https://cursos.alura.com.br/"))
            {

                return "invalidUrl";
            }

            else
            {
                return originalUrl;
            }


        }
    }
}
