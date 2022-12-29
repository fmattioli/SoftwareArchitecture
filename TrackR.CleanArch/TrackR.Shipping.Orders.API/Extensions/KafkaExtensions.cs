using Confluent.Kafka;

using KafkaFlow;
using KafkaFlow.Configuration;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;

using TrackR.Shipping.Orders.Infrastructure.Configuration;

namespace TrackR.Shipping.Orders.API.Extensions
{
    public static class KafkaExtensions
    {
        const string topicName = "sample-topic";
        const string producerName = "say-hello";

        public static IServiceCollection AddKafka(this IServiceCollection services, KafkaSettings kafkaSettings)
        {
            services.AddKafka(
                k => k
                    .UseConsoleLog()
                    .AddCluster(
                        cluster => cluster
                        .AddBrokers(kafkaSettings)
                        .AddConsumers(kafkaSettings)
                        .AddProducers(kafkaSettings)
                        ));

            services.AddHostedService<KafkaBusHostedService>();
            return services;
        }

        private static IClusterConfigurationBuilder AddBrokers(
            this IClusterConfigurationBuilder builder,
            KafkaSettings settings)
        {
            if (settings.Sasl_Enabled)
            {
                builder
                    .WithBrokers(settings.Sasl_Brokers)
                    .WithSecurityInformation(si =>
                    {
                        si.SecurityProtocol = KafkaFlow.Configuration.SecurityProtocol.SaslSsl;
                        si.SaslUsername = settings.Sasl_UserName;
                        si.SaslPassword = settings.Sasl_Password;
                        si.SaslMechanism = KafkaFlow.Configuration.SaslMechanism.ScramSha512;
                        si.SslCaLocation = string.Empty;
                    });
            }
            else
            {
                builder.WithBrokers(new[] { settings.Brokers } );
            }

            return builder;
        }
        
        private static IClusterConfigurationBuilder AddConsumers(
            this IClusterConfigurationBuilder builder,
            KafkaSettings settings)
        {
            builder.AddConsumer(consumer => consumer
                     .Topic(topicName)
                     .WithGroupId("sample-group")
                     .WithBufferSize(100)
                     .WithWorkersCount(10)
                     .AddMiddlewares(middlewares => middlewares
                     .AddSerializer<JsonCoreSerializer>()
                    .AddTypedHandlers(h => h.AddHandler<HelloMessageHandler>())));

            return builder;
        } 
        
        private static IClusterConfigurationBuilder AddProducers(
            this IClusterConfigurationBuilder builder,
            KafkaSettings settings)
        {

            var producerConfig = new ProducerConfig
            {
                MessageTimeoutMs = settings.MessageTimeoutMs,
            };

            builder.CreateTopicIfNotExists(topicName, 1, 1)
                        .AddProducer(
                            producerName,
                            producer => producer
                         .DefaultTopic(topicName)
                    .AddMiddlewares(m => m
                                .Add<ProducerRetryMiddleware>()
                                .AddSerializer<JsonCoreSerializer>())
                    .WithAcks(KafkaFlow.Acks.All)
                    .WithProducerConfig(producerConfig));

            return builder;
        }
    }
}
