using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class ContainerStatistic
    {
        public string Id { get; set; }
        public long SizeInKB { get; set; }
        public long DocumentCount { get; set; }
        public List<PartitionKeyStatistic> PartitionKeys { get; set; }
    }
}
