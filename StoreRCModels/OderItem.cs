using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels
{
    public class OderItem
    {
        public int ModelId { get;}
        public int Count { get;}
        public decimal Price {  get;}

        public OderItem(int modelId, int count, decimal price)
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
