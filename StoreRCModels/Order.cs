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
        private List<OderItem> items;
        public IReadOnlyCollection<OderItem> Items
        {
            get { return Items; }
        }
        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }
        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Price*item.Count); }
        }
        public Order(int id, IEnumerable<OderItem> items) 
        {
            if(items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            Id = id;
            this.items = new List<OderItem>(items);
        }
        public void AddItem(RCModel rcmodel, int count)
        {
            if (rcmodel == null)
            {
                throw new ArgumentNullException(nameof(rcmodel));
            }
                var item = items.SingleOrDefault(x => x.ModelId == rcmodel.numberRCModdel);
                if(item == null)
                {
                    items.Add(new OderItem(rcmodel.numberRCModdel, count, rcmodel.price));
                }
                else
                {
                    items.Remove(item);
                    items.Add(new OderItem(rcmodel.numberRCModdel, item.Count + count, rcmodel.price));
                }
            
        }
    }
}
