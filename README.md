# CosmosUtility

A simple utility to get cosmos DB related metrics using REST API.
This command line tool will return the following information for you container:
- Indexing policy
- Partition key
- Statistics for physical partition, i.e. utilized size and document count
- Partition key ranges

## Prerequisite

- .NET CORE 3.1 SDK

## Setup and Usage

1. Clone this repository
2. Execute `dotnet build` command in root folder
3. Bring up your terminal and browse to `CosmosUtility\bin\debug\netcoreapp3.1` folder where the executables
4. Execute command
  - Instruction page:
    ```
    > ./cosmosutility -h
    ```
  - Retrieve metrics for a collection:
    ```
    > ./cosmosutility -e [cosmos db account endpoint] -k [cosmos db account key] -d [database name] -c [container name]
    ```
