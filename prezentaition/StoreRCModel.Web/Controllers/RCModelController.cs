using Microsoft.AspNetCore.Mvc;
using StoreRCModel.Memory;
using StoreRCModels;

namespace StoreRCModel.Web.Controllers
{
    public class RCModelController : Controller
    {
        private IRCModelsRepository rcmodelsRepository;
        public RCModelController(IRCModelsRepository rcmodelsRepository)
        {
            this.rcmodelsRepository = rcmodelsRepository;
        }
        public IActionResult Index(int id)
        {
            RCModel rcmodel = rcmodelsRepository.GetById(id);
            return View(rcmodel);
        }
    }
}
