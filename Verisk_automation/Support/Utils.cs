using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using static System.Net.Mime.MediaTypeNames;
using SpecFlowProject3.Models;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Globalization;
using Microsoft.Win32;

namespace SpecFlowProject3.Support
{
    internal class Utils
    {

        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The text of an element.</param>

        public static void ClickElementByText(IWebDriver driver, string text)
        {
            // Find elements by XPath that contains the text
            driver.FindElement(By.XPath($"//*[text()='{text}']")).Click();
        }

        static Func<string, By> ReturnXPathIfTextGiven = (text) => By.XPath($"//*[text()='{text}']");

        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The XPath of the element to wait for and click.</param>
        /// <param name="timeoutInSeconds">The maximum time to wait in seconds.</param>
        public static void WaitForElementAndClick(IWebDriver driver, string text, string locatorType, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            switch (locatorType.ToLower())
            {
                case "textlocator":
                    wait.Until(ExpectedConditions.ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
                    break;
                case "idlocator":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(text))).Click();
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(text))).Click();
                    break;
                case "linktext":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(text))).Click();
                    break;
                case "cssSelector":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(text))).Click();
                    break;
                default:
                    throw new ArgumentException("Invalid locator type");
            }
           
        }
       
        public static void WaitForElementAndClick(IWebDriver driver, string text, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
        }
        //fills ContactUsForm form
        public static void FillTheForm(ContactUsModel contactUs, IWebDriver driver)
            {
            driver.FindElement(By.Id("c3d65aff-af7b-4496-aa59-65011b2a2914")).SendKeys(contactUs.firstName);
            driver.FindElement(By.Id("b866e49a-ba5f-41c1-bffc-cafc7e7e7fee")).SendKeys(contactUs.lastName);
            driver.FindElement(By.Id("33a8c375-9386-4c39-aa8b-4236bceb44ae")).SendKeys(contactUs.businessEmail);
            driver.FindElement(By.Id("f3e8fb71-4bd0-4b27-af2d-d1f2aec93909")).SendKeys(contactUs.businessPhone);
            driver.FindElement(By.Id("d6c214b8-683c-4b6c-a2d8-d58ea009a64e")).SendKeys(contactUs.company);
            driver.FindElement(By.Id("d0eec734-31d3-4036-87c3-3f7927a11214")).SendKeys(contactUs.comments);
        }
       
        /// <summary>
        /// Selects an option from a dropdown by visible text.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locatorText">locator text as XPath.</param>
        /// <param name="visibleText">The visible text of the option to be selected.</param>
        public static void SelectFromDropdownByGivenLocator(IWebDriver driver, string locatorText, string visibleText)
        {
            var select = new SelectElement(driver.FindElement(By.XPath(locatorText)));
            select.SelectByText(visibleText);
        }
      
        public static void ClickByHoverOverAndActions(IWebDriver driver,string xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathLocator)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
           // driver.FindElement(By.XPath(xpathLocator)).Click();
        }
        /// Checks whether given list sorted or not
        /// <param name="webelements">The WebElements List</param>
        /// <param name="sortType">Sort type either OldestToNewest or NewetstoOldest</param>

        public static string GetTExtOfanElement(IWebDriver driver, string locator, string locatorType)
        {
           string txt;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            switch (locatorType.ToLower())
            {
                case "textlocator":
                   txt= driver.FindElement(ReturnXPathIfTextGiven(locator)).Text;
                    break;
                case "idlocator":
                    txt = driver.FindElement(By.Id(locator)).Text;
                    break;
                case "xpath":
                    txt = driver.FindElement(By.XPath(locator)).Text;
                    break;
                case "linktext":
                    txt = driver.FindElement(By.LinkText(locator)).Text;
                    break;
                case "cssSelector":
                    txt = driver.FindElement(By.CssSelector(locator)).Text;
                    break;
                default:
                    throw new ArgumentException("Invalid locator type");
            }
            return txt;
        }
    }
}
       

