using Microsoft.AspNetCore.Mvc;
using StoreRCModels;
using System.Linq;

namespace StoreRCModel.Web.Controllers
{
    public class searchController : Controller
    {
        private readonly RCModelService rcmodelService;

        public searchController(RCModelService rcmodelService)
        {
            this.rcmodelService = rcmodelService;
        }
        public IActionResult Index(string query)
        {
            var rcmodels = rcmodelService.GetAllByQuery(query);
            return View(rcmodels);
        }
    }
}
