using System.Threading.Channels;
using TesteChannel.ChannelPoc.Contracts;

namespace TesteChannel.ChannelPoc
{
    public class MessageProducer : IMessageProducer
    {
        private readonly ChannelWriter<string> _messageWriter;

        public MessageProducer(Channel<string> messageChannel)
        {
            _messageWriter = messageChannel.Writer;
        }

        public void Write(string message)
        {
            _messageWriter.WriteAsync(message);
        }
    }
}
