// Added library
using System.Text; // Library for encoding and decoding text
using RabbitMQ.Client; // Library for interacting with RabbitMQ
using RabbitMQ.Client.Events; // Library to access classes related to RabbitMQ consumer events.

// Create connection factory to connect to RabbitMQ service
var factory = new ConnectionFactory { HostName = "localhost"};

// Establish a connection to the RabbitMQ service
using var connection = factory.CreateConnection();

// Create a channel, which is used for communication with RabbitMQ
using var channel = connection.CreateModel();

// Declare a message queue
channel.QueueDeclare(queue: "nameQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

// Create consumer for receiving messages from the queue
var consumer = new EventingBasicConsumer(channel);

// Define an event handler for processing received messages
consumer.Received += (model, ea) =>
    {
        // Extract the message & Decode message (byte to string)
        var encodedMessage = ea.Body.ToArray();
        var name = Encoding.UTF8.GetString(encodedMessage); 

        // Takes received message and adds it to string response
        string response = $"Hello {name}, I am your father!"; 
        Console.WriteLine(response); // Prints message (response)
    };

// Consume message from the queue (nameQueue)
channel.BasicConsume(queue: "nameQueue",
                            autoAck: true, // AutoAck is set to true, which means messages are automatically acknowledged once received
                            consumer: consumer);