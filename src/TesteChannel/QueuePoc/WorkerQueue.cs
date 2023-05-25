using TesteChannel.QueuePoc.Contracts;

namespace TesteChannel.QueuePoc
{
    public class WorkerQueue : BackgroundService
    {
        private readonly IQueueConsumer _messageConsumer;

        public WorkerQueue(IQueueConsumer messageConsumer)
        {
            _messageConsumer = messageConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _messageConsumer.StartProcessing(stoppingToken);
        }
    }
}
