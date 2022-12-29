namespace TrackR.Shipping.Orders.API.Extensions
{
    using KafkaFlow;
    using Polly;

    using TrackR.Shipping.Orders.Infrastructure.Configuration;

    public class ProducerRetryMiddleware : IMessageMiddleware
    {
        private readonly int retryCount;
        private readonly TimeSpan retryInterval;
        private readonly ISettings settings;
        public ProducerRetryMiddleware(ISettings settings)
        {
            this.retryCount = settings.KafkaSettings.ProducerRetryCount;
            this.retryInterval = TimeSpan.FromSeconds(settings.KafkaSettings.ProducerRetryInterval);
        }
        public async Task Invoke(IMessageContext context, MiddlewareDelegate next)
        {
            var policyResult = await Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    this.retryCount,
                    _ => this.retryInterval,
                    (ex, _, retryAttempt, __) =>
                    {
                        Console.WriteLine(ex);
                    })
                .ExecuteAndCaptureAsync(() => next(context));
        }
    }
}
