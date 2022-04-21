using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestApp
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver(); int randomNumber=0;
        [TestInitialize]
        public void Init()
        {
            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
                //IWebElement btnAddElement = driver.FindElement(By.XPath("//button[text()='Add Element']"));
                //btnAddElement.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail("Bad URL/Site is down");
            }
 
        }
        [TestMethod]
        public void CheckAddElement()
        {
            IWebElement btnAddElement = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            Random rnd = new Random();
            int n = rnd.Next(1, 2); ;
            for (int i = 0; i < n; i++)
            { btnAddElement.Click(); }
            Thread.Sleep(1000);
            IList<IWebElement> ctElements = driver.FindElements(By.XPath("//div[@id='elements']//*"));
            if (ctElements.Count < 0)
            {
                Assert.Fail("N number of Elements are not generated");
            }

        }

        [TestMethod]
        public void CheckRandomlyGeneratedElements()
        {
            IWebElement btnAddElement = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            IList<IWebElement> ctElements = driver.FindElements(By.XPath("//div[@id='elements']//*"));
            if (ctElements.Count != randomNumber)
            {
                Assert.Fail("N number of Elements are not generated");
            }

        }
    }
}

