using Order.API.Models.Enums;

namespace Order.API.Models.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
