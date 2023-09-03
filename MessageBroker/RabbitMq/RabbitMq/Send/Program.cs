using RabbitMQ.Client;
using System.Text;

try
{
    //connection
    var factory = new ConnectionFactory { HostName = "localhost" };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();

    //Create Queue
    channel.QueueDeclare(
            queue: "hello",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

    //Create Message
    const string message = "Hello World";
    byte[] body = Encoding.UTF8.GetBytes(message);

    //Publish the message
    channel.BasicPublish(
        exchange: String.Empty,
        routingKey: "hello",
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