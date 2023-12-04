using OpenQA.Selenium;
using SeleniumTEST.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTEST.PageObject
{
    public class UserPattern
    {
        protected IWebDriver Driver;


        protected By navbar = By.CssSelector(".LoginModal_modal_inner__zNxJo");

        public UserPattern(IWebDriver driver)
        {
            Driver = driver;

            if (!Driver.Title.Equals("W3Schools Online Web Tutorials"))
                throw new Exception("This is not the main page");

        }

        
    }
}
