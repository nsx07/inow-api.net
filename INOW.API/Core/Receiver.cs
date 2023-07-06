using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace INOW.API.Core
{
    class Receiver
    {
        private string connectionMQTT;
        protected static Receiver instance;
        private Thread handler;

        private Receiver() {
        }

        public static Receiver Initialize(string connectionMQTT)
        {
            instance = getInstance();
            
            instance.connectionMQTT = connectionMQTT;
            Console.WriteLine(connectionMQTT);

            return instance;
        }

        public static Receiver getInstance()
        {
            if (instance == null)
            {
                instance = new Receiver();
            }
            return instance;
        }

        public void Receive()
        {
            handler = new Thread(IntervalReceiver);
            handler.Priority = ThreadPriority.BelowNormal;
            handler.IsBackground = true;
            handler.Name = "ReceiverThread";
            handler.Start();
        }

        private void IntervalReceiver()
        {
            Uri uri = new Uri(connectionMQTT);
            var factory = new ConnectionFactory { Uri = uri};
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            int counter = 0;

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [{counter}] Received {message}");
                counter++;
            };
            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
            consumer: consumer);

            do Thread.Sleep(1000); while (channel.IsOpen);

            if (channel.IsClosed)
            {
                handler.Interrupt();
            }
        }
    }
}