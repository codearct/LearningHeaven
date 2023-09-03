
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics.Tracing;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "task_queue",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

//dont give more than one message to a worker at a time.prefetchCount:1
channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");

    int dots = message.Split(".").Length - 1;
    Thread.Sleep(dots * 1000);

    Console.WriteLine(" [x] Done");

    //if a worker terminated while processing message,nothing is lost.
    channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);
};

channel.BasicConsume(
    queue: "task_queue",
    autoAck: false,//if a worker terminated while processing message,nothing is lost.
    consumer: consumer
);

Console.WriteLine(" Press [enter] to exist.");
Console.ReadLine();


