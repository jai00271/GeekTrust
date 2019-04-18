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

        public FindThePrince()
        {
            rulerOfSoutheros = new RulerOfSoutheros();
        }

        private static void Main(string[] args)
        {
            do
            {
                question = Initialize();

                Console.WriteLine(WhoIsTheRuler(question));

                Console.WriteLine(WhoAreTheAlliesOfRuler(question));

            } while (true);
        }

        private static string Initialize()
        {
            inputMessages = new List<string>();

            string question = Convert.ToString(Console.ReadKey());

            if (question.ToLower().Equals("Input Messages to kingdoms from King Shan".ToLower()) && inputMessages.Count == 0)
            {
                Console.WriteLine("How many messages you have, please enter the count.");

                int inputCount = Convert.ToInt32(Console.ReadKey());

                for (int i = 0; i < inputCount; i++)
                {
                    inputMessages.Add(Console.ReadLine());
                }
            }

            return question;
        }

        public static string WhoIsTheRuler(string question)
        {
            if (question.ToLower().Equals("Who is the ruler of Southeros?".ToLower()))
            {
                return rulerOfSoutheros.WhoIsTheRuler(inputMessages);
            }
            return "None";
        }

        public static StringBuilder WhoAreTheAlliesOfRuler(string question)
        {
            if (question.ToLower().Equals("Allies of Ruler?".ToLower()))
            {
                return rulerOfSoutheros.AlliesOfRuler(inputMessages);
            }
            return new StringBuilder("None");
        }
    }
}