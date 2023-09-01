
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
	HostName = "localhost",
	UserName = "jucastro",
	Password = "JuanCastro2023",
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
	channel.QueueDeclare("VaxiQueue", false, false, false, null);

	var message = "Bienvenido al curso de RabbitMq y .NET";
	var body = Encoding.UTF8.GetBytes(message);

	channel.BasicPublish("", "VaxiQueue",null,body);
	Console.WriteLine("El mensaje fue enviado {0}", message);

}

Console.WriteLine("Presiona [enter] para salir de la aplicación");
Console.ReadLine();