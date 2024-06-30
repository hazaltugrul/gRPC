using Grpc.Core;
using grpcServerStreamingServer;

namespace grpcServer.Services;

public class ServerStreamingService : ServerStreaming.ServerStreamingBase
{
    public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
       System.Console.WriteLine($" Name : {request.Name} | Message : {request.Message}");
       for(int i=0; i<10; i++){
        await Task.Delay(10);
        await responseStream.WriteAsync(new MessageResponse{
             Message = "Server Streaming works successfully!"
       });
       }

    }
}