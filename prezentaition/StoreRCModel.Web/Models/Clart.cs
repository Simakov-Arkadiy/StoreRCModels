namespace StoreRCModel.Web.Models
{
    public class Clart
    {
        public int OrderId {get;}
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public Clart(int orderId) 
        {
            OrderId = orderId;
            TotalCount = 0;
            TotalPrice = 0m;
        }
    }
}
