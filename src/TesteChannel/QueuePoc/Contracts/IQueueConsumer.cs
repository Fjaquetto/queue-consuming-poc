namespace TesteChannel.QueuePoc.Contracts
{
    public interface IQueueConsumer
    {
        Task StartProcessing(CancellationToken cancellationToken);
    }
}
