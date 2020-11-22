using ImageProcessor;
using NAudio.Wave;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ServiceStack;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using TestStack.White.InputDevices;

namespace PS5Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver driver = new ChromeDriver(@"C:\Users\shoha\source\repos\SeleniumDemo\PS5Bot\bin\Debug\netcoreapp3.1");
            IWebDriver driver = new ChromeDriver(@"C:\Users\regl9\source\repos\SeleniumDemo\SeleniumDemo\bin\Debug\netcoreapp3.1");

            //string imagePath = @"C:\Temp\Screenshot.png";
            string imagePath = @"C:\Users\regl9\source\repos\SeleniumDemo\imgs\Screenshot.png";
            driver.Navigate().GoToUrl(@"https://www.bestbuy.com/site/sony-playstation-5-digital-edition-console/6430161.p?skuId=6430161");
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 250)");
            Thread.Sleep(1000);
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(imagePath);

            byte[] photoBytes = File.ReadAllBytes(imagePath);

            string audioFile = @"C:\Windows\Media\Alarm01.wav";
            var audio = new AudioFileReader(audioFile);
            var outputDevice = new WaveOutEvent();

            bool run = true;
            while (run)
            {
                //driver.Navigate().GoToUrl(@"https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817");
                driver.Navigate().GoToUrl(@"https://www.bestbuy.com/site/sony-playstation-5-digital-edition-console/6430161.p?skuId=6430161");
                Thread.Sleep(10000);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 250)");
                Thread.Sleep(1000);
                Screenshot image1 = ((ITakesScreenshot)driver).GetScreenshot();
                byte[] imageBytes = image1.AsByteArray;

                if (!areEqual(photoBytes, imageBytes))
                {
                    outputDevice.Init(audio);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(10000);
                        outputDevice.Stop();
                        run = false;
                    }
                    //Point point = Mouse.Instance.Curso;
                }
                Thread.Sleep(1000);
            }
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
