using Grpc.Core;
using grpcClientStreamingServer;


namespace grpcServer.Services;

public class ClientStreamingService : ClientStreaming.ClientStreamingBase
{
    public override async Task<MessageResponse> SendMessage(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
    {
        while(await requestStream.MoveNext(context.CancellationToken)){
           System.Console.WriteLine($"Name : {requestStream.Current.Name} | Message : {requestStream.Current.Message}");
        }
        return new MessageResponse{
            Message = "Client Streaming work successfully!"
        };
    }
}