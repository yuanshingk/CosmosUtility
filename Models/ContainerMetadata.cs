using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class ContainerMetadata
    {
        public double RequestCharge { get; set; }

        public string Id { get; set; }

        public IndexingPolicy IndexingPolicy { get; set; }

        public PartitionKey PartitionKey { get; set; }

        public UniqueKeyPolicy UniqueKeyPolicy { get; set; }

        public List<ContainerStatistic> Statistics { get; set; }

        public ConflictResolutionPolicy ConflictResolutionPolicy { get; set; }

        public bool AllowMaterializedViews { get; set; }

        public GeospatialConfig GeospatialConfig { get; set; }

        [JsonProperty(PropertyName = "_rid")]
        public string Rid { get; set; }

        [JsonProperty(PropertyName = "_ts")]
        public string Ts { get; set; }

        [JsonProperty(PropertyName = "_self")]
        public string Self { get; set; }

        [JsonProperty(PropertyName = "_etag")]
        public string Etag { get; set; }

        [JsonProperty(PropertyName = "_docs")]
        public string Docs { get; set; }

        [JsonProperty(PropertyName = "_sprocs")]
        public string Sprocs { get; set; }

        [JsonProperty(PropertyName = "_triggers")]
        public string Triggers { get; set; }

        [JsonProperty(PropertyName = "_udfs")]
        public string Udfs { get; set; }

        [JsonProperty(PropertyName = "_conflicts")]
        public string Conflicts { get; set; }

        public PartitionKeyRange PartitionKeyRange { get; set; }

        public CosmosDbOffer CosmosDbOffer { get; set; }

        public string Raw { get; set; }
    }
}
