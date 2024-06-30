using Grpc.Net.Client;
using grpcServer;
//using grpcUnaryClient;
//using grpcServerStreamingClient;
using grpcClientStreamingClient;

var channel = GrpcChannel.ForAddress("http://localhost:5119");

#region ClientStreaming
var clientStreamingClient = new ClientStreaming.ClientStreamingClient(channel);
var request = clientStreamingClient.SendMessage();
for (int i = 0; i < 10; i++)
{
    await Task.Delay(1000);
    await request.RequestStream.WriteAsync(new MessageRequest{
      Name = "Hazal",
      Message ="Hello from client"
    });
}

request.RequestStream.CompleteAsync();
System.Console.WriteLine((await request.ResponseAsync).Message);

#endregion


#region ServerStreaming
//     var serverStreamingClient = new ServerStreaming.ServerStreamingClient(channel);
//     var response = serverStreamingClient.SendMessage(new MessageRequest{
//         Name ="Hazal",
//         Message = "Hello from client"
//     });

//     CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    
//    while(await response.ResponseStream.MoveNext(cancellationTokenSource.Token)){
//         System.Console.WriteLine(response.ResponseStream.Current.Message);
//     }
#endregion

#region Unary
    // var unaryClient = new Unary.UnaryClient(channel);
    
    // MessageResponse response = await unaryClient.SendMessageAsync(new MessageRequest{
    //     Message = "Hello from client",
    //     Name = "Hazal"
    // });
    // System.Console.WriteLine(response.Message);
#endregion

#region FirstTry
    //var client = new Greeter.GreeterClient(channel);
    
    // HelloReply response= await client.SayHelloAsync(new HelloRequest
    // {
    //     Name = "Hazal's Request"
    // });
    // System.Console.WriteLine(response.Message);
#endregion

