namespace CosmosUtility.Models
{
    public class OfferContent
    {
        public long OfferThroughput { get; set; }
        public bool OfferIsRUPerMinuteThroughputEnabled { get; set; }
        public OfferMinimumThroughputParameters OfferMinimumThroughputParameters { get; set; }
        public long OfferLastReplaceTimestamp { get; set; }
    }
}