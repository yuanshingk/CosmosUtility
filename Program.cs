using CommandLine;
using CosmosUtility.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CosmosUtility
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandOption>(args)
                   .WithParsed<CommandOption>(async o =>
                   {
                       try
                       {
                           var metadata = await GetContainerMetadata(o.Endpoint, o.AccountKey, o.Database, o.Container);
                           metadata ??= new ContainerMetadata();
                           metadata.CosmosDbOffer = await GetOffers(o.Endpoint, o.AccountKey, null);
                           metadata.PartitionKeyRange = await GetPartitionKeyRange(o.Endpoint, o.AccountKey, o.Database, o.Container);

                           var outputText = JsonConvert.SerializeObject(metadata, Formatting.Indented);
                           Console.WriteLine(outputText);

                           using (var strWriter = new StringWriter())
                           {
                               strWriter.Write(outputText);
                               Console.SetOut(strWriter);
                           }                           
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine(ex.Message);
                           Console.ReadLine();
                       }
                   });

            Console.ReadLine();
        }

        private static async Task<ContainerMetadata> GetContainerMetadata(string cosmosDbEndpoint, string cosmosDbAccountKey, string database, string container)
        {
            var resourceLink = $"dbs/{database}/colls/{container}";
            var date = DateTime.Now.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss");
            var token = Helper.GenerateAuthToken("GET", "colls", resourceLink, date.ToLower(), cosmosDbAccountKey, "master", "1.0");
            var url = $"{cosmosDbEndpoint}/{resourceLink}";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", token);
                httpClient.DefaultRequestHeaders.Add("x-ms-date", date);
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2018-12-31");
                httpClient.DefaultRequestHeaders.Add("x-ms-documentdb-populatepartitionstatistics", "true");
                httpClient.DefaultRequestHeaders.Add("x-ms-documentdb-populatequotainfo", "true");

                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();
                    var metadata = JsonConvert.DeserializeObject<ContainerMetadata>(contents);
                    metadata.Raw = contents;
                    if (response.Headers.TryGetValues("x-ms-request-charge", out IEnumerable<string> requestCharges) && requestCharges.Any())
                    {
                        metadata.RequestCharge = Double.Parse(requestCharges.First());
                    }

                    return metadata;
                }
                else
                {
                    Console.WriteLine($"Http status: {response.StatusCode}");
                    var contents = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(contents);
                }
            }

            return null;
        }

        private static async Task<PartitionKeyRange> GetPartitionKeyRange(string cosmosDbEndpoint, string cosmosDbAccountKey, string database, string container)
        {
            var resourceLink = $"dbs/{database}/colls/{container}";
            var date = DateTime.Now.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss");
            var token = Helper.GenerateAuthToken("GET", "pkranges", resourceLink, date.ToLower(), cosmosDbAccountKey, "master", "1.0");
            var url = $"{cosmosDbEndpoint}/{resourceLink}/pkranges";
            var partitionKeyRanges = new List<PartitionKeyRange>();

            string nextContinuationToken = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", token);
                httpClient.DefaultRequestHeaders.Add("x-ms-date", date);
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2018-12-31");

                do
                {
                    httpClient.DefaultRequestHeaders.Remove("x-ms-continuation");
                    if (!string.IsNullOrWhiteSpace(nextContinuationToken))
                    {
                        httpClient.DefaultRequestHeaders.Add("x-ms-continuation", nextContinuationToken);
                    }

                    var response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Headers.TryGetValues("x-ms-continuation", out IEnumerable<string> continuation) && continuation.Any())
                        {
                            nextContinuationToken = continuation.First();
                        }
                        else
                        {
                            nextContinuationToken = null;
                        }

                        var contents = await response.Content.ReadAsStringAsync();
                        var pkrange = JsonConvert.DeserializeObject<PartitionKeyRange>(contents);
                        var raw = new List<string>();
                        raw.Add(contents);
                        pkrange.Raw = raw;
                        partitionKeyRanges.Add(pkrange);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode);
                        break;
                    }
                } while (!string.IsNullOrWhiteSpace(nextContinuationToken));
            }

            return new PartitionKeyRange()
            {
                Count = partitionKeyRanges.Select(pkr => pkr.Count).Sum(),
                Rid = partitionKeyRanges.First().Rid,
                PartitionKeyRanges = partitionKeyRanges.SelectMany(pkr => pkr.PartitionKeyRanges).ToList(),
                Raw = partitionKeyRanges.SelectMany(pkr => pkr.Raw).ToList()
            };
        }

        private static async Task<CosmosDbOffer> GetOffers(string cosmosDbEndpoint, string cosmosDbAccountKey, string selfLink)
        {
            var date = DateTime.Now.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss");
            var token = Helper.GenerateAuthToken("GET", "offers", null, date.ToLower(), cosmosDbAccountKey, "master", "1.0");
            var url = $"{cosmosDbEndpoint}/offers";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", token);
                httpClient.DefaultRequestHeaders.Add("x-ms-date", date);
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2018-12-31");

                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();
                    var offers = JsonConvert.DeserializeObject<CosmosDbOffer>(contents);
                    offers.Raw = contents;
                    return offers;
                }
            }

            return null;
        }
    }
}
