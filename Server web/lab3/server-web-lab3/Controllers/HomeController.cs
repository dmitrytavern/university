using Microsoft.AspNetCore.Mvc;
using server_web_lab3.Models;

namespace server_web_lab3.Controllers
{
    public class HomeController : Controller
    {
        private static List<Property> _properties = new List<Property>();
        private static int _idCounter = 1;

        public ActionResult Index(string search)
        {
            var results = string.IsNullOrWhiteSpace(search)
                ? _properties
                : _properties.Where(p =>
                    p.Type.Contains(search) ||
                    p.Condition.Contains(search)).ToList();

            return View(results);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Property property)
        {
            if (!ModelState.IsValid)
                return View(property);

            property.Id = _idCounter++;
            _properties.Add(property);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = _properties.FirstOrDefault(p => p.Id == id);
            if (item != null)
                _properties.Remove(item);

            return RedirectToAction("Index");
        }
    }
}
