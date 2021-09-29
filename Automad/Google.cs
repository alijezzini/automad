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
    public class Google
    {
        String countrycode;
        String number;
        String pid;
        ChromeDriver driver;
        Main ott;
        public Google(String countrycode, String number, Main ott)
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
                chromeOptions.AddArgument("--user-agent=" + agent);
                /*chromeOptions.AddArgument("headless");*/
                chromeOptions.AddArgument("--window-size=900,700");
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (ott.cache)
                {
                    chromeOptions.AddArguments("user-data-dir=" + path + "\\Profiles\\Profile " + pp);
                }
                chromeOptions.AddExcludedArgument("enable-automation");
                chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
                String proxy = ott.proxyport;
                if (!proxy.Equals("null"))
                {
                    chromeOptions.AddArgument("--proxy-server= http://" + proxy);
                }
                chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                driver = new ChromeDriver(driverService,chromeOptions);
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["source"] = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
                driver.ExecuteChromeCommand("Page.addScriptToEvaluateOnNewDocument", parameters);
                TimeSpan.FromSeconds(130);
                pid = driverService.ProcessId.ToString();

                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl("https://accounts.google.com/signup/v2?flowName=GlifWebSignIn&flowEntry=SignUp&hl=en");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                
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
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("firstName")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("firstName")));
                driver.FindElement(By.Id("firstName")).Click();
                driver.FindElement(By.Id("firstName")).SendKeys(name);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("lastName")));
                driver.FindElement(By.Id("lastName")).SendKeys(lastname);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("username")));
                String username = getAlphaNumericString(3) +name+ lastname + getAlphaNumericString(4);
                driver.FindElement(By.Id("username")).Click();
                driver.FindElement (By.Id("username")).SendKeys(username);
                String pass = mymethods.CreatePassword();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("Passwd")));
                driver.FindElement(By.Name("Passwd")).Click();
                driver.FindElement(By.Name("Passwd")).SendKeys(pass);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("ConfirmPasswd")));
                driver.FindElement(By.Name("ConfirmPasswd")).Click();
                driver.FindElement (By.Name("ConfirmPasswd")).SendKeys(pass);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("accountDetailsNext"))).Click();
                Thread.Sleep(2000);
                if (driver.FindElements(By.XPath("//h1[contains(text(), 'create a Google Account')]")).Count > 0)
                {
                    throw new Exception("Blocked");
                }
                //form > div.mbekbe.bxPAYd > div > div.lqByzd.OcVpRe > div > div.rFrNMe.RSJo4e.uIZQNc.og3oZc.zKHdkd.sdJrJc.Tyc9J.CDELXb.k0tWj.IYewr > div.LXRPh > div.dEOOab.RxsGPe
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.ANuIbb.IdAqtf")));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div[2]/form/div[2]/div/div[1]/div/div[2]/div[1]/div/div[1]/input")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("phoneNumberId"))).SendKeys(countrycode + " " + number);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#view_container > div > div > div.pwWryf.bxPAYd > div > div.zQJV3 > div > div.qhFLie > div > div")));
                driver.FindElement (By.CssSelector("#view_container > div > div > div.pwWryf.bxPAYd > div > div.zQJV3 > div > div.qhFLie > div > div")).Click();
                Thread.Sleep(1000);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[2]/div/div[1]/div/span[contains(text(),'G-')]")));

                
                try
                {
                    ott.Invoke(ott.incrementSucc);
                    ott.Invoke(ott.myDelegate);
                    
                }
                catch { }
                //connection cxn = new connection();
                //cxn.sendresult(countrycode + number, "Google");
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

        static String getAlphaNumericString(int size)
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
