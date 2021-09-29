using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Automad
{
    public class Lark
    {
        String countrycode;
        String number;
        String pid;
        ChromeDriver driver;
        Main ott;
        public Lark(String countrycode, String number,Main ott)
        {
            this.countrycode = countrycode;
            this.number = number;
            this.ott = ott;
        }
        public void run(object state)
        {
            AppDomain.CurrentDomain.UnhandledException += new
             UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Thread.Sleep(mymethods.RandNum(10, 500));
            int pp = ott.getProfile();
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                ChromeOptions chromeOptions = new ChromeOptions();
                String agent = mymethods.RandomAgent();
                //chromeOptions.AddArgument("--user-agent=" + agent);
                chromeOptions.AddArgument("--window-size=900,700");
                String proxy = ott.proxyport;
                if (!proxy.Equals("null"))
                {
                    chromeOptions.AddArgument("--proxy-server= http://" + proxy);
                }
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (ott.cache)
                {
                    chromeOptions.AddArguments("user-data-dir=" + path + "\\Profiles\\Profile " + pp);
                }
                chromeOptions.AddExcludedArgument("enable-automation");
                chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
                chromeOptions.AddArgument("headless");
                chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                driver = new ChromeDriver(driverService, chromeOptions);
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["source"] = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
                driver.ExecuteChromeCommand("Page.addScriptToEvaluateOnNewDocument", parameters);
                TimeSpan.FromSeconds(130);
                pid = driverService.ProcessId.ToString();
                String pass = mymethods.CreatePassword();

                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl("https://passport.larksuite.com/create/?redirect_uri=https%3A%2F%2Fwww.larksuite.com%2Fmessenger%2F&app_id=1");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.sessionStorage.clear()");
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.localStorage.clear()");

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[4]/div[1]/div[1]/div/div/div/div/div[3]/div[1]/div[2]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[4]/div[1]/div[1]/div/div/div/div/div[3]/div[2]/div[2]/div/div/div[1]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'" + countrycode + "')]/.."))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("register_phone"))).SendKeys(number);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div[1]/div[1]/div/div/div/div/div[5]")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div[1]/div[1]/div/div/div/div/div[4]")).Click();
                
                Thread.Sleep(2000);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Check your phone')]/..")));

                try
                {
                    ott.Invoke(ott.incrementSucc);
                    ott.Invoke(ott.myDelegate);
                }
                catch { }
                //connection cxn = new connection();
                //cxn.sendresult(countrycode + number, "ExpressWifi");
                
                ott.ReleaseProfile(pp);
                driver.Quit();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                if (e.Message.Equals("invalid argument: user data directory is already in use, please specify a unique value for --user-data-dir argument, or don't use --user-data-dir"))
                {
                    pp = pp * 7;
                }
                try
                {
                    ott.Invoke(ott.myDelegate);
                    ott.ReleaseProfile(pp);
                }
                catch { }
                try
                {
                    driver.Quit();
                    
                }
                catch
                {

                }
            }
         

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
