using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace gRpcSample
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override async Task SayHello(HelloRequest request, 
            IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                await responseStream.WriteAsync(new HelloReply { Message = $"Hi {i}" });
                await Task.Delay(500);
            }
        }
    }
}
