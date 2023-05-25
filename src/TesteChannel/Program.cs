using TesteChannel.ChannelPoc.Contracts;
using TesteChannel.ChannelPoc;
using TesteChannel.QueuePoc;
using TesteChannel.QueuePoc.Contracts;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var messageChannel = Channel.CreateUnbounded<string>();
builder.Services.AddSingleton<IMessageProducer>(new MessageProducer(messageChannel));
builder.Services.AddSingleton<IMessageConsumer>(new MessageConsumer(messageChannel));
builder.Services.AddHostedService<WorkerChannel>();

var messageQueue = new Queue<string>();
builder.Services.AddSingleton<IQueueProducer>(new QueueProducer(messageQueue));
builder.Services.AddSingleton<IQueueConsumer>(new QueueConsumer(messageQueue));
builder.Services.AddHostedService<WorkerQueue>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
