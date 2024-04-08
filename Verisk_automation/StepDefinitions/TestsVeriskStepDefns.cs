using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SpecFlowProject3.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Verisk_automation.StepDefinitions
{
    internal class TestsVeriskStepDefns
    {
        public IWebDriver driver = new ChromeDriver();

        public TestsVeriskStepDefns(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"the user is on the ""([^""]*)"" dashboard")]
        public void GivenTheUserIsOnTheDashboard(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Assert.AreEqual(url, driver.Url);


        }

        [When(@"User clicks ""([^""]*)""")]
        public void WhenUserClicks(string company)
        {
            throw new PendingStepException();
        }
   
        [When(@"User fills the Contact us form")]
        public void WhenUserFillsTheContactUsForm(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"user should be able to see success message ""([^""]*)""")]
        public void ThenUserShouldBeAbleToSeeSuccessMessage(string p0)
        {
            throw new PendingStepException();
        }

    }
}
