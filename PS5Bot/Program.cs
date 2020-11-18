using ImageProcessor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace PS5Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\shoha\source\repos\SeleniumDemo\PS5Bot\bin\Debug\netcoreapp3.1");
            //IWebDriver driver = new ChromeDriver(@"C:\Users\regl9\source\repos\SeleniumDemo\SeleniumDemo\bin\Debug\netcoreapp3.1");

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

            //string imagePath = @"C:\Users\regl9\source\repos\SeleniumDemo\imgs\Screenshot.png";
            string imagePath = @"C:\Temp\Screenshot.png";

            image.SaveAsFile(imagePath);

            byte[] photoBytes = File.ReadAllBytes(imagePath);
            if (image.AsByteArray.Equals(photoBytes))
            {
                driver.Url = "https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817";
            }
        }
    }
}
