using System;
using System.IO;

namespace Task2_Events
{
    public delegate void MessageEventHandler(string message);

    class MessagePublisher
    {
        public event MessageEventHandler MessageSent;

        public void Send(string message)
        {
            if (MessageSent != null)
            {
                MessageSent(message);
            }
        }
    }

    class FileLogger
    {
        public void LogMessage(string message)
        {
            string fileName = "logPD21.txt";

            string time = DateTime.Now.ToString("HH:mm:ss");
               
            string logEntry = $"[{time}] {message}\n";

            File.AppendAllText(fileName, logEntry);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("logPD21.txt", "");

            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger();

            publisher.MessageSent += logger.LogMessage;

            Console.WriteLine("Введіть текст 4 рази:");

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Рядок {i + 1}: ");
                string input = Console.ReadLine();

                publisher.Send(input);
            }

            Console.WriteLine("Завдання 2 виконано. Перевірте файл logPD21.txt");
            Console.ReadLine();
        }
    }
}