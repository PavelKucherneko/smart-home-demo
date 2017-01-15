using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.PhantomJS;
using SmartHomeDemo.Tests.IntegrationTests.PageObjects;

namespace SmartHomeDemo.Tests.IntegrationTests
{
    class DeviceTest
    {
        [Test]
        public void DevicesAreShownInTheTable()
        {
            var driver = new PhantomJSDriver {Url = "http://localhost:51790/Device"};
            driver.Navigate();

            Thread.Sleep(1000);

            var po = new DevicePageObject(driver);
            Assert.AreNotEqual(0, po.GetDevicesCount());
        }

        [Test]
        public void NewDeviceIsAdded()
        {
            var deviceDriver = new PhantomJSDriver { Url = "http://localhost:51790/Device" };
            deviceDriver.Navigate();

            Thread.Sleep(1000);

            var poDevices = new DevicePageObject(deviceDriver);
            int curDevCount = poDevices.GetDevicesCount();

            // открываем страницу добавления устройства
            var createDeviceDriver = new PhantomJSDriver { Url = "http://localhost:51790/Device/Create" };
            createDeviceDriver.Navigate();

            Thread.Sleep(1000);

            var poCreateDevice = new CreateDevicePageObject(createDeviceDriver);

            poCreateDevice.SetDeviceInputText("Boiler");
            poCreateDevice.ClickSubmitButton();

            Thread.Sleep(5000);

            // проверяем, что количество устройств увеличилось
            deviceDriver = new PhantomJSDriver { Url = "http://localhost:51790/Device" };
            deviceDriver.Navigate();

            Thread.Sleep(1000);

            poDevices = new DevicePageObject(deviceDriver);
            int newDevCount = poDevices.GetDevicesCount();

            Assert.That(newDevCount == curDevCount + 1);
        }
    }
}
