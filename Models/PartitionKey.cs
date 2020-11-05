using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class PartitionKey
    {
        public List<string> Paths { get; set; }
        public string Kind { get; set; }
    }
}