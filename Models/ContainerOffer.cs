using Newtonsoft.Json;

namespace CosmosUtility.Models
{
    public class ContainerOffer
    {
        public string Resource { get; set; }

        public string OfferType { get; set; }

        public string OfferResourceId { get; set; }

        public string OfferVersion { get; set; }

        public OfferContent Content { get; set; }

        public string Id { get; set; }

        [JsonProperty(PropertyName = "_rid")]
        public string Rid { get; set; }

        [JsonProperty(PropertyName = "_self")]
        public string Self { get; set; }

        [JsonProperty(PropertyName = "_etag")]
        public string Etag { get; set; }

        [JsonProperty(PropertyName = "_ts")]
        public string Ts { get; set; }
    }
}