using System.Diagnostics;
using TesteChannel.ChannelPoc.Contracts;
using TesteChannel.QueuePoc.Contracts;

namespace TesteChannel.QueuePoc
{
    public class QueueProducer : IQueueProducer
    {
        private readonly Queue<string> _messageQueue;

        public QueueProducer(Queue<string> messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public void Enqueue(string message)
        {
            _messageQueue.Enqueue(message);

            //Debug.WriteLine(_messageQueue.Count());
        }
    }
}
