using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace OpencartTesting.Tools
{
    public abstract class TestRunner
    {
        protected WebDriver driver;
        protected abstract string OpenCartURL { get; }
        
        [SetUp]
        public void BeforeEachMethod()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("window-size=1920,1080");
            options.AddArgument("start-maximized");
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");

            driver = new ChromeDriver();
            /*
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            */
            driver.Navigate().GoToUrl(OpenCartURL);
           
            }
       
        [TearDown]
        public void AfterEachMethod() 
        {
            driver.Close();
            driver.Quit();
        }
    }
}
