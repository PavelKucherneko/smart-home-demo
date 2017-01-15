using SmartHomeDemo.Db;
using SmartHomeDemo.Db.Models;
using SmartHomeDemo.Models;

namespace SmartHomeDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartHomeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartHomeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Devices.AddOrUpdate(
                d => d.Id,
                new Device() { Id = 1, Name = "Heater", Status = DeviceStatus.On },
                new Device() { Id = 2, Name = "AirConditioner", Status = DeviceStatus.Off },
                new Device() { Id = 3, Name = "Camera", Status = DeviceStatus.On });
        }
    }
}
