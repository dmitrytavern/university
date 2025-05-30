using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using server_web_lab4.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace server_web_lab4.Controllers
{
    public class DepartmentProductsController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartmentProductsController(ApplicationDbContext context) : base()
        {
            db = context;
        }

        public ActionResult Index()
        {
            return View(db.DepartmentProducts.Include(p => p.StoreDepartment).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var departmentProduct = db.DepartmentProducts.Include(p => p.StoreDepartment).FirstOrDefault(p => p.ID_RES == id);

            if (departmentProduct == null)
            {
                return NotFound();
            }

            return View(departmentProduct);
        }

        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.StoreDepartments, "ID", "NAME");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentProduct departmentProduct)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentProducts.Add(departmentProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error: ");

                Console.WriteLine(ModelState.ToString());

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            ViewBag.DepartmentID = new SelectList(db.StoreDepartments, "ID", "NAME", departmentProduct.DepartmentID);

            return View(departmentProduct);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var departmentProduct = db.DepartmentProducts.Find(id);

            if (departmentProduct == null)
            {
                return NotFound();
            }

            ViewBag.DepartmentID = new SelectList(db.StoreDepartments, "ID", "NAME", departmentProduct.DepartmentID);

            return View(departmentProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentProduct departmentProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.StoreDepartments, "ID", "NAME", departmentProduct.DepartmentID);

            return View(departmentProduct);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var departmentProduct = db.DepartmentProducts.Include(p => p.StoreDepartment).FirstOrDefault(p => p.ID_RES == id);

            if (departmentProduct == null)
            {
                return NotFound();
            }

            return View(departmentProduct);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var departmentProduct = db.DepartmentProducts.Find(id);

            if (departmentProduct == null)
            {
                return NotFound();
            }

            db.DepartmentProducts.Remove(departmentProduct);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
