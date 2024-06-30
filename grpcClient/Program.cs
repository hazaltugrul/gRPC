using Grpc.Net.Client;
using grpcServer;
using grpcUnaryServer;

var channel = GrpcChannel.ForAddress("http://localhost:5119");
var unaryClient = new Unary.UnaryClient(channel);

MessageResponse response = await unaryClient.SendMessageAsync(new MessageRequest{
    Message = "Hello from client",
    Name = "Hazal"
});

//var client = new Greeter.GreeterClient(channel);

// HelloReply response= await client.SayHelloAsync(new HelloRequest
// {
//     Name = "Hazal's Request"
// });

System.Console.WriteLine(response.Message);