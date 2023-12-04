using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTEST.Handler;
using SeleniumTEST.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTEST.PageObject
{
    public class LoginPattern
    {
        protected IWebDriver Driver;

        protected By UserInput = By.Id("modalusername");

        protected By PasswordInput = By.Id("current-password");

        protected By ButtonInput = By.CssSelector("button");

        protected By ShowNoShow = By.CssSelector(".PasswordInput_show_pwd_btn__Ncc9S");

        protected By buttologin = By.CssSelector(".user-anonymous");

        protected By div = By.CssSelector(".LoginModal_modal_inner__zNxJo");






        public LoginPattern(IWebDriver driver)
        {
            Driver = driver;

            if (!Driver.Title.Equals("Log in - W3Schools"))
                throw new Exception("This is not the login page");

        }

        public void TyperUserName(string username)
        {
            Driver.FindElement(UserInput).SendKeys(username);
        }

        public void TyperPassword(string password)
        {
            Driver.FindElement(PasswordInput).SendKeys(password);
        }

       
        public void TyperButton()
        {
            Driver.FindElement(ButtonInput).Click();
        }

        public void TyperSpan()
        {
            Driver.FindElement(ShowNoShow).Click();
        }

        public void TyperButtonLogin()
        {
            Driver.FindElement(buttologin).Click();
        }


        public UserPattern LoginAs(string username, string password)
        {
            ExtentReporting.LogInfo("Inserte usuario y clave");

            TyperUserName(username);

            TyperPassword(password);

            TyperButton();

            return new UserPattern(Driver);
        }


        public UserPattern shownoshow( string password)
        {
            ExtentReporting.LogInfo("Inserte clave");

            TyperSpan();

            TyperPassword(password);

            TyperSpan();

            TyperButton();

            return new UserPattern(Driver);
        }

        public bool FormIsPresent()
        {
            return WaitHandler.ElementIsPresent(Driver, div);
        }



    }
}
