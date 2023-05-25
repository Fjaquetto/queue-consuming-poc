namespace TesteChannel.QueuePoc.Contracts
{
    public interface IQueueProducer
    {
        void Enqueue(string message);
    }
}
