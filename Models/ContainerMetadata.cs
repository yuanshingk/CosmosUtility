using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class ContainerMetadata
    {
        public double RequestCharge { get; set; }
        public string Id { get; set; }
        public IndexingPolicy IndexingPolicy { get; set; }
        public PartitionKey PartitionKey { get; set; }
        public List<ContainerStatistic> Statistics { get; set; }
        public PartitionKeyRange PartitionKeyRange { get; set; }
    }
}
