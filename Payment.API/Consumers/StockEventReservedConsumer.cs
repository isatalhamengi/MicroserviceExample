using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockEventReservedConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _endpoint;

        public StockEventReservedConsumer(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            //Ödeme İşlemleri
            if (true)
            {
                PaymentCompletedEvent paymentCompletedEvent = new()
                {
                    OrderId = context.Message.OrderId
                };

                _endpoint.Publish(paymentCompletedEvent);
                Console.WriteLine("Ödeme Başarılı");
            }
            else
            {
                PaymentNotCompletedEvent paymentNotCompletedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                    Message = "Bakiye Yetersiz..."
                };
                _endpoint.Publish(paymentNotCompletedEvent);

                Console.WriteLine("Ödeme Başarısız");
            }
            return Task.CompletedTask;
        }
    }
}
