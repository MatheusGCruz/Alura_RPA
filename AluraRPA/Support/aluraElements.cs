using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA.Support
{
    public class aluraElements
    {
        // Search term
        private static string searchTerm = "RPA";

        // ID

        private static string searchBar = "header-barraBusca-form-campoBusca";
        // Class Name
        private static string searchResult = "busca-resultado-link";
        private static string searchButton = "header__nav--busca-submit";

        private static string nextPage = "busca-paginacao-linksProximos";

        private static string courseTitle1 = "formacao-headline-titulo";
        private static string courseTitle2 = "curso-banner-course-title";

        private static string duration1 = "formacao__info-destaque";
        private static string duration2 = "courseInfo-card-wrapper-infos";

        private static string courseDesc1 = "formacao-descricao-texto";
        private static string courseDesc2 = "course-title--learn";

        private static string instructor1 = "formacao-instrutor-nome";
        private static string instructor2 = "instructor-title--name";

        // X Path
        private static string searchResultLink = "//*[@id=\"busca-resultados\"]/ul/li[2]/a";



        public static string getSearchResult()
        {
            return searchResult;
        }

        public static string getCourseTitle(int type) 
        {
            string courseTitle = "";
            switch (type)
            {
                case 1:
                    courseTitle = courseTitle1;
                    break;
                case 2:
                    courseTitle = courseTitle2;
                    break;
            } 
            return courseTitle;         
        }

        public static string getCourseDesc(int type)
        {
            string courseDesc = "";
            switch (type)
            {
                case 1:
                    courseDesc = courseDesc1;
                    break;
                case 2:
                    courseDesc = courseDesc2;
                    break;
            }
            return courseDesc;
        }

        public static string getDuration(int type)
        {
            string duration = "";
            switch (type)
            {
                case 1:
                    duration = duration1;
                    break;
                case 2:
                    duration = duration2;
                    break;
            }
            return duration;
        }

        public static string getInstructor(int type)
        {
            string instructor = "";
            switch (type)
            {
                case 1:
                    instructor = instructor1;
                    break;
                case 2:
                    instructor = instructor2;
                    break;
            }
            return instructor;
        }

        public static string getSearchTerm() { return searchTerm; }

        public static string getSearchBar() { return searchBar; }
        public static string getSearchButton() { return searchButton; }
        public static string getSearchResultLink() {  return searchResultLink; }
        public static string getNextPage() { return nextPage; }


    }
}
