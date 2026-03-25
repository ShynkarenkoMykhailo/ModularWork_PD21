using System;
using System.IO;

namespace Task1_Delegates
{
    public delegate string TextOperation(string text);

    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("textPD21.txt", "Привіт! Це тестовий рядок для перевірки.");

            File.WriteAllText("resultPD21.txt", "");

            ProcessFile(ToUpperCase);
            ProcessFile(CountCharacters);
            ProcessFile(CountWords);

            Console.WriteLine("Завдання 1 виконано. Перевірте файл resultPD21.txt");
            Console.ReadLine();
        }

        static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }
                 
        static string CountCharacters(string text)
        {
            int count = text.Length;
            return "Кількість символів: " + count;
        }

        static string CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int count = words.Length;
            return "Кількість слів: " + count;
        }

        static void ProcessFile(TextOperation operation)
        {
            string inputFile = "textPD21.txt";
            string outputFile = "resultPD21.txt";

            string text = File.ReadAllText(inputFile);

            string result = operation(text);

            File.AppendAllText(outputFile, result + "\n");
        }
    }
}