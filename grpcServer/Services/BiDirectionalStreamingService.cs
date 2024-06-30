using Grpc.Core;
using grpcBiDirectionalStreamingServer;


namespace grpcServer.Services;

public class BiDirectionalStreamingService : BiDirectionalStreaming.BiDirectionalStreamingBase
{
    public override async Task SendMessage(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        var taskResponse = Task.Run(async ()=>{
            while(await requestStream.MoveNext(context.CancellationToken)){
                           System.Console.WriteLine($"Name : {requestStream.Current.Name} | Message : {requestStream.Current.Message}");
            }
        });

       for (int i = 0; i < 10; i++)
       {
        await Task.Delay(1000);
        await responseStream.WriteAsync(new MessageResponse{
            Message =" Bi-directional streaming work succesfully!"
        });
       }

       await taskResponse;
    }
}