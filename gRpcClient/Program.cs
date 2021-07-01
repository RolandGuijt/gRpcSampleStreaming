using System;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using Grpc.Net.Client;

namespace gRpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50051");
            var client = new Greeter.GreeterClient(channel);
            var call = client.SayHello(
                              new HelloRequest { Name = "GreeterClient" });

            await foreach (var message in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine("Greeting: " + message.Message);
            }
            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
