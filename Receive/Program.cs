using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// Create Connection to RabbitMQ service
var factory = new ConnectionFactory { HostName = "localhost"};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// Declare a message queue
channel.QueueDeclare(queue: "nameQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

// Create consumer, subscribing to receive event
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
    {
        var encodedMessage = ea.Body.ToArray();
        var name = Encoding.UTF8.GetString(encodedMessage); // Decode message (byte to string)

        string response = $"Hello {name}, I am your father!"; // Adds decoded message to string response
        Console.WriteLine(response); // Prints response
    };

