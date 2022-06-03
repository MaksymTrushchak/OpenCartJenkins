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
            ChromeOptions chromeOptions = new ChromeOptions();



            //options.AddArgument("window-size=1920,1080");
            //options.AddArgument("start-maximized");
            //options.AddArgument("headless"); 
            //options.AddArgument("disable-gpu");
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("proxy-server='direct://'");
            //options.AddArgument("proxy-bypass-list=*");
           
            
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-setuid-sandbox");

            chromeOptions.AddArgument("--remote-debugging-port=9222"); 

            chromeOptions.AddArgument("--disable-dev-shm-using");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("user-data-dir=.\\cookies\\test");

           



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
