using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class PartitionKeyRangeDetail
    {
        public string Id { get; set; }

        public string MinInclusive { get; set; }

        public string MaxExclusive { get; set; }

        public int RidPrefix { get; set; }

        public double ThroughputFraction { get; set; }

        public string Status { get; set; }

        public List<string> Parents { get; set; }

        [JsonProperty(PropertyName = "_rid")]
        public string Rid { get; set; }
        
        [JsonProperty(PropertyName = "_ts")]
        public string Ts { get; set; }

        [JsonProperty(PropertyName = "_self")]
        public string Self { get; set; }

        [JsonProperty(PropertyName = "_etag")]
        public string Etag { get; set; }
    }
}