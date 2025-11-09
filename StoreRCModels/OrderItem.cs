using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels
{
    public class OrderItem
    {
        public int ModelId { get;}
        public int Count { get;}
        public decimal Price {  get;}

        public OrderItem(int modelId, int count, decimal price)
        {
            if(count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be grtater than zero.");
            }
            ModelId = modelId;
            Count = count;
            Price = price;
        }
    }
}
