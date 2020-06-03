using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class SelectDemoTests
    {
        private static SelectDemoPage _demoPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _demoPage = new SelectDemoPage(driver);
        }

        [TestCase(DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Friday)]
        public static void TestFirstCheckBoxExactWait(DayOfWeek testDay)
        {
            _demoPage
                .SelectByValue(testDay)
                .AssertSelectedDay(testDay);

        }
        //2 testai naudojant page object, "Multi Select List Demo" sekcija:
        //* Pasirenkame viena reiksme , spaudziame Get all selected, patikriname, kad rodoma teisinga reiksme
        //* Pasirenkame kelias reiksmes, spaudziame Get all selected, patikriname , kad rodomos visos pazymetos reiksmes
        
             //[TestCase("New York")]
             //[TestCase("Florida,New Jersey,Texas")]
             //public void ArMultiple(string cityList)
                //{
                //    List<string> selectOptions = cityList.Split(',').ToList();
                //    _demoPage.DeselectAll().SelectMultiValue(selectOptions).ButtonClick().TestMultiple();
             //}
    
        [TestCase("New York")]
        [TestCase("Florida,New Jersey,Texas")]
        public static void TestMultiSelect(string cityList)
        {
            List<string> selectOptions = cityList.Split(',').ToList();
            _demoPage.DeselectAll().SelectMultiValue(selectOptions).ButtonClick().AssertTextAbove(cityList);
        }
        
        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _demoPage.CloseBrowser();
        }

    }
}
