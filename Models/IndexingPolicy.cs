using System.Collections.Generic;

namespace CosmosUtility.Models
{
    public class IndexingPolicy
    {
        public string IndexingMode { get; set; }
        public bool Automatic { get; set; }
        public List<DocumentPath> IncludedPaths { get; set; }
        public List<DocumentPath> ExcludedPaths { get; set; }
    }
}