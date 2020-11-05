using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class PartitionKeyStatistic
    {
        public List<string> PartitionKey { get; set; }
        public int SizeInKB { get; set; }
    }
}