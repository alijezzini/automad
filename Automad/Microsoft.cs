using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Automad
{
    public class Microsoft
    {
        String countrycode;
        String number;
        String pid;
        ChromeDriver driver;
        Main ott;
        public Microsoft(String countrycode, String number,Main ott)
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
                //chromeOptions.AddArgument("headless");
                chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                driver = new ChromeDriver(driverService,chromeOptions);
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters["source"] = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
                driver.ExecuteChromeCommand("Page.addScriptToEvaluateOnNewDocument", parameters);
                TimeSpan.FromSeconds(130);
                pid = driverService.ProcessId.ToString();
                String pass = mymethods.CreatePassword();

                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl("https://signup.live.com/signup");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(16));
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.sessionStorage.clear()");
                ((IJavaScriptExecutor)driver).ExecuteScript("return window.localStorage.clear()");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#phoneSwitch")));

                driver.FindElement(By.CssSelector("#phoneSwitch")).Click();
                IWebElement option = driver.FindElement(By.XPath("//select//option[contains(text(),'" + countrycode + "')]"));
                String text = option.Text;
                String[] arr = text.Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
                String countrytext = arr[0] + "‏" + "(" + "‎" + arr[1];
                SelectElement country = new SelectElement(driver.FindElement(By.Id("PhoneCountry")));
                country.SelectByText(countrytext);
                
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("MemberName"))).SendKeys(number);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("iSignupAction"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#PasswordTitle, #UsernameRecoverySpeedbumpTitle")));

                if (driver.FindElements(By.Id("UsernameRecoverySpeedbumpTitle")).Count > 0)
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("iSignupAction"))).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#PasswordTitle")));
                }

                int trials = 0;

                fillpass:
                 try
                    {
                    driver.FindElement(By.Id("PasswordInput")).SendKeys(pass);
                    }
                 catch {
                    if (trials < 5)
                    {
                        trials++;
                        Thread.Sleep(1000);
                        goto fillpass;
                        
                    }        
                }
                   

                 
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#iSignupAction"))).Click();
                Thread.Sleep(700);
                if (driver.FindElements(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[1]/div/div[3]/div[1]/div[5]/div/div/form/div[1]/div[2]/div[1]")).Count > 0)
                {
                    goto success;
                }
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
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#FirstName"))).SendKeys(name);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#LastName"))).SendKeys(mymethods.GenRandomLastName());
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#iSignupAction"))).Click();
                Thread.Sleep(1000);
                if(driver.FindElements(By.XPath("//label[contains(text(), 'Country/region')]")).Count > 0)
                { 

                    SelectElement day = new SelectElement(driver.FindElement(By.Name("BirthDay")));
                    String da = mymethods.RandNum(1, 25).ToString();
                    day.SelectByText(da);

                    SelectElement month = new SelectElement(driver.FindElement(By.Name("BirthMonth")));
                    int mon = mymethods.RandNum(1, 11);
                    month.SelectByIndex(mon);

                    if (driver.FindElements(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[1]/div[3]/div/div[1]/div[5]/div/div/form/div/div[4]/div[3]/div[3]/input")).Count > 0)
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[1]/div[3]/div/div[1]/div[5]/div/div/form/div/div[4]/div[3]/div[3]/input")).SendKeys(mymethods.RandNum(1960, 2000).ToString());
                    }
                    else if(driver.FindElements(By.Name("BirthYear")).Count > 0)
                    {
                        SelectElement year = new SelectElement(driver.FindElement(By.Name("BirthYear")));
                        String yea = mymethods.RandNum(1970, 2000).ToString();
                        year.SelectByValue(yea);
                    }
                    driver.FindElement(By.Id("iSignupAction")).Click();
                }
                success:
                Thread.Sleep(2000);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("verificationTitle")));
                
                try
                {
                    ott.Invoke(ott.incrementSucc);
                    ott.Invoke(ott.myDelegate);
                }
                catch { }
                //connection cxn = new connection();
                //cxn.sendresult(countrycode + number, "Microsoft");
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
    }
}
