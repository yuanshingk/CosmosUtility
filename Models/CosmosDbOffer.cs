using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class CosmosDbOffer
    {
        [JsonProperty(PropertyName = "_rid")]
        public string Rid { get; set; }

        [JsonProperty(PropertyName = "_count")]
        public string Count { get; set; }

        public List<ContainerOffer> Offers { get; set; }

        public string Raw { get; set; }
    }
}
