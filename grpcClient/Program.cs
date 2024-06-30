using Grpc.Net.Client;
using grpcServer;

var channel = GrpcChannel.ForAddress("http://localhost:5119");
var client = new Greeter.GreeterClient(channel);

HelloReply response= await client.SayHelloAsync(new HelloRequest
{
    Name = "Hazal's Request"
});

System.Console.WriteLine(response.Message);