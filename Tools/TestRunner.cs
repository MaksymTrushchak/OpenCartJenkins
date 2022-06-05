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
           
            
          
         
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized"); 
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions"); 
            options.AddArguments("--disable-gpu"); 
            options.AddArguments("--disable-dev-shm-usage"); 
            options.AddArguments("--no-sandbox"); 
            options.AddArgument("headless");





            driver = new ChromeDriver("chromedriver/", options);
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
