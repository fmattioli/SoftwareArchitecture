namespace TrackR.Shipping.Orders.Infrastructure.Configuration
{
    public interface ISettings
    {
        public KafkaSettings KafkaSettings { get; }
        public MongoSettings MongoSettings { get; }
    }

    public class Settings : ISettings
    {
        public KafkaSettings? KafkaSettings { get; set; }
        public MongoSettings? MongoSettings { get; set; }
    }
}
