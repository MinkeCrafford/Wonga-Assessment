using System.Text;
using RabbitMQ.Client;

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

// Print to console
Console.WriteLine("Enter your name:");

// Store input from user 
var name = Console.ReadLine();

// Create message string with input from name string 
string message = $"Hello my name is, {name}";

//Print string
Console.WriteLine(message);

//Encode message 
var encodedMessage = Encoding.UTF8.GetBytes(name);

//Send message to receiver 
channel.BasicPublish("",
                    "nameQueue", 
                    null, 
                    encodedMessage);