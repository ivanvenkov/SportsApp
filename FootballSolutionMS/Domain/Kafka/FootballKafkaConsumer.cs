using Domain.Adaptors;
using Domain.Application;
using Domain.Facotry;
using Domain.Models;
using KafkaService;
using KafkaService.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Kafka
{
    public class FootballKafkaConsumer : IKafkaConsumer
    {
        private IPersonManager manager;
        private Adaptor adaptor;

        public async Task ProccessMessage(KafkaOptions kafkaOptions, IServiceScope serviceScope, string message)
        {
            IKafkaServiceFactory kafkaFactory = serviceScope.ServiceProvider
                 .GetRequiredService<IKafkaServiceFactory>();

            IFactory factory = serviceScope.ServiceProvider
                .GetRequiredService<IFactory>();

            this.manager = new PersonManager(factory);
            this.adaptor = factory.GetAdaptor();

            KafkaProducerService producerService = kafkaFactory.GetProducerService
                (
                kafkaOptions.Settings,
                kafkaOptions.Producers[0]
                );

            if (int.TryParse(message, out int id))
            {
                KafkaProtocolModel kafkaProtocol = this.GetProtocol(message);

                switch (kafkaProtocol.Head.Action)
                {
                    case "QUERY":
                        await this.ProcessQuery(producerService);
                        break;

                    case "ADD_PERSON":
                        await this.ProcessAddPerson(kafkaProtocol.Data[0], producerService);
                        break;

                }
            }
            else
            {
                var carID = int.Parse(message);
                await this.RemoveCar(carID);
            }
        }

        private async Task RemoveCar(int id)
        {
            await this.manager.DeleteAsync(id);
        }

        private async Task ProcessAddPerson(KpPersonModel kpPerson, KafkaProducerService producerService)
        {
            var personVM = this.adaptor.Transform(kpPerson);

            var id = await this.manager.AddNewPersonAsync(personVM);

            string jsonString = JsonSerializer.Serialize(id);

            await producerService.ProduceMessageAsync(jsonString);
        }

        private async Task ProcessQuery(KafkaProducerService producerService)
        {
            var allPersons = await this.manager.GetPersonsAsync();

            List<KpPersonModel> cars = this.adaptor.Transform(allPersons);

            KafkaProtocolModel kafkaProtocol = new KafkaProtocolModel
            {
                Data = cars,
                Head = new KpHeapModel
                {
                    Action = "Result",
                    Version = "1"
                }
            };

            string jsonString = JsonSerializer.Serialize(kafkaProtocol);

            await producerService.ProduceMessageAsync(jsonString);
        }

        private KafkaProtocolModel GetProtocol(string message)
        {
            return JsonSerializer.Deserialize<KafkaProtocolModel>(message);
        }
    }
}
