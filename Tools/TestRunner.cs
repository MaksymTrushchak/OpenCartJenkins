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
           
            
          
           // System.SetProperty("webdriver.chrome.driver", "C:\\path\\to\\chromedriver.exe");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized"); // open Browser in maximized mode
            options.AddArguments("disable-infobars"); // disabling infobars
            options.AddArguments("--disable-extensions"); // disabling extensions
            options.AddArguments("--disable-gpu"); // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
            options.AddArguments("--no-sandbox"); // Bypass OS security model
          
           




            driver = new ChromeDriver(options);
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
