using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Automad
{
    public class Transfergo
    {
        String countrycode;
        String number;
        String pid;
        ChromeDriver driver;
        Main ott;
        public Transfergo(String countrycode, String number,Main ott)
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
                String countryname = "";
                switch (countrycode)
                {
                    case "+62": countryname = "ID"; break;
                    case "+965": countryname = "KW"; break;
                    case "+962": countryname = "JO"; break;
                    case "+234": countryname = "NG"; break;
                    case "+233": countryname = "GH"; break;
                    case "+961": countryname = "LB"; break;
                    case "+213": countryname = "DZ"; break;
                    case "+976": countryname = "MN"; break;
                    case "+966": countryname = "SA"; break;
                    case "+380": countryname = "UA"; break;
                    default: countryname = "US"; break;
                }
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
                /*              chromeOptions.AddArgument("headless");*/
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
                driver.Navigate().GoToUrl("https://my.transfergo.com/en/user/welcome");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.sessionStorage.clear()");
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.localStorage.clear()");
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//iframe")));
                //IWebElement iframe = driver.FindElement(By.XPath("/html/head/iframe"));
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//select[@name='phoneCountry']")).Click();
                IWebElement option = driver.FindElement(By.XPath("//select//option[contains(text(),'" + countrycode + "')]"));
                String text = option.Text;
                SelectElement country = new SelectElement(driver.FindElement(By.Name("phoneCountry")));
                country.SelectByText(text);
                driver.FindElement(By.XPath("//input[@name='phoneNumber']")).Clear();
                driver.FindElement(By.XPath("//input[@name='phoneNumber']")).SendKeys(number);
                driver.FindElement(By.XPath("//button")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#React > div > div > div > div.content-wrapper > div > h1"));



                
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
                /*                int id = Int32.Parse(pid);
                                Process proc = Process.GetProcessById(id);
                                proc.Kill();*/
            }
         

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
