using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels.Test
{
    public class OrderTest
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }
        [Fact]
        public void TotalCount_WithEmtyItems_ReturnZero()
        {
            var order = new Order(1, new OderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }
        [Fact]
        public void TotalPrice_WithEmtyItems_ReturnZero()
        {
            var order = new Order(1, new OderItem[0]);
            Assert.Equal(0m, order.TotalCount);
        }
        [Fact]
        public void TotalCount_WithNonEmtyItems_CalculatesTotalCount()
        {
            var order = new Order(1, new [] 
            {
                new OderItem(1,3,10m),
                new OderItem(2,5,100m),
            });
            Assert.Equal(3+5, order.TotalCount);
        }
        [Fact]
        public void TotalPrice_WithNonEmtyItems_CalculatesTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OderItem(1,3,10m),
                new OderItem(2,5,100m),
            });
            Assert.Equal(3*10m + 5*100m, order.TotalPrice);
        }
    }
}
