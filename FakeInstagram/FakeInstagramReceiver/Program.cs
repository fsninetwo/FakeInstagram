using System;
using System.Data.Common;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace FakeInstagramReceiver
{
    class Program
    {
        const string ConnectionString = 
            "Endpoint=sb://fsninetwotestnetwork.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=VxYxi4MgAu34m76KDP+gmTvpdcg+yxNUg7ySv4clnAI=;";

        const string Queuename = "notifyqueue";
        static IQueueClient _queueClient;

        static async Task Main(string[] args)
        {
            _queueClient = new QueueClient(ConnectionString, Queuename);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

            Console.ReadLine();

            await _queueClient.CloseAsync();
        }

        private static async Task ProcessMessageAsync(Message message, CancellationToken arg2)
        {
            var jsonstring = Encoding.UTF8.GetString(message.Body);
            string text = JsonSerializer.Deserialize<string>(jsonstring);
            Console.WriteLine($"Message {text}");

            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"{arg.Exception}");
            return Task.CompletedTask;
        }
    }
}
