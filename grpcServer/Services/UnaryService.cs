using Grpc.Core;
using grpcUnaryServer;

namespace grpcServer.Services;

public class UnaryService : Unary.UnaryBase
{
    public override async Task<MessageResponse> SendMessage(MessageRequest request, ServerCallContext context)
    {
        System.Console.WriteLine($" Name : {request.Name} | Message : {request.Message}");
        return new MessageResponse{
            Message="Unary works successfully!"
        } ;
    }
}