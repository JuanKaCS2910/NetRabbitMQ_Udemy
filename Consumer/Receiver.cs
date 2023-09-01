
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
	HostName ="localhost",
	UserName = "jucastro",
	Password = "JuanCastro2023"
};


using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
	channel.QueueDeclare("VaxiQueue", false, false, false, null);

	var consumer = new EventingBasicConsumer(channel);
	consumer.Received += (model, ea) =>
	{
		var body = ea.Body.Span;
		var message = Encoding.UTF8.GetString(body);
		Console.WriteLine("Mensaje recibido {0}", message);
	};

	channel.BasicConsume("VaxiQueue", true, consumer);
	Console.WriteLine("Presiona [enter] para salir del consumer");
	Console.ReadLine();
}
