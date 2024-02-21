// Added library
using System.Text; // Library for encoding and decoding text
using RabbitMQ.Client; // Library for interacting with RabbitMQ

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

// Print to console (promt user to enter name)
Console.WriteLine("Enter your name:");

// Read and store input from user 
var name = Console.ReadLine();

// Create message string with input from name
string message = $"Hello my name is, {name}";

//Print message to console 
Console.WriteLine(message);

//Encode message from sting to bytes using UTF-8
var encodedMessage = Encoding.UTF8.GetBytes(name!); // The '!' is a null forgiving operator 

//Send message to receiver 
// Publish the encoded message to the "nameQueue" queue
channel.BasicPublish("",
                    "nameQueue", 
                    null, 
                    encodedMessage);