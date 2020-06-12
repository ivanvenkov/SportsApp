namespace KafkaService.Services.Common
{
    public class KafkaServiceFactory : IKafkaServiceFactory
    {
        public KafkaProducerService GetProducerService(KafkaServerSettings serverSettings, KafkaProducer kafkaProducer)
        {
            return new KafkaProducerService(serverSettings, kafkaProducer);
        }
    }
}
