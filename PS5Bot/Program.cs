using ImageProcessor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace PS5Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\regl9\source\repos\SeleniumDemo\SeleniumDemo\bin\Debug\netcoreapp3.1");

            // This will open up the URL 
            driver.Url = "https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817";
            //IWebElement email = driver.FindElement(By.Id("email"));
            //email.SendKeys("YaronWeiss@gmail.com");
            //IWebElement password = driver.FindElement(By.Id("pass"));
            //password.SendKeys("koko");
            //IWebElement login = driver.FindElement(By.Name("login"));
            //login.Click();
            Thread.Sleep(1000);
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            //Save the screenshot
            image.SaveAsFile(@"C:\Users\regl9\source\repos\SeleniumDemo\imgs\Screenshot.png");

            //ImageFactory Load(string imagePath);
        }
    }
}
