using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class ContainerStatistic
    {
        public string Id { get; set; }
        public int SizeInKB { get; set; }
        public int DocumentCount { get; set; }
        public List<PartitionKeyStatistic> PartitionKeys { get; set; }
    }
}
