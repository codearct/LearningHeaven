using RabbitMQ.Client;
using System.Text;

try
{
    var factory = new ConnectionFactory { HostName = "localhost" };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();

    channel.ExchangeDeclare("topic_logs", ExchangeType.Topic);

    var routingKey = (args.Length > 0) ? args[0] : "anonymous.info";

    var message = (args.Length > 1)
        ? String.Join(" ", args.Skip(1).ToArray())
        : "Hello World";
    byte[] body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "topic_logs",
        routingKey: routingKey,
        basicProperties: null,
        body: body
    );

    Console.WriteLine($"[x] Sent '{routingKey}' : '{message}'");

    Console.WriteLine(" Press [enter] to exit. ");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
