using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimplyStreet
{
    public class Class1
    {
        public IWebDriver driver;
        [Test]
        public void NavigateAndSetupAccount()
        {
            driver = new ChromeDriver(@"C:\Users\Tummy Mumma\Documents\webdriver");
            driver.Navigate().GoToUrl("https://simplywall.st/welcome");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("button[data-cy-id='button-email-login']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[data-cy-id='button-register']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Thread.Sleep(2000);
            EnterEmail();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SetPassword();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ClickSubmit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Thread.Sleep(2000);
            EnterFirstName();
            Thread.Sleep(2000);
            ClickSubmit();
            Thread.Sleep(1000);
            ClickNext();
        }

        public async void EnterEmail()
        {
            var email = driver.FindElement(By.CssSelector("input[name='emailAddress']"));
            await Task.Run(() => email.Click());
            email.SendKeys("kumarvenkata2+" + RandomNumber() + "@gmail.com");
        }

        public int RandomNumber()
        {
            Random number = new Random();
            return number.Next();
        }

        public async void SetPassword()
        {
            var password = driver.FindElement(By.CssSelector("[name='password']"));
            await Task.Run(() => password.Click());
            password.SendKeys("IntelligentInvestors12345");
        }

        public async void ClickSubmit()
        {
            var submit = driver.FindElement(By.CssSelector("[type='submit']"));
            await Task.Run(() => submit.Click());
        }

        public async void EnterFirstName()
        {
            var firstname = driver.FindElement(By.CssSelector("input[data-cy-id='firstname']"));
            await Task.Run(() => firstname.SendKeys("myname"));
        }

        public void ClickNext()
        {
            var next = driver.FindElement(By.CssSelector("[data-cy-id='next']"));
            for (int i = 0; i <= 3; i++)
            {
                if (next.Displayed)
                {
                    next.Click();
                }
                else
                {
                    var finish = driver.FindElement(By.CssSelector("[data-cy-id='finish']"));
                    if (finish.Displayed)
                    {
                        finish.Click();
                    }
                }
            }
        }
    }
}
