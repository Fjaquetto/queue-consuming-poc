using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteChannel.ChannelPoc.Contracts;
using TesteChannel.QueuePoc.Contracts;

namespace TesteChannel.Controllers
{
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;
        private readonly IQueueProducer _queueProducer;

        public QueueController(
            IMessageProducer messageProducer,
            IQueueProducer queueProducer)
        {
            _queueProducer = queueProducer;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        [Route("channel")]
        public IActionResult Channel()
        {
            for (int i = 1; i <= 10000; i++)
            {
                _messageProducer.Write("message " + i);
            }
            return Ok();
        }

        [HttpPost]
        [Route("queue")]
        public IActionResult Queue()
        {
            for (int i = 1; i <= 10000; i++)
            {
                _queueProducer.Enqueue("message " + i);
            }
            return Ok();
        }
    }
}
