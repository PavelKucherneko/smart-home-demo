using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHomeDemo.Db.Models;
using SmartHomeDemo.Models;

namespace SmartHomeDemo.Db
{
    public class SmartHomeDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SmartHomeDbContext>
    {
        protected override void Seed(SmartHomeDbContext aContext)
        {
            var rooms = new List<Room>
            {
                new Room{Id = 1, Name = "Corridor"},
                new Room{Id = 2, Name = "Hall"}
            };
            rooms.ForEach(r => aContext.Rooms.Add(r));
            aContext.SaveChanges();

            var devices = new List<Device>
            {
                new Device{RoomId = 1, Name = "Camera", Status = DeviceStatus.On},
                new Device{RoomId = 2, Name = "Heater", Status = DeviceStatus.On},
                new Device{RoomId = 2, Name = "AirConditioner", Status = DeviceStatus.Off},
            };
            devices.ForEach(d => aContext.Devices.Add(d));
            aContext.SaveChanges();
        }
    }
}