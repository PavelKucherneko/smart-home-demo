using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SmartHomeDemo.Models;

namespace SmartHomeDemo.Controllers
{
    public class DeviceInfoController : ApiController
    {
        private readonly ICollection<DeviceViewModel> _devices = new List<DeviceViewModel>
        {
            new DeviceViewModel() {Id = 1, Name = "Heater", Status = DeviceStatuses.On},
            new DeviceViewModel() {Id = 2, Name = "AirConditioner", Status = DeviceStatuses.Off},
            new DeviceViewModel() {Id = 3, Name = "Camera", Status = DeviceStatuses.On},
        };

        // GET api/<controller>
        public ICollection<DeviceViewModel> GetAllDevices()
        {
            return _devices;
        }

        // GET api/<controller>/id
        public IHttpActionResult GetDevice(int id)
        {
            var device = _devices.FirstOrDefault((d) => d.Id == id);
            if(device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}