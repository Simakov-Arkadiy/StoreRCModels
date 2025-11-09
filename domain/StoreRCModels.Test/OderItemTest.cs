using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels.Test
{
    public class OderItemTest
    {
        [Fact]
        public void OderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                new OderItem(1, count, 0m);

            });
        }

        [Fact]
        public void OderItem_WithNegativeCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                new OderItem(1, count, 0m);
            });
        }

        [Fact]
        public void OderItem_WithPositiveCount_SetsCount()
        {
            var orderItem = new OderItem(1,2,3m);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(1, orderItem.ModelId);
            Assert.Equal(3m, orderItem.Price);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                new OderItem(1, count, 0m);
            });
        }
    }
}
