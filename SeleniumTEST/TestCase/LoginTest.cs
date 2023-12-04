using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTEST.Common;
using SeleniumTEST.Handler;
using SeleniumTEST.PageObject;
using SeleniumTEST.Reports;


namespace SeleniumTEST.TestCase
{
    [TestFixture]
    public class LoginTest 
    {
        

        protected IWebDriver Driver;

        protected Browser Browser { get; private set; }


        [SetUp]
        public void BeforeTest()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://profile.w3schools.com/log-in?redirect_url=https%3A%2F%2Fmy-learning.w3schools.com");

            Browser = new Browser(Driver);
        }
        //login commit success
        [Test]  
        public void successLoginTest()
        {
            ExtentReporting.LogInfo("Iniciando success test - Login test");
            LoginPattern login = new LoginPattern(Driver);

            UserPattern user = login.LoginAs("manuelt28605@gmail.com","Selenium123$");

  
        }
        //Usuario Credenciales Incorrectas
        [Test]
        public void FailLoginTestIncorrectsKeys()
        {
            ExtentReporting.LogInfo("Iniciando credenciales incorrectas test - Login test");

            LoginPattern login = new LoginPattern(Driver);

            UserPattern user = login.LoginAs("manuelt28605.com", "Selenium123");



        }
        //Credenciales no existentes o no registrado
        [Test]
        public void FailLoginTestKeysNonExisting()
        {
            ExtentReporting.LogInfo("Iniciand credenciales no registradas test - Login test");

            LoginPattern login = new LoginPattern(Driver);

            UserPattern user = login.LoginAs("manuelt@gmail.com", "Selenium123");

            

        }

        //Campos Vacios obligatorios 
        [Test]
        public void FailLoginTestKeysNone()
        {
            ExtentReporting.LogInfo("Iniciando campos vacios test - Login test");

            LoginPattern login = new LoginPattern(Driver);

            UserPattern user = login.LoginAs("", "");

           

        }

        //Show campos password
        [Test]
        public void LoginSHowNoShow()
        {
            ExtentReporting.LogInfo("Iniciando mostrar campo clave test - Login test");

            LoginPattern login = new LoginPattern(Driver);

            
            UserPattern user =  login.shownoshow("PruebaSHowNoShow");

           
        }


        [TearDown]
        public void AfterTest() 
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Passed)
            {
               
                ScreenShotHandler.TakeScreenshot(Driver);
            }

            if (Driver != null)
            {
                EndTest();
                ExtentReporting.EndReporting();
                Driver.Quit();
            }
        }



        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Skipped:
                    ExtentReporting.LogFail($"Test se ha salteado {message}");
                    break;
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test ha fallado {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenshot("Finalizando test", Browser.getScreenShot());
        }




    }
}
