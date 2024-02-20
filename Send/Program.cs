using System.Text;
using RabbitMQ.Client;

// Create Connection to RabbitMQ service
var factory = new ConnectionFactory { HostName = "localhost"};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();