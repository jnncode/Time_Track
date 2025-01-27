using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Time_Track {
    public class DriverManager {
        private IWebDriver? driver;
        public IWebDriver InitializeDriver() {
            driver = new ChromeDriver();
            return driver;
        }

        public void QuitDriver() {
            if (driver != null) {
                driver.Quit();
            }
        }
    }
}