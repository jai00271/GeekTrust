namespace AGoldenCrown
{
    using AGoldenCrown.Services;
    using System;
    using System.Collections.Generic;

    public class FindThePrince
    {
        public static string question;
        public static List<string> inputMessages;
        public static IRulerOfSoutheros rulerOfSoutheros;
        public static IAlliesOfRuler alliesOfRuler;

        static FindThePrince()
        {
            rulerOfSoutheros = new RulerOfSoutheros();
            alliesOfRuler = new AlliesOfRuler();
        }

        private static void Main(string[] args)
        {
            do
            {
                Initialize(out question);
            } while (true);
        }

        private static void Initialize(out string question)
        {
            inputMessages = new List<string>();

            question = Convert.ToString(Console.ReadLine());
            string message = null;

            if (question.ToLower().Contains("Input Messages to kingdoms from King Shan".ToLower()) && inputMessages.Count == 0)
            {
                do
                {
                    message = Console.ReadLine();
                    if (!string.IsNullOrEmpty(message) && !message.Contains("Who is the ruler of Southeros") && !message.Contains("Allies"))
                        inputMessages.Add(message);
                    if (message.Contains("Who is the ruler of Southeros"))
                        Console.WriteLine(rulerOfSoutheros.SearchRuler(message, inputMessages));
                    if (message.Contains("Allies"))
                        Console.WriteLine(alliesOfRuler.WhoAreTheAlliesOfRuler(message, inputMessages));
                } while (!message.Contains("Allies"));
            }
            else
            {
                if (!string.IsNullOrEmpty(question))
                    Console.WriteLine("None");
            }
            question = message;
        }
    }
}