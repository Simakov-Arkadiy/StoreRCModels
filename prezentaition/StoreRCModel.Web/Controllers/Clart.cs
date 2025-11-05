using Microsoft.AspNetCore.Mvc;
using StoreRCModel.Web.Models;
using StoreRCModels;

namespace StoreRCModel.Web.Controllers
{
    public class ClartController : Controller
    {
        private readonly IRCModelsRepository modelsRepository;

        public ClartController(IRCModelsRepository modelsRepository)
        {
            this.modelsRepository = modelsRepository;
        }
        public IActionResult Add(int id)
        {
            var model = modelsRepository.GetById(id);
            Clart clart;
            if(!HttpContext.Session.TryGetCart(out clart))
            {
                clart = new Clart();
            }
            if (clart.items.ContainsKey(id))
            {
                clart.items[id]++;
                clart.amount += model.price;
            }
            else
            {
                clart.items[id] = 1;
                clart.amount += model.price;
            }
            HttpContext.Session.Set(clart);
            return RedirectToAction("Index","RCModel", new {id});
        }
    }
}
