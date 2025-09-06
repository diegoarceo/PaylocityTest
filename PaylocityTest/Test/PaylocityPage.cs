using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaylocityTest.Test
{
    public class PaylocityPage
    {
        
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        string URL = "https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login";

        public PaylocityPage(IWebDriver driver)
        {
              this.driver = driver;
              wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            

        }


        private IWebElement Username => driver.FindElement(By.Id("Username"));
        private IWebElement Password => driver.FindElement(By.Id("Password"));
        private IWebElement Button => driver.FindElement(By.XPath("//button[contains(@class,'btn btn-primary')]"));
        private IWebElement AddEmployee => driver.FindElement(By.Id("add"));
        private IWebElement FirstName => driver.FindElement(By.Id("firstName"));
        private IWebElement LastName => driver.FindElement(By.Id("lastName"));
        private IWebElement Dependents => driver.FindElement(By.Id("dependants"));
        private IWebElement AddButton => driver.FindElement(By.Id("addEmployee"));
        private IWebElement DeleteButton => driver.FindElement(By.Id("deleteEmployee"));
        private IWebElement UpdateButton => driver.FindElement(By.Id("updateEmployee"));

        public void Login()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Username)).SendKeys("TestUser797");
            Username.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Password)).SendKeys("T$}nelDL8k#Q");
            Password.Click();   
            Button.Click();
        }

        public bool addEmployee(string Name, string LasName)
        {
            Login();
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(AddEmployee)).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(FirstName)).SendKeys(Name);
                wait.Until(ExpectedConditions.ElementToBeClickable(LastName)).SendKeys(LasName);
                wait.Until(ExpectedConditions.ElementToBeClickable(Dependents)).SendKeys("1");
                AddButton.Click();
               
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User was not added" + ex.Message);
                return false;
            }
            


        }
        public bool removeEmployee() {
            Login();
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"employeesTable\"]/tbody")));
                IWebElement targetElement = driver.FindElement(By.XPath(
                        $"//table[@id='employeesTable']//tr[td[contains(text(),'Diego')]]//i[contains(@class,'fa-times')]"));
                wait.Until(ExpectedConditions.ElementToBeClickable(targetElement)).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(DeleteButton)).Click();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        public bool updateEmployee(string updateName) {
            Login();
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"employeesTable\"]/tbody")));
                IWebElement targetElement = driver.FindElement(By.XPath(
                    $"//table[@id='employeesTable']//tr[td[contains(text(),'Diego')]]//i[contains(@class,'fa-edit')]"));
                wait.Until(ExpectedConditions.ElementToBeClickable(targetElement)).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(FirstName)).SendKeys(updateName);
                UpdateButton.Click();
                return true;
                
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

    }
}
