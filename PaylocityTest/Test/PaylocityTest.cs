using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PaylocityTest.Test
{
    public class PaylocityTest
    {

        IWebDriver driver;
        PaylocityPage userTest;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login");
            userTest = new PaylocityPage(driver);

        }
        [Test, Order(1)]
        public void Validatelogin()
        {

            Assert.AreEqual(driver.Title, "Log In - Paylocity Benefits Dashboard");
            userTest.Login();
        }

        [Test, Order(2)]

        public void addEmployee()
        {
         
            Assert.IsTrue(userTest.addEmployee("Diego", "Gutierrez"), "Employee added sucessfully");
        }

        [Test, Order(3)]
        public void UpdateEmployee()
        {
            Assert.IsTrue(userTest.updateEmployee("Test"), "Employee updated sucessfully");
        }

        [Test, Order(4)]
        public void removeEmployee() 
        {
            Assert.IsTrue(userTest.removeEmployee(), "Employee deleted sucessfully");
        }

        [TearDown]
        public void TearDown() {
            driver.Quit();
        }

        
    }
}
