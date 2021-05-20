using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class PartitionKeyStatistic
    {
        public List<string> PartitionKey { get; set; }
        public long SizeInKB { get; set; }
    }
}