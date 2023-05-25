using System.Diagnostics;
using TesteChannel.ChannelPoc.Contracts;
using TesteChannel.QueuePoc.Contracts;

namespace TesteChannel.QueuePoc
{
    public class QueueConsumer : IQueueConsumer
    {
        private readonly Queue<string> _messageQueue;

        public QueueConsumer(Queue<string> messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public async Task StartProcessing(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_messageQueue.Count > 0)
                {
                    var message = _messageQueue.Dequeue();
                    // Process the message
                    Debug.WriteLine($"Processing queue message: {message}");
                }
                else
                {
                    // Wait a short period before checking the queue again
                    await Task.Delay(1000, cancellationToken);
                }
            }
        }
    }
}
