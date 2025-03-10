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
            for (int h = 0; h < diceCount; h++)
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

            for (int w = 0; w < hits; w++)
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

        public static (int totalSaves, int[] savesCounts) RollSaves(int wounds, int saveThreshold, int ap)
        {
            int saves = 0;
            int[] saveDiceCounter = new int[6];
            int adjustedSaveThreshold = saveThreshold - ap;

            for (int s = 0; s < wounds; s++)
            {
                int roll = RollDice();
                saveDiceCounter[roll - 1]++;
                if (roll >= adjustedSaveThreshold)
                {
                    saves++;
                }
            }
            return (saves, saveDiceCounter);
        }
    }
}
