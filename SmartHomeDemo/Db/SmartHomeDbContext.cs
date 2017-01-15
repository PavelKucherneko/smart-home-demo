using System.Data.Entity;
using SmartHomeDemo.Db;
using SmartHomeDemo.Db.Models;

namespace SmartHomeDemo.Db
{
    public class SmartHomeDbContext : DbContext
    {
        public SmartHomeDbContext() : base("SmartHomeDbConnection")
        {
            Database.SetInitializer<SmartHomeDbContext>(new CreateDatabaseIfNotExists<SmartHomeDbContext>());
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}