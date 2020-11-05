using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class PartitionKeyRange
    {
        [JsonProperty(PropertyName = "_rid")]
        public string Rid { get; set; }

        [JsonProperty(PropertyName = "_count")]
        public int Count { get; set; }

        public List<PartitionKeyRangeDetail> PartitionKeyRanges { get; set; }
    }
}