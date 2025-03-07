using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class DiceRoller
    {
        private static Random random = new Random();

        public static int RollDice()
        {
            return random.Next(1, 7);
        }

        public static (int totalHits, int[] hitsCounts) RollHits(int diceCount, int bsThreshold)
        {
            int hits = 0;
            int[] hitDiceCounter = new int[6];
            for (int i = 0; i < diceCount; i++)
            {
                int roll = RollDice();
                hitDiceCounter[roll - 1]++;
                if (roll >= bsThreshold)
                {
                    hits++;
                }
            }

            return (hits, hitDiceCounter);
        }

        public static (int totalWounds, int[] woundsCounts) RollWounds(int hits, int strength, int toughness)
        {
            int wounds = 0;
            int[] woundDiceCounter = new int[6];

            int woundThreshold = CalculateWoundThreshold(strength, toughness);

            for (int i = 0; i < hits; i++)
            {
                int roll = RollDice();
                woundDiceCounter[roll - 1]++;
                if (roll >= woundThreshold)
                {
                    wounds++;
                }
            }

            return (wounds, woundDiceCounter);
        }

        private static int CalculateWoundThreshold(int strength, int toughness)
        {
            if (strength >= 2 * toughness)
                return 2;
            if (strength > toughness)
                return 3;
            if (strength == toughness)
                return 4;
            if (strength * 2 <= toughness)
                return 6;
            return 5;
        }
    }
}
