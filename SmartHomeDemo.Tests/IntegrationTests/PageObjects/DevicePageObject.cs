using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartHomeDemo.Tests.IntegrationTests.PageObjects
{
    class DevicePageObject
    {
        private readonly IWebDriver _driver;

        public DevicePageObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#device-table")]
        private IWebElement _devicesTable;

        public int GetDevicesCount()
        {
            return _devicesTable.FindElements(By.TagName("tr")).Count - 1; // минус строка заголовка
        }
    }
}
