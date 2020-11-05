using CommandLine;

namespace CosmosUtility
{
    public class CommandOption
    {
        [Option('e', "endpoint", Required = true, HelpText = "Cosmos DB endpoint e.g. https://mycosmosdb.documents.azure.com:443/")]
        public string Endpoint { get; set; }

        [Option('k', "key", Required = true, HelpText = "Cosmos DB account key")]
        public string AccountKey { get; set; }

        [Option('d', "database", Required = true, HelpText = "Database name")]
        public string Database { get; set; }

        [Option('c', "container", Required = true, HelpText = "Container name")]
        public string Container { get; set; }
    }
}
