namespace CosmosUtility.Models
{
    public class ConflictResolutionPolicy
    {
        public string Mode { get; set; }
        public string ConflictResolutionPath { get; set; }
        public string ConflictResolutionProcedure { get; set; }
    }
}