using AluraRPA.DAL;
using AluraRPA.DBO;
using AluraRPA.Services;
using AluraRPA.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraRPA
{
    public class WebAutomation
    {
        public IWebDriver driver;
        public IWebDriver subTabDriver;

        ReCourseInstructorService reCourseInstructorService = new ReCourseInstructorService();
        AccessUrlService accessUrlService = new AccessUrlService();
        CourseService courseService = new CourseService();
        InstructorService instructorService = new InstructorService();

        StringFunctions stringFunctions = new StringFunctions();

        public WebAutomation() 
        { 
            driver = new ChromeDriver();
        }

        public async void proccessExecution()
        {
            driver.Navigate().GoToUrl(urlList.aluraUrl());

            IWebElement searchBar = driver.FindElement(By.Id(aluraElements.getSearchBar()));
            searchBar.SendKeys(aluraElements.getSearchTerm());

            IWebElement searchButton = driver.FindElement(By.ClassName(aluraElements.getSearchButton()));
            searchButton.Click();

            bool existNextPage = false;

            do
            {
                ReadOnlyCollection<IWebElement> containers = driver.FindElements(By.ClassName(aluraElements.getSearchResult()));

                foreach (IWebElement resultElement in containers)
                {
                    string hrefValue = resultElement.GetAttribute("href");

                    Console.WriteLine(hrefValue);

                    string newUrl = urlList.courseUrl(hrefValue);

                    if (newUrl != "invalidUrl" && accessUrlService.tryAccess(newUrl))
                    {
                        AccessUrlDbo accessUrlDbo = new AccessUrlDbo(newUrl);
                        subTabDriver = new ChromeDriver();


                        try
                        {

                            accessUrlService.updateUrlData(accessUrlDbo);
                            subTabDriver.Navigate().GoToUrl(newUrl);


                            string tryCourseTitle = courseTitle(subTabDriver);

                            if (tryCourseTitle != "")
                            {
                                CourseDbo course = new CourseDbo(courseTitle(subTabDriver));
                                course.duration = courseDuration(subTabDriver);
                                course.courseDesc = courseDesc(subTabDriver);

                                course = courseService.getCourseInfo(course);

                                foreach (String tryInstructorName in instructors(subTabDriver))
                                {
                                    InstructorDbo instructor = new InstructorDbo(tryInstructorName);
                                    instructor = instructorService.getInstructorInfo(instructor);

                                    ReCourseInstructorDbo reCourseInstructor = new ReCourseInstructorDbo(course.courseId, instructor.instructorId);
                                    reCourseInstructor = reCourseInstructorService.getRelationInfo(reCourseInstructor);
                                };
                            }

                            else
                            {
                                accessUrlDbo.validUrl = 0;
                                accessUrlService.updateUrlData(accessUrlDbo);
                            }



                            subTabDriver.Close();
                            subTabDriver.Quit();
                        }
                        catch (Exception ex)
                        {
                            subTabDriver.Close();
                            subTabDriver.Quit();

                            accessUrlDbo.validUrl = 0;
                            accessUrlService.updateUrlData(accessUrlDbo);
                        }
                    }
                }

                ReadOnlyCollection<IWebElement> nextPage = driver.FindElements(By.ClassName(aluraElements.getNextPage()));
                if (nextPage.Count > 0)
                {
                    nextPage[0].Click();
                    existNextPage = true;
                }
                else
                {
                    existNextPage= false;
                }



            }
            while (existNextPage);

            driver.Close();
            driver.Quit();
        }

        private string courseTitle(IWebDriver subTabDriver)
        {
            ReadOnlyCollection<IWebElement> titleElement1 = subTabDriver.FindElements(By.ClassName(aluraElements.getCourseTitle(1)));
            ReadOnlyCollection<IWebElement> titleElement2 = subTabDriver.FindElements(By.ClassName(aluraElements.getCourseTitle(2)));

            if (titleElement1.Count>0) { return titleElement1[0].GetAttribute("innerHTML"); };
            if (titleElement2.Count > 0) { return titleElement2[0].GetAttribute("innerHTML"); };

            return "";

        }

        private int courseDuration(IWebDriver subTabDriver)
        {
            ReadOnlyCollection<IWebElement> durationElement1 = subTabDriver.FindElements(By.ClassName(aluraElements.getDuration(1)));
            ReadOnlyCollection<IWebElement> durationElement2 = subTabDriver.FindElements(By.ClassName(aluraElements.getDuration(2)));

            if (durationElement1.Count > 0) {return stringFunctions.returnIntFromChain(durationElement1[0].GetAttribute("innerHTML")); }
            if (durationElement2.Count > 0) { return stringFunctions.returnIntFromChain(durationElement2[0].GetAttribute("innerHTML")); }

            return 0;

        }

        private string courseDesc(IWebDriver subTabDriver)
        {
            ReadOnlyCollection<IWebElement> courseDescElement1 = subTabDriver.FindElements(By.ClassName(aluraElements.getCourseDesc(1)));
            ReadOnlyCollection<IWebElement> courseDescElement2 = subTabDriver.FindElements(By.ClassName(aluraElements.getCourseDesc(2)));

            if (courseDescElement1.Count > 0) { return courseDescElement1[0].GetAttribute("innerHTML"); };
            if (courseDescElement2.Count > 0) { return courseDescElement2[0].GetAttribute("innerHTML"); };

            return "";

        }

        private List<string> instructors(IWebDriver subTabDriver)
        {
            List<string> instructorsNames = new List<string>();
            ReadOnlyCollection<IWebElement> instructors1 = subTabDriver.FindElements(By.ClassName(aluraElements.getInstructor(1)));
            ReadOnlyCollection<IWebElement> instructors2 = subTabDriver.FindElements(By.ClassName(aluraElements.getInstructor(2)));

            if (instructors1.Count > 0) { 
                foreach (IWebElement instructor in instructors1) {
                    instructorsNames.Add(instructor.GetAttribute("innerHTML"));
                }
            };
            if (instructors2.Count > 0)
            {
                foreach (IWebElement instructor in instructors1)
                {
                    instructorsNames.Add(instructor.GetAttribute("innerHTML"));
                }
            };
            return instructorsNames;
        }


    }
}
