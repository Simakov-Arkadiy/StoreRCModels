using Microsoft.AspNetCore.Mvc;
using StoreRCModel.Web.Models;
using StoreRCModels;
using System.Linq;

namespace StoreRCModel.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRCModelsRepository modelsRepository;
        private readonly IOrderRepository ordersRepository;

        public OrderController(IRCModelsRepository modelsRepository, IOrderRepository ordersRepository)
        {
            this.modelsRepository = modelsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
           
            if (HttpContext.Session.TryGetCart(out Clart clart))
            {
                var order = ordersRepository.GetById(clart.OrderId);
                OrderModel model = Map(order);
                return View(model);
            }
            return View("Empty");

        }

        private OrderModel Map(Order order)
        {
            var rcmodelIds = order.Items.Select(item => item.ModelId);
            var rcmodels = modelsRepository.GetAllById(rcmodelIds);
            var itemModels = from item in order.Items
                             join rcmodel in rcmodels on item.ModelId equals rcmodel.numberRCModel
                             select new OrderItemModel
                             {
                                 NumberRCModel = rcmodel.numberRCModel,
                                 NameRCModel = rcmodel.nameRCModel,
                                 TypeRCModel = rcmodel.typeRCModel,
                                 Color = rcmodel.color,
                                 Price = item.Price,
                                 Count = item.Count,
                             };

            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }
        public IActionResult AddItem(int id)
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
