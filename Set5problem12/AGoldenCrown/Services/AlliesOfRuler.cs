using AGoldenCrown.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGoldenCrown.Services
{
    public class AlliesOfRuler : IAlliesOfRuler
    {
        public string WhoAreTheAlliesOfRuler(string question, List<string> inputMessages)
        {
            if (!ValidateAlliesOfRuler(question, inputMessages))
            {
                return "None";
            }
            if (question.ToLower().Contains("Allies of".ToLower()) && inputMessages?.Count > 0)
            {
                return GetAllies(inputMessages);
            }
            return "None";
        }

        public string GetAllies(List<string> inputMessages)
        {
            StringBuilder ruler = new StringBuilder();
            foreach (var message in inputMessages)
            {
                GetAlliesList(ruler, message);
            }
            return Convert.ToString(ruler).TrimStart(',').Trim();
        }

        #region PRIVATE METHODS

        private bool ValidateAlliesOfRuler(string question, List<string> inputMessages)
        {
            if (inputMessages.Count < 3)
            {
                return false;
            }
            return true;
        }

        private void GetAlliesList(StringBuilder ruler, string message)
        {
            string[] msg = message.Split(',');
            Enum.TryParse(msg[0].ToLower(), out House house);

            switch (house)
            {
                case House.air:
                    ruler.Append(", Air");
                    break;

                case House.fire:
                    ruler.Append(", Fire");

                    break;

                case House.ice:
                    ruler.Append(", Ice");

                    break;

                case House.land:
                    ruler.Append(", Land");

                    break;

                case House.water:
                    ruler.Append(", Water");
                    break;
            }
        }

        #endregion PRIVATE METHODS
    }
}