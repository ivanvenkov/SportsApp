using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace KafkaService.Services.Common
{
    public interface IKafkaConsumer
    {
        Task ProccessMessage(KafkaOptions kafkaOptions, IServiceScope scope, string message);
    }
}
