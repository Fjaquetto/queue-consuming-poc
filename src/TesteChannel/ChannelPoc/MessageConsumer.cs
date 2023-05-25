using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using TesteChannel.ChannelPoc.Contracts;

namespace TesteChannel.ChannelPoc
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly ChannelReader<string> _messageReader;

        public MessageConsumer(Channel<string> messageChannel)
        {
            _messageReader = messageChannel.Reader;
        }

        public async Task StartProcessing(CancellationToken cancellationToken)
        {
            await foreach (var message in _messageReader.ReadAllAsync(cancellationToken))
            {
                // Process the message
                Debug.WriteLine($"Processing channel message: {message}");
            }
        }
    }
}

