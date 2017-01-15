using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartHomeDemo.Tests.IntegrationTests.PageObjects
{
    class CreateDevicePageObject
    {
        private readonly IWebDriver _driver;

        public CreateDevicePageObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using="#Name")]
        private IWebElement _deviceNameInput;

        [FindsBy(How = How.CssSelector, Using = "#button-submit")]
        private IWebElement _submitButton;

        public void SetDeviceInputText(string aText)
        {
            _deviceNameInput.SendKeys(aText);
        }

        public void ClickSubmitButton()
        {
            _submitButton.Click();
        }
    }
}
