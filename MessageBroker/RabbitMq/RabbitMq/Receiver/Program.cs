using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("direct_logs", ExchangeType.Direct);

var queueName = channel.QueueDeclare().QueueName;

if (args.Length < 1)
{
    Console.Error.WriteLine("Usage {0} [info] [warning] [error]", Environment.GetCommandLineArgs()[0]);

    Console.WriteLine("Press [enter] to exit.");
    Console.ReadLine();

    Environment.ExitCode = 1;

    return;
}

foreach (var severity in args)
{
    channel.QueueBind(queue: queueName, exchange: "direct_logs", routingKey: severity);
}


Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var routingKey = eventArgs.RoutingKey;
    Console.WriteLine($" [x] Received '{routingKey}' : '{message}'");
};

channel.BasicConsume(
    queue: queueName,
    autoAck: true,
    consumer: consumer
);

Console.WriteLine(" Press [enter] to exist.");
Console.ReadLine();


