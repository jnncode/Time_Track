IWebDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl("https://arpwas.honeywell.com/twb/");
var loginButton = driver.FindElement(By.Class("MobileLoginStdBtn")); // Assuming login credentials are saved