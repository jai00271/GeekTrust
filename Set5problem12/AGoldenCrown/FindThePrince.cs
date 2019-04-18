namespace AGoldenCrown
{
    using AGoldenCrown.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FindThePrince
    {
        public static string question;
        public static List<string> inputMessages;
        public static IRulerOfSoutheros rulerOfSoutheros;

        static FindThePrince()
        {
            rulerOfSoutheros = new RulerOfSoutheros();
        }

        private static void Main(string[] args)
        {
            do
            {
                inputMessages = Initialize(out question);

                Console.WriteLine(WhoIsTheRuler(question, inputMessages));

                Console.WriteLine(WhoAreTheAlliesOfRuler(question, inputMessages));
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

        public static string WhoIsTheRuler(string question, List<string> inputMessages)
        {
            if (question.ToLower().Equals("Who is the ruler of Southeros?".ToLower()) && inputMessages?.Count > 2)
            {
                return rulerOfSoutheros.WhoIsTheRuler(inputMessages);
            }
            return "None";
        }

        public static StringBuilder WhoAreTheAlliesOfRuler(string question, List<string> inputMessages)
        {
            if (!ValidateAlliesOfRuler(question, inputMessages))
            {
                return new StringBuilder("None");
            }
            if (question.ToLower().Contains("Allies of".ToLower()) && inputMessages?.Count > 0)
            {
                return rulerOfSoutheros.AlliesOfRuler(inputMessages);
            }
            return new StringBuilder("None");
        }

        private static bool ValidateAlliesOfRuler(string question, List<string> inputMessages)
        {
            if (inputMessages.Count < 3)
            {
                return false;
            }
            return true;
        }
    }
}