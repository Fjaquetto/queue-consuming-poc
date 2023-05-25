using TesteChannel.ChannelPoc.Contracts;

namespace TesteChannel.ChannelPoc
{
    public class WorkerChannel : BackgroundService
    {
        private readonly IMessageConsumer _messageConsumer;

        public WorkerChannel(IMessageConsumer messageConsumer)
        {
            _messageConsumer = messageConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _messageConsumer.StartProcessing(stoppingToken);
        }
    }
}
