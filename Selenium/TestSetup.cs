using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    public class TestSetup
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setting up for each test - Opening Chrome");

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Maximize the Chrome window

            Driver = new ChromeDriver(options);

            // Set an implicit wait timeout
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tearing down for each test - Closing Chrome");
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }

        public void NavigateAndAssertUrl(string url)
        {
            if (Driver != null)
            {
                Driver.Navigate().GoToUrl(url);

                // Assert that the current URL is as expected
                Assert.AreEqual(url, Driver.Url);
            }
            else
            {
                Console.WriteLine("Driver is null. Navigation and assertion aborted.");
            }
        }

        // Helper method for clicking an element by ID
        public void ClickElementById(string elementId)
        {
            if (Driver != null)
            {
                IWebElement element = Driver.FindElement(By.Id(elementId));
                element.Click();
            }
            else
            {
                Console.WriteLine("Driver is null. Click operation aborted.");
            }
        }

        // Helper method to check if an element with a specific ID is visible
        public bool IsElementVisibleById(string elementId)
        {
            try
            {
                IWebElement element = Driver.FindElement(By.Id(elementId));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickOnProductInNavigation(string productName)
        {
            // Click on an <a> element with the specified text within the <ol> with class "s-navigation"
            IWebElement element = Driver.FindElement(By.XPath($"//ol[@class='s-navigation']//a[contains(text(), '{productName}')]"));
            element.Click();
        }


        public void sleep(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));

        }
}
}


