using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class PartitionKeyRangeDetail
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "_rid")]
        public string Rid { get; set; }

        public string MinInclusive { get; set; }

        public string MaxExclusive { get; set; }

        public int RidPrefix { get; set; }


        [JsonProperty(PropertyName = "_self")]
        public string Self { get; set; }

        public double ThroughputFraction { get; set; }

        public string Status { get; set; }

        public List<string> Parents { get; set; }
    }
}