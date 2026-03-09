using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;


namespace SQS.Consumidor
{
    public class ConectSQS
    {
        public static async Task RecebeMensagem(string queueUrl)
        {
            var client = new AmazonSQSClient(RegionEndpoint.SAEast1);

            var request = new ReceiveMessageRequest
            {
                QueueUrl = queueUrl,
               
            };

            var response = await client.ReceiveMessageAsync(request);
            foreach (var item in response.Messages)
            {
                Console.WriteLine(item.Body);
                await client.DeleteMessageAsync(new DeleteMessageRequest
                {
                    QueueUrl = queueUrl,
                    ReceiptHandle = item.ReceiptHandle
                });
            }
        }
    }
}
