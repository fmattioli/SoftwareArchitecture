namespace TrackR.Shipping.Orders.Infrastructure.Configuration
{
    public class KafkaSettings
    {
        public string Brokers { get; set; }

        public string Environment { get; set; }

        public int PollInterval { get; set; }
        
        public int RetryNumber { get; set; }

        public IEnumerable<string> Sasl_Brokers { get; set; }

        public bool Sasl_Enabled { get; set; }

        public string Sasl_UserName { get; set; }

        public string Sasl_Password { get; set; }

        public string DependencyName { get; set; }

        public int ProducerRetryCount { get; set; }

        public int ProducerRetryInterval { get; set; }

        public int MessageTimeoutMs { get; set; }

        public int ConsumerRetryCount { get; set; }

        public int ConsumerRetryInterval { get; set; }

        public string ConsumerInitialState { get; set; }

        public int WorkerCount { get; set; }

        public int BufferSize { get; set; }

        public KafkaBatchSettings Batch { get; set; }
    }
}
