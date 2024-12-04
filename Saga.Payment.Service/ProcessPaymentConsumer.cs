using MassTransit;
using Saga.Contracts;

namespace Sags.Payment.Service
{
    public class ProcessPaymentConsumer : IConsumer<ProcessPayment>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<ProcessPaymentConsumer> logger;

        public ProcessPaymentConsumer(ILogger<ProcessPaymentConsumer> logger, IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
        }       

        public async Task Consume(ConsumeContext<ProcessPayment> context)
        {
            logger.LogInformation("Processing payment for {OrderId}", context.Message.OrderId);

            //Payment simulation
            await Task.Delay(3000);

            int successProbabilityPercentage = 50;
            bool success = Random.Shared.Next(100) <= successProbabilityPercentage;

            if (success)
            {
                await publishEndpoint.Publish(new PaymentProcessed
                {
                    OrderId = context.Message.OrderId,
                    PaymentIntentId = $"pi_{Guid.NewGuid()}"
                });
            }

            else
            {
                await publishEndpoint.Publish(new PaymentFailed
                {
                    OrderId = context.Message.OrderId,
                    Reason = "Payment Failed"
                });
            }

        }
    }
}
