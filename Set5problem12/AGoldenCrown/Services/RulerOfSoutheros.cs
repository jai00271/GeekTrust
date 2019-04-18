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
                { House.AIR, "Owl" },
                { House.FIRE, "Dragon" },
                { House.ICE, "Mammoth" },
                { House.LAND, "Panda" },
                { House.WATER, "Octopus" }
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
            Enum.TryParse(msg[0], out House house);
            string encodedMesaage = msg[1].Trim();

            switch (house)
            {
                case House.AIR:
                    Decoder(houseAnimalMapping[House.AIR], encodedMesaage);
                    ruler = houseAnimalMapping[House.AIR];
                    break;

                case House.FIRE:
                    Decoder(houseAnimalMapping[House.FIRE], encodedMesaage);
                    ruler = houseAnimalMapping[House.FIRE];
                    break;

                case House.ICE:
                    Decoder(houseAnimalMapping[House.ICE], encodedMesaage);
                    ruler = houseAnimalMapping[House.ICE];
                    break;

                case House.LAND:
                    Decoder(houseAnimalMapping[House.LAND], encodedMesaage);
                    ruler = houseAnimalMapping[House.LAND];
                    break;

                case House.WATER:
                    Decoder(houseAnimalMapping[House.WATER], encodedMesaage);
                    ruler = houseAnimalMapping[House.WATER];
                    break;
            }
        }

        private static void GetAllies(StringBuilder ruler, string message)
        {
            string[] msg = message.Split(',');
            Enum.TryParse(msg[0], out House house);

            switch (house)
            {
                case House.AIR:
                    ruler.Append("Air");
                    break;

                case House.FIRE:
                    ruler.AppendJoin(",", "Fire");

                    break;

                case House.ICE:
                    ruler.AppendJoin(",", "Ice");

                    break;

                case House.LAND:
                    ruler.AppendJoin(",", "Land");

                    break;

                case House.WATER:
                    ruler.AppendJoin(",", "Water");

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
        LAND = 1,
        WATER = 2,
        ICE = 3,
        AIR = 4,
        FIRE = 5
    }
}