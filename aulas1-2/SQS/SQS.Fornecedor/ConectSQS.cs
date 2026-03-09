using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS.Fornecedor
{
    public class ConectSQS
    {
        public static async Task EnviarMensagem(string queueUrl)
        {
            var client = new AmazonSQSClient(RegionEndpoint.SAEast1);

            var request = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = " Mensagem Postada"
            };

            var response = await client.SendMessageAsync(request);
        }
    }
}

