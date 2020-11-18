using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\shoha\source\repos\SeleniumDemo\SeleniumDemo\bin\Debug\netcoreapp3.1");

            // This will open up the URL 
            driver.Url = "https://www.facebook.com/";
            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("YaronWeiss@gmail.com");
            IWebElement password = driver.FindElement(By.Id("pass"));
            password.SendKeys("koko");
            IWebElement login = driver.FindElement(By.Name("login"));
            login.Click();
            Thread.Sleep(2000);
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            //Save the screenshot
            image.SaveAsFile("C:/temp/Screenshot.png");
        }
    }
}
