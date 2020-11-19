using ImageProcessor;
using NAudio.Wave;
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

            string imagePath = @"C:\Temp\Screenshot.png";
            //string imagePath = @"C:\Users\regl9\source\repos\SeleniumDemo\imgs\Screenshot.png";

            //image.SaveAsFile(imagePath);

            byte[] photoBytes = File.ReadAllBytes(imagePath);

            string audioFile = @"C:\Users\shoha\Music\Video Projects\Madcon - beggin lyrics.mp3";
            var audio = new AudioFileReader(audioFile);
            var outputDevice = new WaveOutEvent();

            bool run = true;
            while (run)
            {
                driver.Navigate().GoToUrl(@"https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817");
                Thread.Sleep(1000);
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                byte[] imageBytes = image.AsByteArray;

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
