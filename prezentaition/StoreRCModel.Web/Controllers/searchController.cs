using Microsoft.AspNetCore.Mvc;
using StoreRCModels;
using System.Linq;

namespace StoreRCModel.Web.Controllers
{
    public class searchController : Controller
    {
        private IRCModelsRepository rCModelsRepository;

        public searchController(IRCModelsRepository rCModelsRepository)
        {
            this.rCModelsRepository = rCModelsRepository;
        }
        public IActionResult Index(string query)
        {
            var rcmodels = rCModelsRepository.GetAllByTitel(query);
            return View(rcmodels);
        }
    }
}
