using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_web_lab4.Models;
using System.Net;

namespace server_web_lab4.Controllers
{
    public class StoreDepartmentsController : Controller
    {
        private readonly ApplicationDbContext db;

        public StoreDepartmentsController(ApplicationDbContext context) : base()
        {
            db = context;
        }

        public ActionResult Index()
        {
            return View(db.StoreDepartments.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var storeDepartment = db.StoreDepartments.Find(id);

            if (storeDepartment == null)
            {
                return NotFound();
            }

            return View(storeDepartment);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreDepartment storeDepartment)
        {
            if (ModelState.IsValid)
            {
                db.StoreDepartments.Add(storeDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeDepartment);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            StoreDepartment storeDepartment = db.StoreDepartments.Find(id);

            if (storeDepartment == null)
            {
                return NotFound();
            }

            return View(storeDepartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreDepartment storeDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storeDepartment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var storeDepartment = db.StoreDepartments.Find(id);

            if (storeDepartment == null)
            {
                return NotFound();
            }
            return View(storeDepartment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var storeDepartment = db.StoreDepartments.Find(id);

            if (storeDepartment == null)
            {
                return NotFound();
            }

            db.StoreDepartments.Remove(storeDepartment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
