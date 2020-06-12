using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KafkaService.Services.Common
{

    public class KafkaOptions
    {
        [JsonPropertyName("Consumers")]
        public List<KafkaConsumer> Consumers { get; set; }

        [JsonPropertyName("Producers")]
        public List<KafkaProducer> Producers { get; set; }

        [JsonPropertyName("Settings")]
        public KafkaServerSettings Settings { get; set; }
    }

    public class KafkaServerSettings
    {
        [JsonPropertyName("BootstrapServer")]
        public string BootstrapServer { get; set; }
    }

    public class KafkaProducer
    {
        [JsonPropertyName("Topic")]
        public string Topic { get; set; }

        [JsonPropertyName("Key")]
        public string Key { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }
    }

    public class KafkaConsumer
    {
        [JsonPropertyName("Topic")]
        public string Topic { get; set; }

        [JsonPropertyName("GroupId")]
        public string GroupId { get; set; }

        [JsonPropertyName("ClientId")]
        public string ClientId { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }
    }
}

