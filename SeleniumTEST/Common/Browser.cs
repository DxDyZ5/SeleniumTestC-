using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTEST.Common
{
    public class Browser
    {
        private IWebDriver driver;

        public Browser(IWebDriver driver)
        {
           this.driver = driver;
        }

        public string getScreenShot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;

            return img;
        } 
    }
}
