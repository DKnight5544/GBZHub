using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hub.CustomClasses
{
    public class DiceTosser
    {
        Random random = new Random();
        const string DICE_VALUES = "123456";
        public string GetRandomDice(int diceCount)
        {
            string result = "";
            for (int d = 0; d < diceCount; d++)
            {
                int rnd = random.Next(0, 6);
                result += DICE_VALUES.Substring(rnd, 1);
            }
            return result;
        }
    }
}