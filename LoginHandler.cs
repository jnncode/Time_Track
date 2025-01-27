using OpenQA.Selenium;

namespace Time_Track {
    public class LoginHandler() {
        private const string twbURL = "https://arpwas.honeywell.com/twb";
        
        public void PerformLogin(IWebDriver driver) {
            try {
                DotNetEnv.Env.Load("C:/Users/sys1/source/repos/Time_Track/.env"); // Load environment variables from .env file

                string? username = Environment.GetEnvironmentVariable("USERNAME");
                string? password = Environment.GetEnvironmentVariable("PASSWORD");

                driver.Navigate().GoToUrl(twbURL);
                WebElement usernameInput = (WebElement)driver.FindElement(By.Id("sap-alias"));
                WebElement passwordInput = (WebElement)driver.FindElement(By.Id("sap-password"));

                usernameInput.SendKeys(username);
                passwordInput.SendKeys(password);
                WebElement loginButton = (WebElement)driver.FindElement(By.ClassName("MobileLoginStdBtn"));
                loginButton.Click();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}