namespace KafkaService.Services.Common
{
    public interface IKafkaServiceFactory
    {
        KafkaProducerService GetProducerService(KafkaServerSettings serverSettings, KafkaProducer kafkaProducer);
    }
}