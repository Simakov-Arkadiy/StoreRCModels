using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels
{
    public class Order
    {
        public int Id { get;}
        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }
        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }
        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Price*item.Count); }
        }
        public Order(int id, IEnumerable<OrderItem> items) 
        {
            if(items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            Id = id;
            this.items = new List<OrderItem>(items);
        }
        public void AddItem(RCModel rcmodel, int count)
        {
            if (rcmodel == null)
            {
                throw new ArgumentNullException(nameof(rcmodel));
            }
                var item = items.SingleOrDefault(x => x.ModelId == rcmodel.numberRCModel);
                if(item == null)
                {
                    items.Add(new OrderItem(rcmodel.numberRCModel, count, rcmodel.price));
                }
                else
                {
                    items.Remove(item);
                    items.Add(new OrderItem(rcmodel.numberRCModel, item.Count + count, rcmodel.price));
                }
            
        }
    }
}
