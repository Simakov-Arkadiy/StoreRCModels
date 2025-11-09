using Microsoft.AspNetCore.Mvc;
using StoreRCModel.Web.Models;
using StoreRCModels;

namespace StoreRCModel.Web.Controllers
{
    public class ClartController : Controller
    {
        private readonly IRCModelsRepository modelsRepository;
        private readonly IOrderRepository ordersRepository;

        public ClartController(IRCModelsRepository modelsRepository, IOrderRepository ordersRepository)
        {
            this.modelsRepository = modelsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Add(int id)
        {
            Order order;
            Clart clart;
            if(HttpContext.Session.TryGetCart(out clart))
            {
                order = ordersRepository.GetById(clart.OrderId);
            }
            else
            {
                order = ordersRepository.Create();
                clart = new Clart(order.Id);
            }
            var model = modelsRepository.GetById(id);
            order.AddItem(model, 1);
            ordersRepository.Update(order);

            clart.TotalCount = order.TotalCount;
            clart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(clart);
            return RedirectToAction("Index","RCModel", new {id});
        }
    }
}
