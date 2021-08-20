using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NotesIntegrationTests
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private ChromeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            // Initialize edge driver 
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            _driver.Url = "https://localhost:44339";
            Assert.AreEqual("Home page - Notes", _driver.Title);
        }

        [TestMethod]
        public void NoteEditTextIsDisabledOnStartup()
        {
            // Replace with your own test logic
            _driver.Url = "https://localhost:44339";
            var noteEditTextArea = _driver.FindElementById("notes-edit-text");
            noteEditTextArea.SendKeys("Hello, World!");
            Assert.IsTrue(noteEditTextArea.Text == "");
        }



        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
