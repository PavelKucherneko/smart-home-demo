using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartHomeDemo.Db;
using SmartHomeDemo.Db.Models;

namespace SmartHomeDemo.Controllers
{
    public class DeviceController : Controller
    {
        private readonly SmartHomeDbContext _db = new SmartHomeDbContext();

        // GET: Device
        public ActionResult Index()
        {
            var devices = _db.Devices.Include(d => d.Room);
            return View(devices.ToList());
        }

        // GET: Device/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = _db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: Device/Create
        public ActionResult Create()
        {
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Name");
            return View();
        }

        // POST: Device/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoomId,Name,Status,Version")] Device device)
        {
            if (ModelState.IsValid)
            {
                _db.Devices.Add(device);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Name", device.RoomId);
            return View(device);
        }

        // GET: Device/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = _db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Name", device.RoomId);
            return View(device);
        }

        // POST: Device/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoomId,Name,Status,Version")] Device device)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(device).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Name", device.RoomId);
            return View(device);
        }

        // GET: Device/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = _db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Device device = _db.Devices.Find(id);
            _db.Devices.Remove(device);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
