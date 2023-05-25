using System.Threading.Channels;

namespace TesteChannel.ChannelPoc.Contracts
{
    public interface IMessageProducer
    {
        void Write(string message);
    }
}
