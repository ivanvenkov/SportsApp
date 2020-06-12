using Confluent.Kafka;
using KafkaService.Services.Common;
using System;
using System.Threading.Tasks;

namespace KafkaService
{
    public class KafkaProducerService
    {
        private readonly KafkaProducer producer;
        private readonly ProducerConfig config;

        public KafkaProducerService(KafkaServerSettings serverSettings, KafkaProducer producer)
        {
            this.producer = producer;
            config = new ProducerConfig
            {
                BootstrapServers = serverSettings.BootstrapServer,
                ClientId = "football"
            };

            if (string.IsNullOrEmpty(producer.Key))
            {
                producer.Key = null;
            }
        }

        public async Task ProduceMessageAsync(string value)
        {
            using (var produce = new ProducerBuilder<string, string>(config).Build())
            {
                Console.WriteLine($"Pruducing async on {producer.Topic}, {produce.Name}: {value}");
                try
                {
                    var dr = await produce.ProduceAsync(
                        producer.Topic,
                        new Message<string, string>
                        {
                            Value = value,
                            Key = producer.Key
                        });

                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> ex)
                {

                    Console.WriteLine($"Delivery failed: {ex.Error.Reason}");
                }
            }
        }
    }
}

