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
            queue: "task_queue",
            durable: true,//dont want to lose queue if rabbitmq server was down ? durable should be true : durable should be false
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

    //Create Message
    var message = GetMessage(args);
    byte[] body = Encoding.UTF8.GetBytes(message);

    //dont want to lose any messages if rabbitmq server was down ? properties.Persistent should be true : properties.Persistent should be false
    var properties = channel.CreateBasicProperties();
    properties.Persistent = true;

    //Publish the message
    channel.BasicPublish(
        exchange: String.Empty,
        routingKey: "task_queue",
        basicProperties: properties,
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