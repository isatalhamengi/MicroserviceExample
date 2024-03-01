using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Shared.Events;

namespace Order.API.Consumers
{
    public class StockNotReservedEventConsumer : IConsumer<StockNotReservedEvent>
    {
        readonly OrderAPIDbContext _context;

        public StockNotReservedEventConsumer(OrderAPIDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<StockNotReservedEvent> context)
        {
            Order.API.Models.Entities.Order order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == context.Message.OrderId);
            order.OrderStatus = Models.Enums.OrderStatus.Failed;
            await _context.SaveChangesAsync();
        }
    }
}
