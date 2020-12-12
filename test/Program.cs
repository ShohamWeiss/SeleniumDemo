using ImageProcessor;
using NAudio.Wave;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TestStack.White.InputDevices;

namespace PS5Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\shoha\source\repos\SeleniumDemo\test\bin\Debug"); // Shoham
            string savedImagePath = @"C:\Temp\Screenshot.png"; // Shoham

            //IWebDriver driver = new ChromeDriver(@"C:\Users\regl9\source\repos\SeleniumDemo\SeleniumDemo\bin\Debug\netcoreapp3.1"); // Regis
            //string imagePath = @"C:\Users\regl9\source\repos\SeleniumDemo\imgs\Screenshot.png"; // Regis

            string audioFile = @"C:\Windows\Media\Alarm01.wav"; // Set up alarm
            var audio = new AudioFileReader(audioFile);
            var outputDevice = new WaveOutEvent();

            //****//For taking the screenshot the first time
            //driver.Navigate().GoToUrl(@"https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817");
            //Thread.Sleep(1000);
            //Screenshot imageToSave = ((ITakesScreenshot)driver).GetScreenshot();
            //Bitmap img = Image.FromStream(new MemoryStream(imageToSave.AsByteArray)) as Bitmap;
            //img.Save(savedImagePath);
            //****//            

            Bitmap savedImage = (Bitmap)Bitmap.FromFile(savedImagePath);
            List<bool> savedImageList = GetHash(savedImage);
            byte[] savedImageBytes = File.ReadAllBytes(savedImagePath); // Read in saved screenshot

            bool run = true;
            while (run)
            {
                driver.Navigate().GoToUrl(@"https://direct.playstation.com/en-us/consoles/console/playstation5-digital-edition-console.3005817");
                Thread.Sleep(1000);
                Screenshot currentImage = ((ITakesScreenshot)driver).GetScreenshot();
                Bitmap currentBitmap = Image.FromStream(new MemoryStream(currentImage.AsByteArray)) as Bitmap;
                List<bool> currentImageList = GetHash(currentBitmap);

                if (!savedImageList.SequenceEqual(currentImageList))
                {
                    outputDevice.Init(audio);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(10000); // Alarm will play for 10 seconds
                        outputDevice.Stop();
                        run = false;
                    }
                }
            }
        }
        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }
    }
}
