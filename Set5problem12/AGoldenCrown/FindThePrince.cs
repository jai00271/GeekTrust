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
                inputMessages = Initialize(out question);

                Console.WriteLine(rulerOfSoutheros.SearchRuler(question, inputMessages));

                Console.WriteLine(alliesOfRuler.WhoAreTheAlliesOfRuler(question, inputMessages));
            } while (true);
        }

        private static List<string> Initialize(out string question)
        {
            inputMessages = new List<string>();

            question = Convert.ToString(Console.ReadKey());

            if (question.ToLower().Equals("Input Messages to kingdoms from King Shan".ToLower()) && inputMessages.Count == 0)
            {
                Console.WriteLine("How many messages you have, please enter the count.");

                int inputCount = Convert.ToInt32(Console.ReadKey());

                for (int i = 0; i < inputCount; i++)
                {
                    inputMessages.Add(Console.ReadLine());
                }
            }

            return inputMessages;
        }
    }
}