using OpenQA.Selenium;

namespace Time_Track {
    public class Program {
        public static void Main(string[] args) {
            DriverManager driverManager = new DriverManager();
            IWebDriver driver;
            try {
                driver = driverManager.InitializeDriver();
                LoginHandler loginHandler = new LoginHandler();
                loginHandler.PerformLogin(driver);
            }
            finally {
                driverManager.QuitDriver();
            }
        }
    }
}