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
    public class Naver
    {
        String countrycode;
        String number;
        String pid;
        ChromeDriver driver;
        Main ott;
        public Naver(String countrycode, String number,Main ott)
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
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (ott.cache)
                {
                    chromeOptions.AddArguments("user-data-dir=" + path + "\\Profiles\\Profile " + pp);
                }
                chromeOptions.AddArgument("--user-agent=" + agent);
                chromeOptions.AddArgument("headless");
                //chromeOptions.AddArguments("--incognito");
                String proxy = ott.proxyport;
                if (!proxy.Equals("null"))
                {
                    chromeOptions.AddArgument("--proxy-server= http://"+proxy);
                }
                

                chromeOptions.AddExcludedArgument("enable-automation");
               chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 1);
                /*              chromeOptions.AddArgument("headless");*/
                chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                driver = new ChromeDriver(driverService,chromeOptions);
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["source"] = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
                driver.ExecuteChromeCommand("Page.addScriptToEvaluateOnNewDocument", parameters);
                TimeSpan.FromSeconds(130);
                pid = driverService.ProcessId.ToString();
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(80);
                driver.Navigate().GoToUrl("https://nid.naver.com/user2/V2Join.nhn?m=agree");
                driver.Manage().Cookies.DeleteAllCookies();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
                Thread.Sleep(2000);

                ((IJavaScriptExecutor)driver).ExecuteScript("return window.sessionStorage.clear()");
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.localStorage.clear()");

                int sex = mymethods.RandNum(0, 10);
                String name = "";
                String genderVal = "";
                if (sex < 5)
                {
                    name = mymethods.GenRandomFemaleName()+mymethods.GenRandomLastName();
                    genderVal = "F";
                }
                else if (sex >= 5)
                {
                    name = mymethods.GenRandomMaleName()+ mymethods.GenRandomLastName();
                    genderVal = "M";
                }
                String password = mymethods.CreatePassword();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[3]/div/div/div/form/div[1]/p/span/label/span"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[3]/div/div/div/form/div[2]/span[2]/a"))).Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[1]/div[1]/span[1]/input"))).SendKeys(getAlphaNumericString(10).ToLower());
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[1]/div[2]/span[1]/input"))).SendKeys(password);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[1]/div[2]/span[3]/input"))).SendKeys(password);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[2]/div[1]/span[1]/input"))).SendKeys(name);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[2]/div[2]/div/div[1]/span/input"))).SendKeys(""+mymethods.RandNum(1960,1999));
                var month = new SelectElement(driver.FindElement(By.Id("mm")));
                month.SelectByIndex(mymethods.RandNum(2, 13));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[2]/div[2]/div/div[3]/span/input"))).SendKeys("" + mymethods.RandNum(1, 26));
                var gender = new SelectElement(driver.FindElement(By.Id("gender")));
                gender.SelectByValue(genderVal);

                var code = new SelectElement(driver.FindElement(By.Id("nationNo")));
                code.SelectByValue(countrycode.Substring(1));

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[3]/div[2]/span/input"))).SendKeys(number);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[3]/div[2]/a"))).Click();
                Thread.Sleep(2000);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/form[1]/div/div/div/div[3]/span[1]")));
                


                try
                {
                    ott.Invoke(ott.incrementSucc);
                    ott.Invoke(ott.myDelegate);
                }
                catch { }
                //connection cxn = new connection();
                //cxn.sendresult(countrycode + number, "Tinder");
                

                ott.ReleaseProfile(pp);
                driver.Quit();
            }
            
            catch(Exception e)
            {
                if (e.Message.Equals("invalid argument: user data directory is already in use, please specify a unique value for --user-data-dir argument, or don't use --user-data-dir"))
                {
                    pp = pp * 7;
                }
                /*int id = Int32.Parse(pid);
                Process proc = Process.GetProcessById(id);
                proc.Kill();*/
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
