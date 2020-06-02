using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    class SelectDemoPage : PageBase
    {
        private static SelectElement DaySelectList => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private static IWebElement SelectedDayLabel => Driver.FindElement(By.ClassName("selected-value"));
        private static SelectElement MultiSelectList => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private static IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private static IWebElement AllSelectedResult => Driver.FindElement(By.ClassName("getall-selected"));


        public SelectDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        }

        public SelectDemoPage SelectByValue(DayOfWeek dayOfWeek)
        {
            DaySelectList.SelectByValue(dayOfWeek.ToString());
            return this;
        }

        public SelectDemoPage AssertSelectedDay(DayOfWeek expectedDay)
        {
            Assert.AreEqual($"Day selected :- {expectedDay}", SelectedDayLabel.Text);
            return this;
        }
        public SelectDemoPage DeselectAll()
        {
            MultiSelectList.DeselectAll();
            return this;
        }
        public SelectDemoPage SelectMultiValue(List<string> selectMulti)
        {
            {
                foreach (string select in selectMulti)
                {
                    MultiSelectList.SelectByValue(select);
                }
            }
            return this;
        }
        public SelectDemoPage ButtonClick()
        {
           GetAllSelectedButton.Click();
            return this;
        }
        public SelectDemoPage TestMultiple()
        {
            Assert.That(MultiSelectList.IsMultiple);
            return this;
        }
        public SelectDemoPage AssertTextAbove(string expectedResult)
        {
            Assert.AreEqual($"Options selected are : {expectedResult}", AllSelectedResult.Text);
            return this;
        }
    }
}
