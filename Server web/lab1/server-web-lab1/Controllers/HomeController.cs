using Microsoft.AspNetCore.Mvc;
using server_web_lab1.Models;

namespace server_web_lab1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new SubsidyInputModel());
        }

        [HttpPost]
        public ActionResult Index(SubsidyInputModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            decimal totalIncome = model.TotalIncome;

            int residents = model.ResidentsCount > 0 ? model.ResidentsCount : 1;

            decimal livingWage = 3200m;
            decimal halfLivingWage = livingWage * 0.5m;

            decimal incomePerPerson = totalIncome / residents;

            int nonWorkCount = 0;
            if (model.HasChildren) nonWorkCount++;
            if (model.HasDisabled) nonWorkCount++;
            if (model.HasUnemployed) nonWorkCount++;

            bool onlyNonWorking = nonWorkCount >= residents;

            bool lowIncomeFamily = incomePerPerson <= halfLivingWage;

            decimal percent = (onlyNonWorking || lowIncomeFamily) ? 0.10m : 0.15m;

            decimal mandatoryPayment = (totalIncome * percent);

            decimal monthlyUtilityCosts = model.UtilityCosts;

            decimal subsidy = monthlyUtilityCosts - mandatoryPayment;

            model.SubsidyResult = subsidy > 0 ? subsidy : 0;

            return View(model);
        }
    }
}
