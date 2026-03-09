
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SQS.Fornecedor;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) 
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var queueUrl = configuration["SQS:QueueUrl"];

await ConectSQS.EnviarMensagem(queueUrl);