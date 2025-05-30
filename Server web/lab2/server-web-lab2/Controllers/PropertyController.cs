using Microsoft.AspNetCore.Mvc;
using server_web_lab2.Models;

public class PropertyController : Controller
{
    private List<Property> properties = new List<Property>
    {
        new Property { Type = "Квартира", District = "Центр", Area = 45, Rooms = 2, Price = 45000, OperationType = "продаж" },
        new Property { Type = "Будинок", District = "Сихів", Area = 120, Rooms = 4, Price = 95000, OperationType = "продаж" },
        new Property { Type = "Квартира", District = "Левандівка", Area = 60, Rooms = 3, Price = 60000, OperationType = "оренда" },
        new Property { Type = "Квартира", District = "Центр", Area = 35, Rooms = 1, Price = 40000, OperationType = "продаж" },
        new Property { Type = "Будинок", District = "Сихів", Area = 90, Rooms = 3, Price = 80000, OperationType = "купівля" },
        new Property { Type = "Квартира", District = "Центр", Area = 50, Rooms = 2, Price = 48000, OperationType = "здавання" },
        new Property { Type = "Квартира", District = "Сихів", Area = 55, Rooms = 2, Price = 51000, OperationType = "продаж" },
        new Property { Type = "Будинок", District = "Левандівка", Area = 150, Rooms = 5, Price = 120000, OperationType = "оренда" },
        new Property { Type = "Квартира", District = "Центр", Area = 40, Rooms = 2, Price = 47000, OperationType = "продаж" },
        new Property { Type = "Квартира", District = "Сихів", Area = 60, Rooms = 3, Price = 57000, OperationType = "продаж" },
    };

    public ActionResult Index()
    {
        return View(properties);
    }

    public ActionResult ByDistrictAndOperation(string district, string operation)
    {
        var result = properties
            .Where(p => p.District == district && p.OperationType == operation)
            .OrderBy(p => p.Price)
            .ToList();
        return View("Index", result);
    }

    public ActionResult ByDistrictAndRooms(string district, int rooms)
    {
        var result = properties
            .Where(p => p.District == district && p.Rooms == rooms)
            .OrderBy(p => p.Price)
            .ToList();
        return View("Index", result);
    }

    public ActionResult ForSaleInDistrict(string district)
    {
        var result = properties
            .Where(p => p.OperationType == "продаж" && p.District == district)
            .ToList();
        return View("Index", result);
    }

    public ActionResult CheapestInDistrict(string district)
    {
        var result = properties
            .Where(p => p.District == district)
            .OrderBy(p => p.Price)
            .FirstOrDefault();

        return View("Single", result);
    }
}
