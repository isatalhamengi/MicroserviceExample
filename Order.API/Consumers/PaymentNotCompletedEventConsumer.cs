using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Shared.Events;

namespace Order.API.Consumers
{
    public class PaymentNotCompletedEventConsumer : IConsumer<PaymentNotCompletedEvent>
    {
        readonly OrderAPIDbContext _context;

        public PaymentNotCompletedEventConsumer(OrderAPIDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<PaymentNotCompletedEvent> context)
        {
            Order.API.Models.Entities.Order order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == context.Message.OrderId);
            order.OrderStatus = Models.Enums.OrderStatus.Failed;
            await _context.SaveChangesAsync();
        }
    }
}
