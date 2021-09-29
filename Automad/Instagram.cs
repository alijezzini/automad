using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Automad
{
    public class Instagram
    {
        String countrycode;
        String number;
        String pid;
        ChromeDriver driver;
        Main ott;

        public Instagram(String countrycode, String number, Main ott)
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
            try {

                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                ChromeOptions chromeOptions = new ChromeOptions();

                String agent = mymethods.RandomAgent();
                chromeOptions.AddArgument("--window-size=900,700");
                chromeOptions.AddArgument("--user-agent=" + agent);

                chromeOptions.AddArgument("--ignore-certificate-errors");
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (ott.cache)
                {
                    chromeOptions.AddArguments("user-data-dir=" + path + "\\Profiles\\Profile " + pp);
                }
                //chromeOptions.AddArgument("headless");
                //chromeOptions.AddArgument("--proxy-server= http://192.241.74.244:2935");
                //chromeOptions.AddExtension(@"proxauth.crx");
                String proxy = ott.proxyport;
                if (!proxy.Equals("null"))
                {
                    chromeOptions.AddArgument("--proxy-server= http://" + proxy);
                }
                chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
                
                chromeOptions.AddExcludedArgument("enable-automation");
                chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                
                driver = new ChromeDriver(driverService,chromeOptions);
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["source"] = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
                driver.ExecuteChromeCommand("Page.addScriptToEvaluateOnNewDocument", parameters);
                TimeSpan.FromSeconds(130);
                pid = driverService.ProcessId.ToString();

                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                driver.Navigate().GoToUrl("https://www.instagram.com/accounts/emailsignup/");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.sessionStorage.clear()");
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.localStorage.clear()");


                int sex = mymethods.RandNum(0, 10);
                String name = "";
                if (sex < 5)
                {
                    name = mymethods.GenRandomFemaleName();
                }
                else if (sex >= 5)
                {
                    name = mymethods.GenRandomMaleName();
                }
                String lastname = mymethods.GenRandomLastName();
                Thread.Sleep(300);
                if (driver.FindElements(By.XPath("/html/body/div[2]/div/div/div/div[2]/button[1]")).Count>0)
                {
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/button[1]")).Click();
                }
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("emailOrPhone")));
                driver.FindElement(By.Name("emailOrPhone")).SendKeys("" + countrycode + number);
                driver.FindElement(By.Name("fullName")).SendKeys(name + " " + lastname);
                driver.FindElement(By.Name("username")).SendKeys(name + randString(4) + lastname + randString(4));
                driver.FindElement(By.Name("password")).SendKeys(mymethods.CreatePassword());
                Thread.Sleep(1000);
                if (driver.FindElements(By.CssSelector("#react-root > section > main > div > div > div > div:nth-child(1) > div > form > div:nth-child(6) > div > div > div > button > span")).Count > 0)
                {
                    driver.FindElement(By.CssSelector("#react-root > section > main > div > div > div > div:nth-child(1) > div > form > div:nth-child(6) > div > div > div > button > span")).Click();
                }
                Thread.Sleep(500);
                if (driver.FindElements(By.XPath("//button[contains(text(),'Sign up')]")).Count > 0)
                {
                    driver.FindElement(By.XPath("//button[contains(text(),'Sign up')]")).Click();
                }
                else
                {
                    driver.FindElement(By.XPath("//button[contains(text(),'Next')]")).Click();
                }
                
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//select[@title='Year:']")));
                int day = mymethods.RandNum(1, 25);
                int month = mymethods.RandNum(1, 11);
                String year = mymethods.RandNum(1970, 2000).ToString();
                SelectElement syear = new SelectElement(driver.FindElementByXPath("//select[@title='Year:']"));
                SelectElement sday = new SelectElement(driver.FindElementByXPath("//select[@title='Day:']"));
                SelectElement smonth = new SelectElement(driver.FindElementByXPath("//select[@title='Month:']"));
                Thread.Sleep(500);
                syear.SelectByValue(year);
               
               // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#react-root > section > main > div > div > div > div:nth-child(1) > div > div.Igw0E.IwRSH.eGOV_._4EzTm.bkEs3.DhRcB > div > div > span > span:nth-child(1) > select > option[value='" + month + "']")));
                Thread.Sleep(500);
                smonth.SelectByIndex(month);
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#react-root > section > main > div > div > div > div:nth-child(1) > div > div.Igw0E.IwRSH.eGOV_._4EzTm.bkEs3.DhRcB > div > div > span > span:nth-child(2) > select > option[value='" + day + "']")));
                Thread.Sleep(500);
                sday.SelectByIndex(day);

                Thread.Sleep(500);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'Next')]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Enter the 6-digit code we sent to:')]")));
                Thread.Sleep(1000);
                try
                {
                    ott.Invoke(ott.incrementSucc);
                    ott.Invoke(ott.myDelegate);
                }
                catch { }
                //connection cxn = new connection();
                //cxn.sendresult(countrycode + number, "Instagram");
                
                ott.ReleaseProfile(pp);
                driver.Quit();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                /*int id = Int32.Parse(pid);
                Process proc = Process.GetProcessById(id);
                proc.Kill();*/
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

        static String randString(int size)
        {

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 1; i < size + 1; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
