namespace TesteChannel.ChannelPoc.Contracts
{
    public interface IMessageConsumer
    {
        Task StartProcessing(CancellationToken cancellationToken);
    }
}
