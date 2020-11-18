using ImageProcessor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
            //driver.Url = "https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817";
            driver.Url = "https://direct.playstation.com/en-us/consoles/console/";
            //Thread.Sleep(1000);

            //string imagePath = @"C:\Users\regl9\source\repos\SeleniumDemo\imgs\Screenshot.png";
            string imagePath = @"C:\Temp\Screenshot.png";
            //image.SaveAsFile(imagePath);
            byte[] photoBytes = File.ReadAllBytes(imagePath);

            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] imageBytes = image.AsByteArray;

            if (!areEqual(photoBytes, imageBytes))
            {
                // Make a sound
                //driver.Url = "https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817";
            }
            IWebElement email = driver.FindElement(By.Id("rc-anchor-alert"));
            IWebElement button = driver.FindElement(By.XPath("/html/body/div[1]/div/img"));

            button.Click();
        }
        static bool areEqual(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
