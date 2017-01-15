using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using NUnit.Framework;
using SmartHomeDemo.Controllers;
using SmartHomeDemo.Models;

namespace SmartHomeDemo.Tests.UnitTests.Controllers
{
    class DeviceInfoControllerTest
    {
        [TestCase(3)]
        public void GetAllDevices_CountOfDevicesIsCorrect(int aMinDeviceCount)
        {
            // Arrange
            DeviceInfoController controller = new DeviceInfoController();

            // Act
            ICollection<DeviceViewModel> devices = controller.GetAllDevices();

            // Assert
            Assert.That(devices.Count >= aMinDeviceCount);
        }

        [Test]
        public void GetDevice_CorrectIndex()
        {
            // Arrange
            int id = 1;
            DeviceInfoController controller = new DeviceInfoController();

            // Act
            OkNegotiatedContentResult<DeviceViewModel> result = controller.GetDevice(id) as OkNegotiatedContentResult<DeviceViewModel>;
            
            // Assert
            Assert.NotNull(result);
            Assert.That(result.Content.Id == id);
        }

        [Test]
        public void GetDevice_IncorrectIndex()
        {
            // Arrange
            int id = -1;
            DeviceInfoController controller = new DeviceInfoController();

            // Act
            NotFoundResult result = controller.GetDevice(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
