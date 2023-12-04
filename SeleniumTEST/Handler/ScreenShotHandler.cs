using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTEST.Handler
{
    public class ScreenShotHandler
    {
        private static string ImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


        public static string TakeScreenshot(IWebDriver driver)
        {
            long   miliseconds =   DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            string imagePath = ImagePath + "//img_" + miliseconds + ".png";

            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();

            image.SaveAsFile(imagePath, ScreenshotImageFormat.Png);

            return imagePath;
        }
    }
}
