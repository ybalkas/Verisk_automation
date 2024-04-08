using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow;
using SpecFlowProject3.Support;
using static System.Net.Mime.MediaTypeNames;
using SpecFlowProject3.Models;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Verisk_automation.StepDefinitions
{ 

    [Binding]
    public class VeriskTestsStepDefinitions
    {

        public IWebDriver driver;
        //IWebDriver driver = new ChromeDriver();
        public VeriskTestsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"the user is on the ""([^""]*)"" page")]
        public void GivenTheUserIsOnThePage(string url)
        {     
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, driver.Url);
        }

        [Given(@"User clicks Acceptall button")]
        public void GivenUserClicksAcceptallButton()
        {
            Utils.WaitForElementAndClick(driver, "//button[@id='onetrust-accept-btn-handler']", "xpath", 10);
        }

    [When(@"User fills the Contact us form")]
        public void WhenUserFillsTheContactUsForm(Table table)
        {
            Utils.SelectFromDropdownByGivenLocator(driver, "//select[@id='ebf2e33d-72da-4135-ab57-265f8fcc0cac']", "Other");
            var details = table.CreateInstance<ContactUsModel>();
            Utils.FillTheForm(details, driver);
            Utils.SelectFromDropdownByGivenLocator(driver, "//select[@id='033b3662-d537-456a-ae39-d815e0693c62']", "Reinsurer");
            Utils.WaitForElementAndClick(driver, "//button[@id='5567b197-cccf-4949-b5fb-b4e4508c142a']", "xpath", 10);
            //Thread.Sleep(10);
        }

        [Then(@"user should be able to see success message ""([^""]*)""")]
        public void ThenUserShouldBeAbleToSeeSuccessMessage(string confirmMessage)
        {
           string  actualMessage=Utils.GetTExtOfanElement(driver, "//*[@class='Form__Status']//p", "xpath");
            Assert.AreEqual(confirmMessage, actualMessage);
        }
    }
}
