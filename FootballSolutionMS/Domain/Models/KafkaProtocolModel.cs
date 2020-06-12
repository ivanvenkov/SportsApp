using System.Collections.Generic;

namespace Domain.Models
{
    public class KafkaProtocolModel
    {
        public KafkaProtocolModel()
        {
            Head = new KpHeapModel();
            Data = new List<KpPersonModel>();
        }

        public KpHeapModel Head { get; set; }
        public List<KpPersonModel> Data { get; set; }
    }

    public class KpHeapModel
    {
        public string Version { get; set; }
        public string Action { get; set; }
    }

    public class KpPersonModel
    {
        public string PersonName { get; set; }

        public char SportType { get; set; }

        public string SportTypeDescription { get; set; }
    }
}
