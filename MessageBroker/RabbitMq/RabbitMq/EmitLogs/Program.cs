using RabbitMQ.Client;
using System.Text;

try
{
    var factory = new ConnectionFactory { HostName = "localhost" };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();

    channel.ExchangeDeclare("logs", ExchangeType.Fanout);

    var message = GetMessage(args);
    byte[] body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "logs",
        routingKey: String.Empty,
        basicProperties: null,
        body: body
    );

    Console.WriteLine($"[x] Sent {message}");

    Console.WriteLine(" Press [enter] to exit. ");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static string GetMessage(string[] args)
{
    return ((args.Length > 0) ? String.Join(" ", args) : "Hello World!");
}