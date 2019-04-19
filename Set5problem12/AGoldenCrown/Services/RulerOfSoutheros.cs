using AGoldenCrown.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGoldenCrown.Services
{
    public class RulerOfSoutheros : IRulerOfSoutheros
    {
        private readonly Dictionary<Enum, string> houseAnimalMapping;

        public RulerOfSoutheros()
        {
            houseAnimalMapping = new Dictionary<Enum, string>
            {
                { House.air, "owl" },
                { House.fire, "dragon" },
                { House.ice, "mammoth" },
                { House.land, "pnda" },
                { House.water, "octopus" }
            };
        }

        public string SearchRuler(string question, List<string> inputMessages)
        {
            if (question.ToLower().Equals("Who is the ruler of Southeros?".ToLower()) && inputMessages?.Count > 2)
            {
                return WhoIsTheRuler(inputMessages);
            }
            return "None";
        }

        public string WhoIsTheRuler(List<string> inputMessages)
        {
            int supportOfRuler = 0;
            foreach (var message in inputMessages)
            {
                GetLeader(message, ref supportOfRuler);
            }
            if (supportOfRuler < 3)
            {
                return "None";
            }
            return "King Shan";
        }

        #region PRIVATE METHODS

        private void GetLeader(string message, ref int supportOfRuler)
        {
            string[] msg = message.Split(',');
            Enum.TryParse(msg[0].ToLower(), out House house);
            string encodedMesaage = msg[1].ToLower().Trim();

            switch (house)
            {
                case House.air:
                    if (Decoder(houseAnimalMapping[House.air], encodedMesaage))
                        supportOfRuler += 1;
                    break;

                case House.fire:
                    if (Decoder(houseAnimalMapping[House.fire], encodedMesaage))
                        supportOfRuler += 1;
                    break;

                case House.ice:
                    if (Decoder(houseAnimalMapping[House.ice], encodedMesaage))
                        supportOfRuler += 1;
                    break;

                case House.land:
                    if (Decoder(houseAnimalMapping[House.land], encodedMesaage))
                        supportOfRuler += 1;
                    break;

                case House.water:
                    if (Decoder(houseAnimalMapping[House.water], encodedMesaage))
                        supportOfRuler += 1;
                    break;
            }
        }

        private bool Decoder(string animal, string encodedMesaage)
        {
            foreach (var character in animal.ToCharArray())
            {
                if (encodedMesaage.Contains(character))
                {
                    encodedMesaage.Replace(character, '@');
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        #endregion PRIVATE METHODS
    }    
}