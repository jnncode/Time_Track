using System.Xml.XPath;
using Microsoft.VisualBasic;
using OpenQA.Selenium;

namespace Time_Track {
    public class EnterRecords() {
        private const string mondayTabXpath = "[id=view_tab_tv_labor_tab5_1_4]";
        private const string tuesdayTabXpath = "[id=view_tab_tv_labor_tab5_1_5]";
        private const string wednesdayTabXpath = "[id=view_tab_tv_labor_tab5_1_6]";
        private const string thursdayTabXpath = "[id=view_tab_tv_labor_tab5_1_7]";
        private const string fridayTabXpath = "[id=view_tab_tv_labor_tab5_1_8]";

        private const string attendanceHoursTextXpath = "//tr[@valign='middle']//td[2]";
        private const string addLaborButtonXpath = "//a[@id='view_tab_bu_add_labor']";
        private const string orderInputFieldXpath = "//input[@id='view_tlc_in_order']";
        private const string operationInputFieldXpath = "//input[@id='view_tlc_in_operation']";

        private const string hoursInputFieldXpath = "//input[@id='view_tlc_in_hours']";

        private const string saveButtonXpath = "(//a[@id='view_tlc_bu_save_labor_rcd'])[2]";

         private readonly string[] dayTabsXpaths = {
            mondayTabXpath,
            tuesdayTabXpath,
            wednesdayTabXpath,
            thursdayTabXpath,
            fridayTabXpath
        };
        public void ReadWriteTime(IWebDriver driver) {
            try {
                DotNetEnv.Env.Load("C:/Users/sys1/source/repos/Time_Track/.env"); // Load environment variables from .env file
                string? order = Environment.GetEnvironmentVariable("ORDER");
                string? operation = Environment.GetEnvironmentVariable("OPERATION");

                WebElement weeklyLaborEntryTab = (WebElement)driver.FindElement(By.Id("view_tab_Time_Work_Bench-itm-3-txt"));
                weeklyLaborEntryTab.Click();
                WebElement previousWeekButton = (WebElement)driver.FindElement(By.Id("view_tab_bu_prev_day"));
                previousWeekButton.Click();
                
                foreach (var dayXpath in dayTabsXpaths) {
                    WebElement dayTab = (WebElement)driver.FindElement(By.XPath(dayXpath));
                    dayTab.Click();

                    WebElement attendanceHoursText = (WebElement)driver.FindElement(By.XPath(attendanceHoursTextXpath));
                    string attendanceHoursValue = attendanceHoursText.Text;
                    WebElement addlaborButton = (WebElement)driver.FindElement(By.XPath(addLaborButtonXpath));
                    addlaborButton.Click();

                    WebElement orderInput = (WebElement)driver.FindElement(By.XPath(orderInputFieldXpath));
                    orderInput.SendKeys(order);
                    WebElement operationInput = (WebElement)driver.FindElement(By.XPath(operationInputFieldXpath));
                    operationInput.SendKeys(operation);

                    WebElement hoursInput = (WebElement)driver.FindElement(By.XPath(hoursInputFieldXpath));
                    hoursInput.SendKeys(attendanceHoursValue);
    
                    WebElement saveButton = (WebElement)driver.FindElement(By.XPath(saveButtonXpath));
                    saveButton.Click();
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}