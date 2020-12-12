using ImageProcessor;
using NAudio.Wave;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.InputDevices;

namespace PS5Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of Bots
            List<IWebDriver> drivers = new List<IWebDriver>();

            Parallel.ForEach(drivers, (driver) =>
            {

            });

            IWebDriver driver = new ChromeDriver(@"C:\Users\shoha\source\repos\SeleniumDemo\PS5Bot\bin\Debug\netcoreapp3.1");
            //IWebDriver driver = new ChromeDriver(@"C:\Users\regl9\source\repos\SeleniumDemo\SeleniumDemo\bin\Debug\netcoreapp3.1");

            //string imagePath = @"C:\Temp\Screenshot.png";
            //string imagePath = @"C:\Users\regl9\source\repos\SeleniumDemo\imgs\Screenshot.png";
            //string imagePath1 = @"C:\Users\regl9\source\repos\SeleniumDemo\imgs\imgs1\Screenshot.png";
            //Screenshot image = scrollAndScreenshot(driver);
            //image = scrollAndScreenshot(driver);
            //image.SaveAsFile(imagePath);

            //byte[] photoBytes = File.ReadAllBytes(imagePath); //load from file

            string audioFile = @"C:\Windows\Media\Alarm01.wav";
            //string audioFile = @"C:\Users\shoha\Music\Video Projects\Madcon - beggin lyrics.mp3";
            var outputDevice = new WaveOutEvent();

            bool run = true;
            while (run)
            {
                //driver.Navigate().GoToUrl(@"https://www.bestbuy.com/site/sony-playstation-5-digital-edition-console/6430161.p?skuId=6430161");
                driver.Navigate().GoToUrl(@"https://www.target.com/p/playstation-5-digital-edition-console/-/A-81114596#lnk=sametab");                
                Thread.Sleep(3000);
                //IWebElement button = driver.FindElement(By.XPath("/html/body/div[3]/main/div[2]/div[3]/div[2]/div/div/div[8]/div[1]/div/div/div/button"));
                IWebElement button = driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div/div[2]/div[3]/div[1]/div/div[1]/div/div[1]"));
                string buttontext = button.Text;
                string buttonchecktext = "Out of stock in stores near you";
                while (!(buttontext == "Out of stock in stores near you"))
                {
                    var audio = new AudioFileReader(audioFile);
                    outputDevice.Init(audio);
                    outputDevice.Play();
                    Thread.Sleep(3000);
                    outputDevice.Stop();
                }
                //driver.Navigate().GoToUrl(@"https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817");
                //Screenshot image1 = scrollAndScreenshot(driver);
                //image1.SaveAsFile(imagePath1);
                //byte[] imageBytes = image1.AsByteArray;

                //if (!AreEqual(photoBytes, imageBytes))
                //{
                //    outputDevice.Init(audio);
                //    outputDevice.Play();
                //    while (outputDevice.PlaybackState == PlaybackState.Playing)
                //    {
                //        Thread.Sleep(10000);
                //        outputDevice.Stop();
                //        run = false;
                //    }

                //    //Point point = Mouse.Instance.Curso;
                //}
                   Thread.Sleep(1000);
            }
        }
        static bool AreEqual(byte[] a, byte[] b)
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

        static Screenshot scrollAndScreenshot(IWebDriver driver)
        {
            //driver.Navigate().GoToUrl(@"https://www.bestbuy.com/site/sony-playstation-5-digital-edition-console/6430161.p?skuId=6430161");
            driver.Navigate().GoToUrl(@"https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817");

            Thread.Sleep(3000);
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 250)");
            //Thread.Sleep(10000);
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            return image;
        }
    }
}
