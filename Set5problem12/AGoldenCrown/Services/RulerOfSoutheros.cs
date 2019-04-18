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
                { House.air, "Owl" },
                { House.fire, "Dragon" },
                { House.ice, "Mammoth" },
                { House.land, "Panda" },
                { House.water, "Octopus" }
            };
        }

        public StringBuilder AlliesOfRuler(List<string> inputMessages)
        {
            StringBuilder ruler = new StringBuilder();
            foreach (var message in inputMessages)
            {
                GetAllies(ruler, message);
            }
            return ruler;
        }

        public string WhoIsTheRuler(List<string> inputMessages)
        {
            string ruler = null;
            foreach (var message in inputMessages)
            {
                GetLeader(message, ref ruler);
            }
            return ruler;
        }

        #region PRIVATE METHODS

        private void GetLeader(string message, ref string ruler)
        {
            string[] msg = message.Split(',');
            Enum.TryParse(msg[0].ToLower(), out House house);
            string encodedMesaage = msg[1].Trim();

            switch (house)
            {
                case House.air:
                    Decoder(houseAnimalMapping[House.air], encodedMesaage);
                    ruler = houseAnimalMapping[House.air];
                    break;

                case House.fire:
                    Decoder(houseAnimalMapping[House.fire], encodedMesaage);
                    ruler = houseAnimalMapping[House.fire];
                    break;

                case House.ice:
                    Decoder(houseAnimalMapping[House.ice], encodedMesaage);
                    ruler = houseAnimalMapping[House.ice];
                    break;

                case House.land:
                    Decoder(houseAnimalMapping[House.land], encodedMesaage);
                    ruler = houseAnimalMapping[House.land];
                    break;

                case House.water:
                    Decoder(houseAnimalMapping[House.water], encodedMesaage);
                    ruler = houseAnimalMapping[House.water];
                    break;
            }
        }

        private static void GetAllies(StringBuilder ruler, string message)
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

    public enum House
    {
        land = 1,
        water = 2,
        ice = 3,
        air = 4,
        fire = 5
    }
}